using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Threading.Tasks;
using Talabat.APIs.Dtos;
using Talabat.Core.Entities;
using Talabat.Core.Repositories;
using Talabat.Repository.Data;

namespace Talabat.APIs.Controllers
{
	public class BasketController : BaseApiController
	{
		#region params basket|mapper

		private readonly IBasketRepository _basketRepository;
		private readonly IMapper _mapper;
		private readonly StoreContext _context;
		#endregion

		#region ctor
		public BasketController(IBasketRepository basketRepository, IMapper mapper, StoreContext context)
		{
			_basketRepository = basketRepository;
			_mapper = mapper;
			_context = context;
		}
		#endregion

		#region crud

		#region get by id

		[HttpGet]
		public async Task<ActionResult<CustomerBasket>> GetBasketById(string id)
		{
			var basket = await _basketRepository.GetBasketAsync(id);
			return Ok(basket ?? new CustomerBasket(id));
		}
		#endregion

		#region update

		[HttpPost]
		public async Task<ActionResult<CustomerBasket>> UpdateBasket(CustomerBasketDto basket)
		{
			var mappedBasket = _mapper.Map<CustomerBasketDto, CustomerBasket>(basket);
			var updatedBasket = await _basketRepository.UpdateBasketAsync(mappedBasket);
			return Ok(updatedBasket);
		}
		#endregion

		#region update quantity
		[HttpPost("updateQuantity")]
		public async Task<IActionResult> UpdateQuantity([FromBody] Basket updatedBasket)
		{
			if (updatedBasket == null)
			{
				return BadRequest("Invalid data");
			}

			try
			{
				var existingBasket = await _context.Orders
					.Include(b => b.Items) // Assuming Items is a navigation property in your Basket model
					.FirstOrDefaultAsync(b => b.Id == updatedBasket.Id);

				if (existingBasket == null)
				{
					return NotFound("Basket not found");
				}

				// Update the quantity for each item in the basket
				foreach (var updatedItem in updatedBasket.Items)
				{
					var existingItem = existingBasket.Items.FirstOrDefault(i => i.Id == updatedItem.Id);
					if (existingItem != null)
					{
						existingItem.Quantity = updatedItem.Quantity;
						// You may need to update other properties as well
					}
				}

				await _context.SaveChangesAsync();

				return Ok(existingBasket); // You can return the updated basket if needed
			}
			catch (Exception ex)
			{
				// Log the exception or handle it accordingly
				return StatusCode(500, "Internal Server Error");
			}
		}
		#endregion

		#region is enough
		[HttpPost("isQuantityEnough")]
		public IActionResult IsQuantityEnough([FromBody] Basket basket)
		{
			if (basket == null)
			{
				return BadRequest("Invalid data");
			}

			try
			{
				bool isEnough = true; // Initialize to true, and we'll set it to false if any condition fails

				foreach (var item in basket.Items)
				{
					var product = _context.Products.FirstOrDefault(i => i.Id == item.Id);

					if (product == null)
					{
						return NotFound($"Product with ID {item.Id} not found");
					}

					// Check if the quantity in the basket is greater than the available quantity
					if (item.Quantity > product.Quantity)
					{
						isEnough = false;
						break; // No need to continue checking if one item doesn't meet the criteria
					}
				}

				return Ok(isEnough);
			}
			catch (Exception ex)
			{
				// Log the exception or handle it accordingly
				return StatusCode(500, "Internal Server Error");
			}
		}

		#endregion

		#region delete

		[HttpDelete]
		public async Task DeleteBasket(string id)
		{
			await _basketRepository.DeleteBasketAsync(id);
		}
		#endregion
		#endregion

	}
}
