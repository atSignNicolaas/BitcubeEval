using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Trainingfacility_Bitcube.Models;

namespace Trainingfacility_Bitcube.Controllers
{
    public class CoursesController : Controller
    {
        private readonly MvcDataContext _context;

        public CoursesController(MvcDataContext context)
        {
            _context = context;
        }

        // GET: Courses
        public async Task<IActionResult> Index()
        {
            var mvcDataContext = _context.Courses.Include(c => c.Degree);
            return View(await mvcDataContext.ToListAsync());
        }

        // GET: Courses/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            List<Courses> coursesModel = _context.Courses.ToList();
            string courseNames = "";
            if (id == null)
            {
                return NotFound();
            }

            var courses = await _context.Courses
                .Include(c => c.Degree)
                .FirstOrDefaultAsync(m => m.CoursesId == id);
            if (courses == null)
            {
                return NotFound();
            }
            //var relatedCourses = from x in coursesModel where (x.DegreeId == courses.DegreeId) select x;
            foreach (var y in coursesModel){
                if (y.DegreeId == courses.DegreeId & y.CoursesId != courses.CoursesId)
                {
                    if (!y.Equals(coursesModel.Last()))
                    {
                        courseNames += y.Name + ", ";
                    }
                    else 
                    {
                        courseNames += y.Name;
                    }
                }
                
            }
            ViewData["relatedcourses"] = courseNames;
            return View(courses);
        }

        // GET: Courses/Create
        public IActionResult Create()
        {
            ViewData["Name"] = new SelectList(_context.Degree, "DegreeId", "Name");
            return View();
        }

        // POST: Courses/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("CoursesId,Name,Duration,RelatedCourses,DegreeId")] Courses courses)
        {
            if (ModelState.IsValid)
            {
                _context.Add(courses);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["DegreeId"] = new SelectList(_context.Degree, "DegreeId", "DegreeId", courses.DegreeId);
            return View(courses);
        }

        // GET: Courses/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var courses = await _context.Courses.FindAsync(id);
            if (courses == null)
            {
                return NotFound();
            }
            ViewData["Name"] = new SelectList(_context.Degree, "DegreeId", "Name", courses.DegreeId);
            return View(courses);
        }

        // POST: Courses/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("CoursesId,Name,Duration,RelatedCourses,DegreeId")] Courses courses)
        {
            if (id != courses.CoursesId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(courses);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CoursesExists(courses.CoursesId))
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
            ViewData["DegreeId"] = new SelectList(_context.Degree, "DegreeId", "DegreeId", courses.DegreeId);
            return View(courses);
        }

        // GET: Courses/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var courses = await _context.Courses
                .Include(c => c.Degree)
                .FirstOrDefaultAsync(m => m.CoursesId == id);
            if (courses == null)
            {
                return NotFound();
            }

            return View(courses);
        }

        // POST: Courses/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var courses = await _context.Courses.FindAsync(id);
            _context.Courses.Remove(courses);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool CoursesExists(int id)
        {
            return _context.Courses.Any(e => e.CoursesId == id);
        }
    }
}
