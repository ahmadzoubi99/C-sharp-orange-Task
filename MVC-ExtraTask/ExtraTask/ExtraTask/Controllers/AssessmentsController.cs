using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using ExtraTask.Context;
using ExtraTask.Models;

namespace ExtraTask.Controllers
{
    public class AssessmentsController : Controller
    {
        private readonly MyContext _context;

        public AssessmentsController(MyContext context)
        {
            _context = context;
        }

        // GET: Assessments
        // GET: Assessments
        public async Task<IActionResult> Index()
        {
            var myContext = _context.Assessments
                .Include(a => a.Student)
                .ThenInclude(s => s.Class)
                .Include(a => a.Teacher);
            return View(await myContext.ToListAsync());
        }

        [HttpPost]
        public async Task<IActionResult> SearchByName(string? name)
        {
            // Start with the base query
            var modelContext = _context.Assessments
                .Include(a => a.Student)
                .ThenInclude(s => s.Class)
                .Include(a => a.Teacher)
                .AsQueryable();

            // Add filter conditionally if 'name' is provided
            if (!string.IsNullOrEmpty(name))
            {
                modelContext = modelContext.Where(a => a.Student.FirstName.Contains(name));
            }

            return View("Index", await modelContext.ToListAsync());
        }

        // GET: Assessments/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var assessment = await _context.Assessments
                .Include(a => a.Student)
                .Include(a => a.Teacher)
                .FirstOrDefaultAsync(m => m.AssessmentID == id);
            if (assessment == null)
            {
                return NotFound();
            }

            return View(assessment);
        }

        // GET: Assessments/Create
        public IActionResult Create()
        {
            var students = _context.Students
        .Select(s => new
        {
            StudentID = s.StudentID,
            FullName = s.FirstName + " " + s.LastName
        })
        .ToList();

            ViewData["StudentID"] = new SelectList(students, "StudentID", "FullName");
            
            ViewData["TeacherID"] = new SelectList(_context.Teachers, "TeacherID", "TeacherID");
            return View();
        }

        // POST: Assessments/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("AssessmentID,StudentID,Commitment,AcademicPerformance,AbsentDays,Comments,TeacherID")] Assessment assessment)
        {
           
                _context.Add(assessment);
            int teacherID = (int)HttpContext.Session.GetInt32("TeacherID");
            assessment.TeacherID = teacherID;
            await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            ViewBag.TeacherID = HttpContext.Session.GetInt32("TeacherID");
            ViewData["StudentID"] = new SelectList(_context.Students, "StudentID", "StudentID", assessment.StudentID);
/*            ViewData["TeacherID"] = new SelectList(_context.Teachers, "TeacherID", "ViewBag.TeacherID", assessment.TeacherID);
*/            return View(assessment);
        }

        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var assessment = await _context.Assessments.FindAsync(id);
            if (assessment == null)
            {
                return NotFound();
            }

            var students = _context.Students
                .Select(s => new
                {
                    StudentID = s.StudentID,
                    FullName = s.FirstName + " " + s.LastName
                })
                .ToList();

            var teacher = _context.Teachers
                .Select(t => new
                {
                    TeacherID = t.TeacherID,
                    FullName = t.FullName
                })
                .ToList();

            if (students == null || !students.Any())
            {
                // Handle the case when there are no students
                return NotFound("No students found.");
            }

            if (teacher == null || !teacher.Any())
            {
                // Handle the case when there are no teachers
                return NotFound("No teachers found.");
            }

            ViewData["StudentID"] = new SelectList(students, "StudentID", "FullName", assessment.StudentID);
            ViewData["TeacherID"] = new SelectList(teacher, "TeacherID", "FullName", assessment.TeacherID);
            return View(assessment);
        }

        // POST: Assessments/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("AssessmentID,StudentID,Commitment,AcademicPerformance,AbsentDays,Comments,TeacherID")] Assessment assessment)
        {
            if (id != assessment.AssessmentID)
            {
                return NotFound();
            }

        
                try
                {
                    _context.Update(assessment);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!AssessmentExists(assessment.AssessmentID))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                
                return RedirectToAction(nameof(Index));
            }
            ViewData["StudentID"] = new SelectList(_context.Students, "StudentID", "StudentID", assessment.StudentID);
            ViewData["TeacherID"] = new SelectList(_context.Teachers, "TeacherID", "TeacherID", assessment.TeacherID);
            return View(assessment);
        }

        // GET: Assessments/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var assessment = await _context.Assessments
                .Include(a => a.Student)
                .Include(a => a.Teacher)
                .FirstOrDefaultAsync(m => m.AssessmentID == id);
            if (assessment == null)
            {
                return NotFound();
            }

            return View(assessment);
        }

        // POST: Assessments/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var assessment = await _context.Assessments.FindAsync(id);
            if (assessment != null)
            {
                _context.Assessments.Remove(assessment);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool AssessmentExists(int id)
        {
            return _context.Assessments.Any(e => e.AssessmentID == id);
        }
    }
}
