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
    public class CategoriesController : Controller
    {
        private readonly MyContext _context;
        private readonly IWebHostEnvironment webHostEnvironment;

        public CategoriesController(MyContext context, IWebHostEnvironment webHostEnvironment)
        {
            _context = context;
            this.webHostEnvironment = webHostEnvironment;
        }

        // GET: Categories
        public async Task<IActionResult> Index()
        {
            return View(await _context.Category.ToListAsync());
        }

        // GET: Categories/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var categories = await _context.Category
                .FirstOrDefaultAsync(m => m.CategoryID == id);
            if (categories == null)
            {
                return NotFound();
            }

            return View(categories);
        }

        // GET: Categories/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Categories/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("CategoryID,CategoryName,CategoryImage,ImageFile")] Categories categories)
        {
            if (categories.ImageFile != null)
            {
                string wwwRootPath = webHostEnvironment.WebRootPath;

                string fileName = Guid.NewGuid().ToString() + categories.ImageFile.FileName;

                string path = Path.Combine(wwwRootPath + "/Image/" + fileName);

                using (var fileStream = new FileStream(path, FileMode.Create))
                {
                    await categories.ImageFile.CopyToAsync(fileStream);
                }

                categories.CategoryImage = fileName;
            }


            _context.Add(categories);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));

            return View(categories);
        }

        // GET: Categories/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var categories = await _context.Category.FindAsync(id);
            if (categories == null)
            {
                return NotFound();
            }
            return View(categories);
        }
        public IActionResult CategoryDetails(int id)
        {
            var category = new Categories { CategoryID = id, CategoryName = $"Category {id}", CategoryImage = $"category{id}.jpg" };
            return View(category);
        }
        // POST: Categories/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("CategoryID,CategoryName,CategoryImage")] Categories categories)
        {
            if (id != categories.CategoryID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(categories);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CategoriesExists(categories.CategoryID))
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
            return View(categories);
        }

        // GET: Categories/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var categories = await _context.Category
                .FirstOrDefaultAsync(m => m.CategoryID == id);
            if (categories == null)
            {
                return NotFound();
            }

            return View(categories);
        }

        // POST: Categories/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var categories = await _context.Category.FindAsync(id);
            if (categories != null)
            {
                _context.Category.Remove(categories);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }


        private bool CategoriesExists(int id)
        {
            return _context.Category.Any(e => e.CategoryID == id);
        }

        [HttpPost]
        public async Task<IActionResult> SearchByName(string? name)
        {
            // Start with the base query
            var modelContext = _context.Category.AsQueryable();

            // Add filter conditionally if 'name' is provided
            if (!string.IsNullOrEmpty(name))
            {
                modelContext = modelContext.Where(c => c.CategoryName.Contains(name));
            }

            return View("Index", await modelContext.ToListAsync());
        }
    }
}
