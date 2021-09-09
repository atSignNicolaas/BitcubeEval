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
    public class LecturerController : Controller
    {
        private readonly MvcDataContext _context;

        public LecturerController(MvcDataContext context)
        {
            _context = context;
        }

        // GET: Lecturer
        public async Task<IActionResult> Index()
        {
            return View(await _context.Lecturer.ToListAsync());
        }

        // GET: Lecturer/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var lecturer = await _context.Lecturer
                .FirstOrDefaultAsync(m => m.LecturerId == id);
            if (lecturer == null)
            {
                return NotFound();
            }

            return View(lecturer);
        }

        // GET: Lecturer/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Lecturer/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("LecturerId,Forename,Surname,Email,Dateofbirth")] Lecturer lecturer)
        {
            if (ModelState.IsValid)
            {
                //create firstname and forename based on forename or forename and surname
                int space = lecturer.Forename.IndexOf(" ");
                lecturer.Firstname = lecturer.Forename.Substring(0, space);
                lecturer.Fullname = lecturer.Forename + " " + lecturer.Surname;
                _context.Add(lecturer);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(lecturer);
        }

        // GET: Lecturer/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var lecturer = await _context.Lecturer.FindAsync(id);
            if (lecturer == null)
            {
                return NotFound();
            }
            return View(lecturer);
        }

        // POST: Lecturer/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("LecturerId,Forename,Surname,Email,Dateofbirth,Firstname,Fullname")] Lecturer lecturer)
        {
            if (id != lecturer.LecturerId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(lecturer);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!LecturerExists(lecturer.LecturerId))
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
            return View(lecturer);
        }

        // GET: Lecturer/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var lecturer = await _context.Lecturer
                .FirstOrDefaultAsync(m => m.LecturerId == id);
            if (lecturer == null)
            {
                return NotFound();
            }

            return View(lecturer);
        }

        // POST: Lecturer/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var lecturer = await _context.Lecturer.FindAsync(id);
            _context.Lecturer.Remove(lecturer);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool LecturerExists(int id)
        {
            return _context.Lecturer.Any(e => e.LecturerId == id);
        }

        public IActionResult Login()
        {
            return View();
        }

        //login page reads lecturers unique id to display related students and degrees
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Login([Bind("LecturerId")]Lecturer lecturer)
        {
            if (ModelState.IsValid)
            {
                var dataobject = await _context.Lecturer.FirstOrDefaultAsync(m => m.LecturerId == lecturer.LecturerId);
                if (dataobject != null)
                {
                    HttpContext.Session.SetInt32("UserId", dataobject.LecturerId);
                    HttpContext.Session.SetString("Username", dataobject.Firstname.ToString());
                    return RedirectToAction("Dashboard", new {id = dataobject.LecturerId});
                }
            }
            return View(lecturer);
        }

        //after successful login show lecturer firstname and allow him to manage his/her students and degrees
         public IActionResult Dashboard(int? id)
        {
            //Set model properties equal to existing data for accessebility 
            ViewModel mymodel = new ViewModel();
            mymodel.Student = GetStudent(id);
            mymodel.Degree = GetDegree(id);

            if (HttpContext.Session.GetString("UserId") != null)
            {
                var lecturer = _context.Lecturer
                .FirstOrDefault(m => m.LecturerId == id);
                return View(mymodel);
            }
            else
            {
                return RedirectToAction("Login");
            }
        }

        //Retrieve data from database and return list
        public List<Student> GetStudent(int? id){
            if (id != null){
                List<Student> mvcDataContext = _context.Student.Include(d => d.Degree).Where(d => d.Degree.Lecturer.LecturerId == id).ToList();
                return mvcDataContext;
            }
            else{
                List<Student> mvcDataContext = _context.Student.Include(d => d.Degree).ToList();
                return mvcDataContext;
            }
        }

        //Retrieve data from database
        public List<Degree> GetDegree(int? id){
            if (id != null){
                List<Degree> mvcDataContext = _context.Degree.Include(d => d.Lecturer).Where(d => d.Lecturer.LecturerId == id).ToList();
                return mvcDataContext;
            }
            else{
                List<Degree> mvcDataContext = _context.Degree.Include(d => d.Lecturer).ToList();
                return mvcDataContext;
            }
        }
    }
}
