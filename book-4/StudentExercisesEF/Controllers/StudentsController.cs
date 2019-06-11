using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using StudentExercisesEF.Data;
using StudentExercisesEF.Models;
using StudentExercisesEF.Models.ViewModels;

namespace StudentExercisesEF.Controllers
{
    public class StudentsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public StudentsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Students
        public async Task<IActionResult> Index(string searchString)
        {
            ViewData["CurrentFilter"] = searchString;

            IQueryable<Student> applicationDbContext = _context.Student.Include(s => s.Cohort);

            if (!String.IsNullOrEmpty(searchString))
            {
                applicationDbContext = applicationDbContext.Where(s => s.FirstName.Contains(searchString)
                                       || s.LastName.Contains(searchString));
            }

            return View(await applicationDbContext.ToListAsync());
        }

        // GET: Students/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var student = await _context.Student
                .Include(s => s.Cohort)
                .Include(s=>s.StudentExercises)
                .ThenInclude(se=>se.Exercise)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (student == null)
            {
                return NotFound();
            }

            return View(student);
        }

        // GET: Students/Create
        public IActionResult Create()
        {
            StudentCreateViewModel studentViewModel = new StudentCreateViewModel();
            SelectList Cohorts = new SelectList(_context.Cohort, "Id", "Name");
            studentViewModel.Cohorts = Cohorts;

            return View(studentViewModel);
        }

        // POST: Students/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(StudentCreateViewModel studentViewModel)
        {
            if (ModelState.IsValid)
            {
                _context.Add(studentViewModel.student);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            SelectList Cohorts = new SelectList(_context.Cohort, "Id", "Name", studentViewModel.student.CohortId);
            studentViewModel.Cohorts = Cohorts;

            return View(studentViewModel);
        }

        // GET: Students/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            StudentEditViewModel studentViewModel = new StudentEditViewModel();

            if (id == null)
            {
                return NotFound();
            }

            var student = await _context.Student.FindAsync(id);
            studentViewModel.student = student;

            if (student == null)
            {
                return NotFound();
            }

            //Create a select list for the cohorts
            SelectList Cohorts = new SelectList(_context.Cohort, "Id", "Name", studentViewModel.student.CohortId);
            studentViewModel.Cohorts = Cohorts;

            //Create a select list for the exercises
            SelectList Exercises = new SelectList(_context.Exercise, "Id", "Name", studentViewModel.ExerciseIds);
            studentViewModel.Exercises = Exercises;

            // Get the list of exercise the student is already working on to show pre-selected
            List<int> exerciseIds = _context.StudentExercise.Where(se => se.StudentId == id).Select(se => se.ExerciseId).ToList();
            studentViewModel.ExerciseIds = exerciseIds;



            return View(studentViewModel);

        }

        // POST: Students/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, StudentEditViewModel studentViewModel)
        {
            List<int> currentNotPrev = new List<int>();
            List<int> prevNotCurrent = new List<int>();

            List<int> PrevExerciseIds = _context.StudentExercise.Where(se => se.StudentId == id).Select(se => se.ExerciseId).ToList();

            currentNotPrev = studentViewModel.ExerciseIds.Except(PrevExerciseIds).ToList();
            prevNotCurrent = PrevExerciseIds.Except(studentViewModel.ExerciseIds).ToList();

            if (id != studentViewModel.student.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(studentViewModel.student);


                    if (currentNotPrev.Count() > 0)
                    {
                        foreach (int exerciseId in currentNotPrev)
                        {
                            StudentExercise studentExercise = new StudentExercise()
                            {
                                StudentId = id,
                                ExerciseId = exerciseId
                            };
                            _context.Add(studentExercise);

                        }
                    }

                    if (prevNotCurrent.Count() > 0) { 
                        foreach (int exerciseId in prevNotCurrent)
                    {
                        var studentExercise =  _context.StudentExercise.FirstOrDefault(se => se.StudentId == id && se.ExerciseId == exerciseId);
                        _context.Remove(studentExercise);

                    }
                    }


                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!StudentExists(studentViewModel.student.Id))
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
            //Create a select list for the cohorts
            SelectList Cohorts = new SelectList(_context.Cohort, "Id", "Name", studentViewModel.student.CohortId);
            studentViewModel.Cohorts = Cohorts;

            //Create a select list for the exercises
            SelectList Exercises = new SelectList(_context.Exercise, "Id", "Name", studentViewModel.ExerciseIds);
            studentViewModel.Exercises = Exercises;

            // Get the list of exercise the student is already working on to show pre-selected
            List<int> exerciseIds = _context.StudentExercise.Select(se => se.ExerciseId).ToList();
            studentViewModel.ExerciseIds = exerciseIds;

            return View(studentViewModel.student);
        }

        // GET: Students/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var student = await _context.Student
                .Include(s => s.Cohort)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (student == null)
            {
                return NotFound();
            }

            return View(student);
        }

        // POST: Students/Delete/5
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
            return _context.Student.Any(e => e.Id == id);
        }

        // PATCH /Students/CompleteExercise
        [HttpPatch]

        public async Task<IActionResult> PatchExercise([FromBody] StudentExercise studentExercise)
        {
            try
            {            
            _context.StudentExercise.Update(studentExercise);
                await _context.SaveChangesAsync();

                return RedirectToAction("Index");

            }
            catch (Exception e)
            {
                if (!StudentExerciseExists(studentExercise.Id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }


        }

        private bool StudentExerciseExists(int id)
        {
            return _context.StudentExercise.Any(se => se.Id == id);
        }
    }
}
