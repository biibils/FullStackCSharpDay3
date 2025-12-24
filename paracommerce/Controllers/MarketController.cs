using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using paracommerce.Models;
using paracommerce.Services;

namespace paracommerce.Controllers;

public class MarketController : Controller
{
    private readonly IProductService _productService;

    public MarketController(IProductService productService)
    {
        _productService = productService;
    }

    public IActionResult Index()
    {
        var products = _productService.GetAllProducts();

        if (!products.Any())
        {
            ViewBag.Message = "Belum ada produk yang dapat ditampilkan.";
        }
        return View(products);
    }
}
