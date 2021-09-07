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
    public class DegreeController : Controller
    {
        private readonly MvcDataContext _context;

        public DegreeController(MvcDataContext context)
        {
            _context = context;
        }

        // GET: Degree
        public async Task<IActionResult> Index()
        {
            var mvcDataContext = _context.Degree.Include(d => d.Lecturer);
            return View(await mvcDataContext.ToListAsync());
        }

        // GET: Degree/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            List<Courses> coursesModel = _context.Courses.ToList();
            string courseNames = "";
            if (id == null)
            {
                return NotFound();
            }

            var degree = await _context.Degree
                .Include(d => d.Lecturer)
                .FirstOrDefaultAsync(m => m.DegreeId == id);
            if (degree == null)
            {
                return NotFound();
            }
            foreach (var y in coursesModel){
                if (y.DegreeId == degree.DegreeId)
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
            return View(degree);
        }

        // GET: Degree/Create
        public IActionResult Create()
        {
            ViewData["Fullname"] = new SelectList(_context.Set<Lecturer>(), "LecturerId", "Fullname");
            return View();
        }

        // POST: Degree/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("DegreeId,Name,Duration,LecturerId")] Degree degree)
        {
            if (ModelState.IsValid)
            {
                _context.Add(degree);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["LecturerId"] = new SelectList(_context.Set<Lecturer>(), "LecturerId", "LecturerId", degree.LecturerId);
            return View(degree);
        }

        // GET: Degree/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var degree = await _context.Degree.FindAsync(id);
            if (degree == null)
            {
                return NotFound();
            }
            ViewData["Fullname"] = new SelectList(_context.Set<Lecturer>(), "LecturerId", "Fullname", degree.LecturerId);
            return View(degree);
        }

        // POST: Degree/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("DegreeId,Name,Duration,LecturerId")] Degree degree)
        {
            if (id != degree.DegreeId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(degree);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!DegreeExists(degree.DegreeId))
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
            ViewData["LecturerId"] = new SelectList(_context.Set<Lecturer>(), "LecturerId", "LecturerId", degree.LecturerId);
            return View(degree);
        }

        // GET: Degree/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var degree = await _context.Degree
                .Include(d => d.Lecturer)
                .FirstOrDefaultAsync(m => m.DegreeId == id);
            if (degree == null)
            {
                return NotFound();
            }

            return View(degree);
        }

        // POST: Degree/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var degree = await _context.Degree.FindAsync(id);
            _context.Degree.Remove(degree);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool DegreeExists(int id)
        {
            return _context.Degree.Any(e => e.DegreeId == id);
        }
    }
}
