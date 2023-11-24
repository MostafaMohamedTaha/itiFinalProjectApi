using AdminDashboard.Helpers;
using AdminDashboard.Models;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;
using Talabat.APIs.Dtos;
using Talabat.APIs.Helpers;
using Talabat.Core.Entities;
using Talabat.Core.Repositories;
using Talabat.Core.Specifications.Products;

namespace AdminDashboard.Controllers
{
    //[Authorize]
    public class ProductController : Controller
    {
        private readonly IGenericRepository<Product> _productsRepo;
        private readonly IGenericRepository<ProductType> _typesRepo;
        private readonly IGenericRepository<ProductBrand> _brandsRepo;
        private readonly IUnitOfWork unitOfWork;
        private readonly IMapper mapper;

        public ProductController(IUnitOfWork unitOfWork,IMapper mapper,
            IGenericRepository<Product> productsRepo,
            IGenericRepository<ProductBrand> brandsRepo,
            IGenericRepository<ProductType> typesRepo)
        {
            this.unitOfWork = unitOfWork;
            this.mapper = mapper;
            _productsRepo = productsRepo;
            _typesRepo = typesRepo;
            _brandsRepo = brandsRepo;
        }

        [HttpGet]
        public async Task<ActionResult<Pagination<ProductViewModel>>> Index([FromQuery] ProductSpecParams productParams)
        {
            var spec = new ProductWithTypeAndBrandSpecifications(productParams);

            var products = await _productsRepo.GetAllWithSpecAsync(spec);

            var Data = mapper.Map<IReadOnlyList<Product>, IReadOnlyList<ProductViewModel>>(products);

            var countSpec = new ProductWithFiltersForCountSpecification(productParams);

            var Count = await _productsRepo.GetCountAsync(countSpec);

            ViewBag.Brands = await _brandsRepo.GetAllAsync();

            ViewBag.Types = await _typesRepo.GetAllAsync();

            // To Remain The Value Of Search Field In The View After The Request

            ViewBag.SearchValue = productParams.Search;

			return View(new Pagination<ProductViewModel>(productParams.PageIndex, productParams.PageSize, Count, Data));
        }
       
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult>Create(ProductViewModel model)
        {
            if(ModelState.IsValid)
            {
                if (model.Image != null)
                    model.PictureUrl = PictureSettings.UploadFile(model.Image, "products");
                else
                    model.PictureUrl = "images/products/hat-react2.png";

                var mappedProduct = mapper.Map<ProductViewModel,Product>(model);
                await unitOfWork.Repository<Product>().AddAsync(mappedProduct);
                await unitOfWork.Complete();
                return RedirectToAction("Index");
            }
            return View(model);
        }

        public async Task<IActionResult> Edit(int id)
        {
            var product = await unitOfWork.Repository<Product>().GetByIdAsync(id);
            var mappedProduct = mapper.Map<Product,ProductViewModel>(product);
            return View(mappedProduct);
        }
        [HttpPost]
        public async Task<IActionResult> Edit(int id,ProductViewModel model)
        {
            if (id != model.Id)
                return NotFound();
            if(ModelState.IsValid)
            {
                if(model.Image != null)
                {
                    if(model.PictureUrl != null)
                    {
                        PictureSettings.DeleteFile(model.PictureUrl, "products");
                        model.PictureUrl = PictureSettings.UploadFile(model.Image, "products"); 
                    }
                    else
                    {
                        model.PictureUrl = PictureSettings.UploadFile(model.Image, "products");

                    }
                    
                }
                var mappedProduct = mapper.Map<ProductViewModel, Product>(model);
                unitOfWork.Repository<Product>().Update(mappedProduct);
                var result = await unitOfWork.Complete();
                if (result > 0)
                    return RedirectToAction("Index");
            }
            return View(model);
        }

        public async Task<IActionResult>Delete(int id)
        {
            var product = await unitOfWork.Repository<Product>().GetByIdAsync(id);
            var mappedProduct =mapper.Map<Product,ProductViewModel>(product);
            return View(mappedProduct);
        }
        [HttpPost]
        public async Task<IActionResult> Delete(int id,ProductViewModel model)
        {
            if(id !=model.Id)
                return NotFound();
            try
            {
                var product = await unitOfWork.Repository<Product>().GetByIdAsync(id);
                if (product.PictureUrl != null)
                    PictureSettings.DeleteFile(product.PictureUrl, "products");

                unitOfWork.Repository<Product>().Delete(product);
                await unitOfWork.Complete();
                return RedirectToAction("Index");

            }
            catch (System.Exception)
            {

                return View(model);
            }
        }
    }
}
