using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using TASK1.Context;
using TASK1.Models;

namespace MVC_Task1.Controllers
{
    public class UsersController : Controller
    {
        private readonly MyContext _context;

        public UsersController(MyContext context)
        {
            _context = context;
        }

        // GET: Users
        public async Task<IActionResult> Index()
        {
            var myContext = _context.Users.Include(u => u.Employee);

            return View(await myContext.ToListAsync());
        }

        // GET: Users/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var users = await _context.Users
                .Include(u => u.Employee)
                .FirstOrDefaultAsync(m => m.UserID == id);
            if (users == null)
            {
                return NotFound();
            }

            return View(users);
        }

        // GET: Users/Create
        public IActionResult Create()
        {
            ViewData["EmployeeID"] = new SelectList(_context.Employees, "EmployeeId", "EmployeeId");
/*            RedirectToAction("Manger","Employees");
*/            return View("Manger");
        }

        // POST: Users/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("UserID,Username,Password,Role,EmployeeID")] Users users)
        {
            
                _context.Add(users);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            
            ViewData["EmployeeID"] = new SelectList(_context.Employees, "EmployeeId", "EmployeeId", users.EmployeeID);
            return View(users);
        }

        // GET: Users/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var users = await _context.Users.FindAsync(id);
            if (users == null)
            {
                return NotFound();
            }
            ViewData["EmployeeID"] = new SelectList(_context.Employees, "EmployeeId", "EmployeeId", users.EmployeeID);
            return View(users);
        }

        // POST: Users/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("UserID,Username,Password,Role,EmployeeID")] Users users)
        {
            if (id != users.UserID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(users);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!UsersExists(users.UserID))
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
            ViewData["EmployeeID"] = new SelectList(_context.Employees, "EmployeeId", "EmployeeId", users.EmployeeID);
            return View(users);
        }

        // GET: Users/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var users = await _context.Users
                .Include(u => u.Employee)
                .FirstOrDefaultAsync(m => m.UserID == id);
            if (users == null)
            {
                return NotFound();
            }

            return View(users);
        }

        // POST: Users/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var users = await _context.Users.FindAsync(id);
            if (users != null)
            {
                _context.Users.Remove(users);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool UsersExists(int id)
        {
            return _context.Users.Any(e => e.UserID == id);
        }

        [HttpPost]
        public IActionResult Login([Bind("Username,Password")] Users userLogin)
        {
            var auth = _context.Users.Where(x => x.Username == userLogin.Username && x.Password == userLogin.Password).FirstOrDefault();

            if (auth != null)
            {
                var emp = _context.Users.Include(x => x.Employee).Where(x => x.Employee.EmployeeId == auth.EmployeeID).FirstOrDefault();
                switch (auth.Role)
                {
                    case "Manger":

                        HttpContext.Session.SetString("userID", userLogin.Username);
                        HttpContext.Session.SetString("employeeName", emp.Employee.Name);
                        HttpContext.Session.SetString("Role", emp.Role);

                        ViewBag.name = emp.Employee.Name;
                        TempData["name"] = emp.Employee.Name;

                        return RedirectToAction("Index", "Employee");

                    case "Employee":

                        HttpContext.Session.SetString("userID", userLogin.Username);
                        return RedirectToAction("HomeEmployee", "Employee");
                }
            }
            return RedirectToAction(nameof(Index));


        }

    }
}
