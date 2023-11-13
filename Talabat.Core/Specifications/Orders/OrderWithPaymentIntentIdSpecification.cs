using Talabat.Core.Entities.Order_Aggregate;

namespace Talabat.Core.Specifications.Orders
{
    public class OrderWithPaymentIntentIdSpecification : BaseSpecification<Order>
    {
        public OrderWithPaymentIntentIdSpecification(string paymentId) : base(O => O.PaymentIntentId == paymentId)
        {

        }


    }
}
