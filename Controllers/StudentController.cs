using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Trainingfacility_Bitcube.Models;

namespace Trainingfacility_Bitcube.Controllers
{
    public class StudentController : Controller
    {
        private readonly MvcDataContext _context;

        public StudentController(MvcDataContext context)
        {
            _context = context;
        }

        // GET: Data
        //if lecturer is logged in show his/her related students only
        public async Task<IActionResult> Index(int? id)
        {
             if (id != null){
                var mvcDataContext = _context.Student.Include(d => d.Degree).Where(d => d.Degree.Lecturer.LecturerId == id);
                return View(await mvcDataContext.ToListAsync());
            }
            else{
                var mvcDataContext = _context.Student.Include(d => d.Degree);
                return View(await mvcDataContext.ToListAsync());
            }
        }

        // GET: Data/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var student = await _context.Student
                .Include(s => s.Degree)
                .FirstOrDefaultAsync(m => m.StudentId == id);
            if (student == null)
            {
                return NotFound();
            }

            return View(student);
        }

        // GET: Data/Create
        public IActionResult Create()
        {
            ViewData["Name"] = new SelectList(_context.Set<Degree>(), "DegreeId", "Name");
            return View();
        }

        // POST: Data/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("StudentId,Forename,Surname,Dateofbirth,Email,DegreeId")] Student student)
        {
            if (ModelState.IsValid)
            {
                //create firstname and surname based on forename or forename and surname
                int space = student.Forename.IndexOf(" ");
                student.Firstname = student.Forename.Substring(0, space);
                student.Fullname = student.Forename + " " + student.Surname;
                _context.Add(student);
                await _context.SaveChangesAsync();
                return RedirectToAction("Dashboard", "Lecturer", new {id = HttpContext.Session.GetInt32("UserId")});
            }
            ViewData["DegreeId"] = new SelectList(_context.Set<Degree>(), "DegreeId", "DegreeId", student.DegreeId);
            return View(student);
        }

        // GET: Data/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var student = await _context.Student.FindAsync(id);
            if (student == null)
            {
                return NotFound();
            }
            ViewData["Name"] = new SelectList(_context.Set<Degree>(), "DegreeId", "Name", student.DegreeId);
            return View(student);
        }

        // POST: Data/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("StudentId,Forename,Surname,Dateofbirth,Email,Firstname,Fullname,DegreeId")] Student student)
        {
            if (id != student.StudentId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(student);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!StudentExists(student.StudentId))
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
            ViewData["DegreeId"] = new SelectList(_context.Set<Degree>(), "DegreeId", "DegreeId", student.DegreeId);
            return View(student);
        }

        // GET: Data/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var student = await _context.Student
                .Include(s => s.Degree)
                .FirstOrDefaultAsync(m => m.StudentId == id);
            if (student == null)
            {
                return NotFound();
            }

            return View(student);
        }

        // POST: Data/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var student = await _context.Student.FindAsync(id);
            _context.Student.Remove(student);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool StudentExists(int id)
        {
            return _context.Student.Any(e => e.StudentId == id);
        }
    }
}
