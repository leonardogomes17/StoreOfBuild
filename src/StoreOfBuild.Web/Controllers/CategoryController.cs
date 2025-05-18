using System.Diagnostics;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using StoreOfBuild.Data;
using StoreOfBuild.Domain;
using StoreOfBuild.Domain.Dtos;
using StoreOfBuild.Domain.Products;
using StoreOfBuild.Web.Models;

namespace StoreOfBuild.Web.Controllers;

[Authorize(Roles = "Admin, Manager")]
public class CategoryController : Controller
{
    private readonly ILogger<HomeController> _logger;
    private readonly CategoryStorer _categoryStorer;
    private readonly IRepository<Category> _categoryRepository;

    public CategoryController(ILogger<HomeController> logger, CategoryStorer categoryStorer, IRepository<Category> categoryRepository)
    {
        _logger = logger;
        _categoryStorer = categoryStorer;
        _categoryRepository = categoryRepository;
    }

    public IActionResult Index()
    {
        var categories = _categoryRepository.GetAll().AsEnumerable();
        var dtoCategory = categories.Select(c => new CategoryDto() { Id = c.Id, Name = c.Name });
        return View(dtoCategory);
    }

    public IActionResult CreateOrEdit(int id)
    {
        if (id > 0)
        {
            var category = _categoryRepository.GetByID(id);

            if (category == null)
                return View();

            var categoryDto = new CategoryDto { Id = category.Id, Name = category.Name };
            return View(categoryDto);
        }
        else
            return View();
    }

    public IActionResult Delete(int id)
    {
        _categoryStorer.Delete(id);
        return RedirectToAction("Index");
    }

    [HttpPost]
    public IActionResult CreateOrEdit(CategoryDto dto)
    {
        _categoryStorer.Store(dto);
        return RedirectToAction("Index");
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}
