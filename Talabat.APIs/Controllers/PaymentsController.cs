using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Stripe;
using System.IO;
using System.Threading.Tasks;
using Talabat.APIs.Errors;
using Talabat.Core.Entities;
using Talabat.Core.Entities.Order_Aggregate;
using Talabat.Core.Services;

namespace Talabat.APIs.Controllers
{
    public class PaymentsController : BaseApiController
    {
        private readonly IPaymentService _paymentService;
        private readonly ILogger<PaymentsController> _logger;
        private const string _webhook = "whsec_67aaa1c3ba4a47402244c598e626eb7427bc757aea1f38bf35ecd8fd36c83849";

        public PaymentsController(IPaymentService paymentService, ILogger<PaymentsController> logger)
        {
            _paymentService = paymentService;
            this._logger = logger;
        }
        //[Authorize]
        [HttpPost("{basketid}")]
        public async Task<ActionResult<CustomerBasket>> CreateOrUpdatePaymentIntent(string basketId)
        {
            var basket = await _paymentService.CreateOrUpdatePaymentIntent(basketId);

            if (basket == null) return BadRequest(new ApiResponse(400, "A Problem With Your Basket"));

            return Ok(basket);
        }
        [HttpPost("webhook")]
        public async Task<ActionResult> StripeWebHook()
        {
            var Json = await new StreamReader(HttpContext.Request.Body).ReadToEndAsync();

            var StripeEvent = EventUtility.ConstructEvent(Json, Request.Headers["Stripe-Signature"], _webhook);
            var paymentIntent = (PaymentIntent)StripeEvent.Data.Object;
            Order order;
            switch (StripeEvent.Type)
            {
                case Events.PaymentIntentSucceeded:
                    order = await _paymentService.UpdatePaymentIntentToSucceededOrFailed(paymentIntent.Id, true);
                    _logger.LogInformation("Payment is succeeded", paymentIntent.Id);
                    break;
                case Events.PaymentIntentPaymentFailed:
                    order = await _paymentService.UpdatePaymentIntentToSucceededOrFailed(paymentIntent.Id, false);
                    _logger.LogInformation("Payment is failed", paymentIntent.Id);
                    break;
            }
            return Ok();
        }
    }

}

