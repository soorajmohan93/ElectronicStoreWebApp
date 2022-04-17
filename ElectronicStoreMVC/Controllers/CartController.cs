using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using ElectronicStoreModels.Models;
using ElectronicStoreMVC.Models;
using Microsoft.AspNetCore.Authorization;
using ElectronicStoreModels;

namespace ElectronicStoreMVC.Controllers
{
    public class CartController : Controller
    {
        private readonly ElectronicStoreContext _context;

        public CartController(ElectronicStoreContext context)
        {
            _context = context;
        }



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
        public async Task<IActionResult> Create([Bind("CartId,Product,Customer")] Cart cart)
        {
            if (ModelState.IsValid)
            {
                _context.Add(cart);

                Product product = cart.Products;
                product.ProductStock = Calculations.RemainingQuantity(1,2);



                await _context.SaveChangesAsync();
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

            var cart = await _context.Cart.FindAsync(id);
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
        public async Task<IActionResult> Edit(int id, [Bind("CartId,Product,Customer")] Cart cart)
        {
            if (id != cart.CartId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(cart);
                    await _context.SaveChangesAsync();
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
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var cart = await _context.Cart.FindAsync(id);
            _context.Cart.Remove(cart);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool CartExists(int id)
        {
            return _context.Cart.Any(e => e.CartId == id);
        }
    }
}
