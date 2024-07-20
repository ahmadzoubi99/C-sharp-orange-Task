using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Task2_MVC.Context;
using Task2_MVC.Models;

namespace Task2_MVC.Controllers
{
    public class ProductsController : Controller
    {
        private readonly MyContext _context;
        private readonly IWebHostEnvironment webHostEnvironment;
        public ProductsController(MyContext context,IWebHostEnvironment webHostEnvironment)
        {
            _context = context;
            this.webHostEnvironment = webHostEnvironment;
        }

        // GET: Products
        public async Task<IActionResult> Index()
        {
            var myContext = _context.product.Include(p => p.Category);
            return View(await myContext.ToListAsync());
        }

        // GET: Products/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var product = await _context.product
                .Include(p => p.Category)
                .FirstOrDefaultAsync(m => m.ProductID == id);
            if (product == null)
            {
                return NotFound();
            }

            return View(product);
        }

        // GET: Products/Create
        public IActionResult Create()
        {
            ViewData["ProductCategoryID"] = new SelectList(_context.Category, "CategoryID", "CategoryName");
            return View();
        }

        // POST: Products/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ProductID,ProductName,ProductPrice,ProductImage,ProductDescription,ProductCategoryID,ImageFile")] Product product)
        {
            if (product.ImageFile != null)
            {

                var wwwRootPath = webHostEnvironment.WebRootPath;
                string fileName = Guid.NewGuid().ToString() + product.ImageFile.FileName;
                string path = Path.Combine(wwwRootPath +"/Image/"+ fileName);
                using (var fileStream = new FileStream(path, FileMode.Create))
                {
                    await product.ImageFile.CopyToAsync(fileStream);
                }
                product.ProductImage = fileName;
            }

            _context.Add(product);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            
            ViewData["ProductCategoryID"] = new SelectList(_context.Category, "CategoryID", "CategoryName", product.ProductCategoryID);
            return View(product);
        }

        // GET: Products/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var product = await _context.product.FindAsync(id);
            if (product == null)
            {
                return NotFound();
            }
            ViewData["ProductCategoryID"] = new SelectList(_context.Category, "CategoryID", "CategoryName", product.ProductCategoryID);
            return View(product);
        }

        // POST: Products/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ProductID,ProductName,ProductPrice,ProductImage,ProductDescription,ProductCategoryID")] Product product)
        {
            if (id != product.ProductID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(product);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ProductExists(product.ProductID))
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
            ViewData["ProductCategoryID"] = new SelectList(_context.Category, "CategoryID", "CategoryName", product.ProductCategoryID);
            return View(product);
        }

        // GET: Products/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var product = await _context.product
                .Include(p => p.Category)
                .FirstOrDefaultAsync(m => m.ProductID == id);
            if (product == null)
            {
                return NotFound();
            }

            return View(product);
        }

        // POST: Products/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var product = await _context.product.FindAsync(id);
            if (product != null)
            {
                _context.product.Remove(product);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }


        private bool ProductExists(int id)
        {
            return _context.product.Any(e => e.ProductID == id);
        }

        public async Task<IActionResult> CategoryProducts(int id)
        {
            var products = _context.product.Where(x
          => x.ProductCategoryID == id).ToList();
            return View(products);

        }
        public async Task<IActionResult> SearchByName(string? name)
        {
            // Start with the base query
            var modelContext = _context.product.AsQueryable();

            // Add filter conditionally if 'name' is provided
            if (!string.IsNullOrEmpty(name))
            {
                modelContext = modelContext.Where(c => c.ProductName.Contains(name));
            }

            return View("Index", await modelContext.ToListAsync());
        }
    }

}

