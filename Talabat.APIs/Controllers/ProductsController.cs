using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;
using Talabat.APIs.Dtos;
using Talabat.APIs.Errors;
using Talabat.APIs.Helpers;
using Talabat.Core.Entities;
using Talabat.Core.Repositories;
using Talabat.Core.Specifications.Products;

namespace Talabat.APIs.Controllers
{

	public class ProductsController : BaseApiController
	{
		#region params

		private readonly IGenericRepository<Product> _productsRepo;
		private readonly IGenericRepository<ProductType> _typesRepo;
		private readonly IGenericRepository<ProductBrand> _brandsRepo;
		private readonly IMapper _mapper;
		#endregion

		#region ctor
		public ProductsController(IGenericRepository<Product> productsRepo,
			IGenericRepository<ProductBrand> brandsRepo,
			IGenericRepository<ProductType> typesRepo,
			IMapper mapper)
		{
			_productsRepo = productsRepo;
			_typesRepo = typesRepo;
			_brandsRepo = brandsRepo;
			_mapper = mapper;
		}
		#endregion

		#region get product

		//[Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
		[HttpGet]
		public async Task<ActionResult<Pagination<ProductToReturnDto>>> GetProducts([FromQuery] ProductSpecParams productParams)
		{
			var spec = new ProductWithTypeAndBrandSpecifications(productParams);

			var products = await _productsRepo.GetAllWithSpecAsync(spec);

			var Data = _mapper.Map<IReadOnlyList<Product>, IReadOnlyList<ProductToReturnDto>>(products);

			var countSpec = new ProductWithFiltersForCountSpecification(productParams);

			var Count = await _productsRepo.GetCountAsync(countSpec);

			return Ok(new Pagination<ProductToReturnDto>(productParams.PageIndex, productParams.PageSize, Count, Data));
		}
		#endregion

		#region get by id

		[HttpGet("id")] // GET: /api/Products/id
		public async Task<ActionResult<ProductToReturnDto>> GetProduct(int id)
		{
			var spec = new ProductWithTypeAndBrandSpecifications(id);

			var product = await _productsRepo.GetByIdWithSpecAsync(spec);

			if (product == null) return NotFound(new ApiResponse(404));

			return Ok(_mapper.Map<Product, ProductToReturnDto>(product));
		}
		#endregion

		#region get by id

		[HttpGet("quantity")] // GET: /api/Products/id
		public async Task<IActionResult> GetProductquantity(int id)
		{

			var product = await _productsRepo.GetByIdAsync(id);

			return Ok(product.Quantity);
		}
		#endregion

		#region get brand

		[HttpGet("brands")]
		public async Task<ActionResult<IReadOnlyList<ProductBrand>>> GetBrands()
		{
			var brands = await _brandsRepo.GetAllAsync();
			return Ok(brands);
		}
		#endregion

		#region get type

		[HttpGet("types")]
		public async Task<ActionResult<IReadOnlyList<ProductType>>> GetTypes()
		{
			var types = await _typesRepo.GetAllAsync();
			return Ok(types);
		}
		#endregion
	}
}
