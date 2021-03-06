﻿using System;
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
    public class CohortsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public CohortsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Cohorts
        public async Task<IActionResult> Index()
        {
            return View(await _context.Cohort.ToListAsync());
        }

        // GET: Cohorts/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Cohort cohort = await _context.Cohort
                .Include(c => c.Students)
                .Include(c => c.Instructors)
                .AsNoTracking()
                .FirstOrDefaultAsync(m => m.Id == id);
            if (cohort == null)
            {
                return NotFound();
            }

            return View(cohort);
        }

        // GET: Cohorts/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Cohorts/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Name")] Cohort cohort)
        {
            if (ModelState.IsValid)
            {
                _context.Add(cohort);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(cohort);
        }

        // GET: Cohorts/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var cohort = await _context.Cohort.FindAsync(id);
            if (cohort == null)
            {
                return NotFound();
            }
            return View(cohort);
        }

        // POST: Cohorts/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Name")] Cohort cohort)
        {
            if (id != cohort.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(cohort);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CohortExists(cohort.Id))
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
            return View(cohort);
        }

        // GET: Cohorts/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var cohort = await _context.Cohort
                .FirstOrDefaultAsync(m => m.Id == id);
            if (cohort == null)
            {
                return NotFound();
            }

            return View(cohort);
        }

        // POST: Cohorts/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var cohort = await _context.Cohort.FindAsync(id);
            _context.Cohort.Remove(cohort);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool CohortExists(int id)
        {
            return _context.Cohort.Any(e => e.Id == id);
        }

        //GET: Reports/
        public async Task<IActionResult> Reports(int selectedCohortId)
        {

            CohortReportViewModel reportModel = new CohortReportViewModel();


            SelectList Cohorts = new SelectList(_context.Cohort, "Id", "Name",reportModel.selectedCohortId);
            reportModel.Cohorts = Cohorts;

            //Generatea  report for The exercises that are in progress
            var exercisesInProgress = await _context.StudentExercise.Include(se => se.Student).Where(se => se.Student.CohortId == selectedCohortId).Include(se => se.Exercise)
            .GroupBy(se => new
            {
                se.Exercise.Name,
                se.Exercise.Language,
               
            })
            .Select(g => new CohortExerciseReport()
            {
                exercise = new Exercise()
                {
                    Name = g.Key.Name,
                    Language = g.Key.Language
                },
                StudentCount = g.Count()
            }).OrderByDescending(g => g.StudentCount).Take(3).ToListAsync();

            reportModel.TopThreeExercise = exercisesInProgress;
            //Generate a report for students that includes their name info and how many exercises they have completed
            var workingStudents = await _context.StudentExercise.Where(se => se.isComplete == true).Include(se => se.Student).Where(se => se.Student.CohortId == selectedCohortId).Include(se => se.Exercise)
            .GroupBy(se => new
            {
                se.Student.FirstName,
                se.Student.LastName,
                se.Student.SlackHandle,

            })
            .Select(g => new CohortStudentReport() {
                student = new Student() {
                    FirstName = g.Key.FirstName,
                    LastName = g.Key.LastName,
                    SlackHandle = g.Key.SlackHandle },
                ExerciseCount = g.Count() }).ToListAsync();

            var busyStudents = workingStudents.OrderByDescending(g => g.ExerciseCount).Take(3).ToList();
            var lazyStudents = workingStudents.OrderBy(g => g.ExerciseCount).Take(3).ToList();
            
            reportModel.BusyStudents = busyStudents;
            reportModel.LazyStudents = lazyStudents;
                       
            return View(reportModel);
        }
    }
}
