using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using StoreOfBuild.Domain;
using StoreOfBuild.Domain.Dtos;
using StoreOfBuild.Domain.Products;


namespace StoreOfBuild.Web.Controllers
{
    [Authorize]
    public class ProductController : Controller
    {
        private readonly ILogger<ProductController> _logger;

        private readonly ProductStorer _productStorer;

        private readonly IRepository<Product> _productRepository;

        private readonly IRepository<Category> _categoryRepository;

        public ProductController(ILogger<ProductController> logger, ProductStorer productStorer, IRepository<Product> productRepository, IRepository<Category> categoryRepository)
        {
            _logger = logger;
            _productStorer = productStorer;
            _productRepository = productRepository;
            _categoryRepository = categoryRepository;
        }

        public IActionResult ListProducts()
        {
            var products = _productRepository.GetAll().Include(x => x.Category);
            var dtoProducts = products.Select(c => new ProductDto() { Id = c.Id, Name = c.Name, Categoryid = c.Category.Id, Price = c.Price, StockQuantity = c.StockQuantity });
            return View(dtoProducts);

        }

        public IActionResult CreateOrEdit(int id)
        {
            var categories = _categoryRepository.GetAll().AsEnumerable();
            var productDto = new ProductDto();
            productDto.ListCategories = categories.Select(x => new CategoryDto { Id = x.Id, Name = x.Name });

            if (id > 0)
            {
                var product = _productRepository.GetByID(id, nameof(Product.Category));

                if (product == null)
                    return View();

                productDto.Id = product.Id;
                productDto.Name = product.Name;
                productDto.Categoryid = product.Category.Id;
                productDto.Price = product.Price;
                productDto.StockQuantity = product.StockQuantity;

                return View(productDto);
            }
            else
                return View(productDto);
        }

        public IActionResult Delete(int id)
        {
            _productStorer.Delete(id);
            return RedirectToAction("ListProducts");
        }

        [HttpPost]
        public IActionResult CreateOrEdit(ProductDto dto)
        {
            _productStorer.Store(dto);
            return RedirectToAction("ListProducts");
        }
    }
}