using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Core_Azure_Host.Data;
using Core_Azure_Host.Models;

namespace Core_Azure_Host.Controllers
{
    public class EmployeeDetailsController : Controller
    {
        private readonly AzureDbContext _context;

        public EmployeeDetailsController(AzureDbContext context)
        {
            _context = context;
        }

        // GET: EmployeeDetails
        public async Task<IActionResult> Index()
        {
            return View(await _context.EmployeeDetail.ToListAsync());
        }

        // GET: EmployeeDetails/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var employeeDetail = await _context.EmployeeDetail
                .FirstOrDefaultAsync(m => m.Id == id);
            if (employeeDetail == null)
            {
                return NotFound();
            }

            return View(employeeDetail);
        }

        // GET: EmployeeDetails/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: EmployeeDetails/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Name,EmailAddress")] EmployeeDetail employeeDetail)
        {
            if (ModelState.IsValid)
            {
                _context.Add(employeeDetail);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(employeeDetail);
        }

        // GET: EmployeeDetails/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var employeeDetail = await _context.EmployeeDetail.FindAsync(id);
            if (employeeDetail == null)
            {
                return NotFound();
            }
            return View(employeeDetail);
        }

        // POST: EmployeeDetails/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Name,EmailAddress")] EmployeeDetail employeeDetail)
        {
            if (id != employeeDetail.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(employeeDetail);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!EmployeeDetailExists(employeeDetail.Id))
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
            return View(employeeDetail);
        }

        // GET: EmployeeDetails/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var employeeDetail = await _context.EmployeeDetail
                .FirstOrDefaultAsync(m => m.Id == id);
            if (employeeDetail == null)
            {
                return NotFound();
            }

            return View(employeeDetail);
        }

        // POST: EmployeeDetails/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var employeeDetail = await _context.EmployeeDetail.FindAsync(id);
            _context.EmployeeDetail.Remove(employeeDetail);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool EmployeeDetailExists(int id)
        {
            return _context.EmployeeDetail.Any(e => e.Id == id);
        }
    }
}
