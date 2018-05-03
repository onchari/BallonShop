using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using BallonShop.Data;
using BallonShop.Models.ProductViewModel;

namespace BallonShop.Controllers
{
    public class SubCategoryViewModelsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public SubCategoryViewModelsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: SubCategoryViewModels
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.SubCategoryViewModel.Include(s => s.MainCategoryViewModel);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: SubCategoryViewModels/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var subCategoryViewModel = await _context.SubCategoryViewModel
                .Include(s => s.MainCategoryViewModel)
                .SingleOrDefaultAsync(m => m.SubCategoryViewModelId == id);
            if (subCategoryViewModel == null)
            {
                return NotFound();
            }

            return View(subCategoryViewModel);
        }

        // GET: SubCategoryViewModels/Create
        public IActionResult Create()
        {
            ViewData["MainCategoryViewModelId"] = new SelectList(_context.MainCategoryViewModel, "MainCategoryViewModelId", "MainCategoryName");
            return View();
        }

        // POST: SubCategoryViewModels/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("SubCategoryViewModelId,Name,MainCategoryViewModelId")] SubCategoryViewModel subCategoryViewModel)
        {
            if (ModelState.IsValid)
            {
                _context.Add(subCategoryViewModel);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["MainCategoryViewModelId"] = new SelectList(_context.MainCategoryViewModel, "MainCategoryViewModelId", "MainCategoryViewModelId", subCategoryViewModel.MainCategoryViewModelId);
            return View(subCategoryViewModel);
        }

        // GET: SubCategoryViewModels/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var subCategoryViewModel = await _context.SubCategoryViewModel.SingleOrDefaultAsync(m => m.SubCategoryViewModelId == id);
            if (subCategoryViewModel == null)
            {
                return NotFound();
            }
            ViewData["MainCategoryViewModelId"] = new SelectList(_context.MainCategoryViewModel, "MainCategoryViewModelId", "MainCategoryViewModelId", subCategoryViewModel.MainCategoryViewModelId);
            return View(subCategoryViewModel);
        }

        // POST: SubCategoryViewModels/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("SubCategoryViewModelId,Name,MainCategoryViewModelId")] SubCategoryViewModel subCategoryViewModel)
        {
            if (id != subCategoryViewModel.SubCategoryViewModelId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(subCategoryViewModel);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!SubCategoryViewModelExists(subCategoryViewModel.SubCategoryViewModelId))
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
            ViewData["MainCategoryViewModelId"] = new SelectList(_context.MainCategoryViewModel, "MainCategoryViewModelId", "MainCategoryViewModelId", subCategoryViewModel.MainCategoryViewModelId);
            return View(subCategoryViewModel);
        }

        // GET: SubCategoryViewModels/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var subCategoryViewModel = await _context.SubCategoryViewModel
                .Include(s => s.MainCategoryViewModel)
                .SingleOrDefaultAsync(m => m.SubCategoryViewModelId == id);
            if (subCategoryViewModel == null)
            {
                return NotFound();
            }

            return View(subCategoryViewModel);
        }

        // POST: SubCategoryViewModels/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var subCategoryViewModel = await _context.SubCategoryViewModel.SingleOrDefaultAsync(m => m.SubCategoryViewModelId == id);
            _context.SubCategoryViewModel.Remove(subCategoryViewModel);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool SubCategoryViewModelExists(int id)
        {
            return _context.SubCategoryViewModel.Any(e => e.SubCategoryViewModelId == id);
        }
    }
}
