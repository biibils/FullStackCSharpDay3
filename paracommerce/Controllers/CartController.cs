using Microsoft.AspNetCore.Mvc;
using paracommerce.Models;
using paracommerce.Services;

namespace paracommerce.Controllers;

public class CartController : Controller
{
    private readonly IProductService _productService;
    private readonly ICartService _cartService;

    public CartController(IProductService productService, ICartService cartService)
    {
        _productService = productService;
        _cartService = cartService;
    }

    // POST: Cart/Add
    [HttpPost]
    [ValidateAntiForgeryToken]
    public IActionResult AddToCart(int productId)
    {
        var product = _productService.GetProductById(productId);
        if (product == null)
        {
            return NotFound();
        }
        _cartService.AddToCart(product);
        return RedirectToAction("Index", "Market");
    }

    public IActionResult Increase(int productId)
    {
        _cartService.Increase(productId);
        return RedirectToAction("Index", "Market");
    }

    public IActionResult Decrease(int productId)
    {
        _cartService.Decrease(productId);
        return RedirectToAction("Index", "Market");
    }

    // GET: Cart/
    public IActionResult Index()
    {
        var cart = _cartService.GetCart();
        return View(cart);
    }

    public IActionResult Checkout()
    {
        var success = _cartService.Checkout();

        if (!success)
        {
            TempData["Error"] = "Stok tidak mencukupi.";
            return RedirectToAction("Index");
        }

        TempData["Success"] = "Checkout Berhasil";
        return RedirectToAction("CheckoutSuccess");
    }

    // GET: Cart/CheckoutSuccess
    public IActionResult CheckoutSuccess()
    {
        return View();
    }
}
