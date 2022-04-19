using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using ElectronicStoreModels.Models;
using ElectronicStoreMVC.Models;
using ElectronicStoreModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace ElectronicStoreMVC.Controllers
{
    public class CartController : Controller
    {
        private readonly ElectronicStoreContext _context;

        public CartController(ElectronicStoreContext context)
        {
            _context = context;
        }

        // GET: Cart
        public IActionResult Index(int? Customer)
        {

            ViewData["Customer"] = new SelectList(_context.Customer, "CustomerId", "CustomerName");

            var carts = from c in _context.Cart.Include(c => c.Customers).Include(c => c.Products)
                        select c;

            if (Customer != null)
            {
                carts = carts.Where(x => x.Customer == Customer);
            }
            CartViewModel cartView = new CartViewModel() { Carts = carts };
            return View(cartView);

        }

        // GET: Cart/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var cart = await _context.Cart
                .Include(c => c.Customers)
                .Include(c => c.Products)
                .FirstOrDefaultAsync(m => m.CartId == id);
            if (cart == null)
            {
                return NotFound();
            }

            return View(cart);
        }

        // GET: Cart/Create
        public IActionResult Create()
        {
            ViewData["Customer"] = new SelectList(_context.Customer, "CustomerId", "CustomerName");
            ViewData["Product"] = new SelectList(_context.Product, "ProductId", "ProductName");
            return View();
        }

        // POST: Cart/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize]
        public async Task<IActionResult> Create([Bind("CartId,Product,Customer,CartQuantity")] Cart cart)
        {
            if (ModelState.IsValid)
            {
                var query = from p in _context.Product
                            where p.ProductId == cart.Product
                            select p;
                Product product = query.FirstOrDefault<Product>();
                try
                {
                    int stock = product.ProductStock;
                    product.ProductStock = Calculations.RemainingQuantity(product.ProductStock, cart.CartQuantity);
                    if (product.ProductStock >= 0)
                    {
                        _context.Add(cart);
                        _context.Update(product);
                        await _context.SaveChangesAsync();
                    }
                    else
                    {
                        //If cart quantity is greater than stock quantity then cart item should not be created
                        //Code refered from https://stackoverflow.com/questions/43561214/display-error-message-on-the-view-from-controller-asp-net-mvc-5
                        ModelState.AddModelError(nameof(cart.CartQuantity), $"Cart Quantity should not be greater than quantity in stock: {stock}");
                        ViewData["Customer"] = new SelectList(_context.Customer, "CustomerId", "CustomerName", cart.Customer);
                        ViewData["Product"] = new SelectList(_context.Product, "ProductId", "ProductName", cart.Product);
                        return View(cart);
                    }
                    
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ProductExists(product.ProductId))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            ViewData["Customer"] = new SelectList(_context.Customer, "CustomerId", "CustomerName", cart.Customer);
            ViewData["Product"] = new SelectList(_context.Product, "ProductId", "ProductName", cart.Product);
            return View(cart);
        }

        // GET: Cart/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var cart = await _context.Cart.Include(c => c.Customers).Include(c => c.Products).FirstOrDefaultAsync(m => m.CartId == id);
            if (cart == null)
            {
                return NotFound();
            }
            ViewData["Customer"] = new SelectList(_context.Customer, "CustomerId", "CustomerName", cart.Customer);
            ViewData["Product"] = new SelectList(_context.Product, "ProductId", "ProductName", cart.Product);
            return View(cart);
        }

        // POST: Cart/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize]
        public async Task<IActionResult> Edit(int id, [Bind("CartId,Product,Customer,CartQuantity")] Cart cart)
        {
            if (id != cart.CartId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    var queryCart = from c in _context.Cart.AsNoTracking()
                                where c.CartId == cart.CartId
                                select c;
                    Cart oldCart = queryCart.FirstOrDefault<Cart>();
                    
                    var queryProduct = from p in _context.Product
                                where p.ProductId == cart.Product
                                select p;
                    Product product = queryProduct.FirstOrDefault<Product>();
                    try
                    {
                        int stock = product.ProductStock + oldCart.CartQuantity;
                        product.ProductStock = Calculations.RemainingQuantity(product.ProductStock, cart.CartQuantity - oldCart.CartQuantity);
                        if (product.ProductStock >= 0)
                        {
                            _context.Update(cart);
                            _context.Update(product);
                            await _context.SaveChangesAsync();
                        }
                        else
                        {
                            //If cart quantity is greater than stock quantity then cart item should not be updated
                            //Code refered from https://stackoverflow.com/questions/43561214/display-error-message-on-the-view-from-controller-asp-net-mvc-5
                            ModelState.AddModelError(nameof(cart.CartQuantity), $"Cart Quantity should not be greater than quantity in stock: {stock}");
                            ViewData["Customer"] = new SelectList(_context.Customer, "CustomerId", "CustomerName", cart.Customer);
                            ViewData["Product"] = new SelectList(_context.Product, "ProductId", "ProductName", cart.Product);
                            return View(cart);
                        }
                    }
                    catch (DbUpdateConcurrencyException)
                    {
                        if (!ProductExists(product.ProductId))
                        {
                            return NotFound();
                        }
                        else
                        {
                            throw;
                        }
                    }
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CartExists(cart.CartId))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            ViewData["Customer"] = new SelectList(_context.Customer, "CustomerId", "CustomerName", cart.Customer);
            ViewData["Product"] = new SelectList(_context.Product, "ProductId", "ProductName", cart.Product);
            return View(cart);
        }

        // GET: Cart/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var cart = await _context.Cart
                .Include(c => c.Customers)
                .Include(c => c.Products)
                .FirstOrDefaultAsync(m => m.CartId == id);
            if (cart == null)
            {
                return NotFound();
            }

            return View(cart);
        }

        // POST: Cart/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        [Authorize]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var cart = await _context.Cart.FindAsync(id);
            _context.Cart.Remove(cart);
            var query = from p in _context.Product
                        where p.ProductId == cart.Product
                        select p;
            Product product = query.FirstOrDefault<Product>();
            try
            {
                product.ProductStock = Calculations.RemainingQuantity(product.ProductStock, cart.CartQuantity*-1);
                _context.Update(product);
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ProductExists(product.ProductId))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }
            return RedirectToAction(nameof(Index));
        }

        private bool CartExists(int id)
        {
            return _context.Cart.Any(e => e.CartId == id);
        }

        private bool ProductExists(int id)
        {
            return _context.Product.Any(e => e.ProductId == id);
        }
    }
}
