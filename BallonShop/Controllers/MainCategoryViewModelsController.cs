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
    public class MainCategoryViewModelsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public MainCategoryViewModelsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: MainCategoryViewModels
        public async Task<IActionResult> Index()
        {
            return View(await _context.MainCategoryViewModel.ToListAsync());
        }

        // GET: MainCategoryViewModels/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var mainCategoryViewModel = await _context.MainCategoryViewModel
                .SingleOrDefaultAsync(m => m.MainCategoryViewModelId == id);
            if (mainCategoryViewModel == null)
            {
                return NotFound();
            }

            return View(mainCategoryViewModel);
        }

        // GET: MainCategoryViewModels/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: MainCategoryViewModels/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("MainCategoryViewModelId,MainCategoryName")] MainCategoryViewModel mainCategoryViewModel)
        {
            if (ModelState.IsValid)
            {
                _context.Add(mainCategoryViewModel);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(mainCategoryViewModel);
        }

        // GET: MainCategoryViewModels/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var mainCategoryViewModel = await _context.MainCategoryViewModel.SingleOrDefaultAsync(m => m.MainCategoryViewModelId == id);
            if (mainCategoryViewModel == null)
            {
                return NotFound();
            }
            return View(mainCategoryViewModel);
        }

        // POST: MainCategoryViewModels/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("MainCategoryViewModelId,MainCategoryName")] MainCategoryViewModel mainCategoryViewModel)
        {
            if (id != mainCategoryViewModel.MainCategoryViewModelId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(mainCategoryViewModel);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!MainCategoryViewModelExists(mainCategoryViewModel.MainCategoryViewModelId))
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
            return View(mainCategoryViewModel);
        }

        // GET: MainCategoryViewModels/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var mainCategoryViewModel = await _context.MainCategoryViewModel
                .SingleOrDefaultAsync(m => m.MainCategoryViewModelId == id);
            if (mainCategoryViewModel == null)
            {
                return NotFound();
            }

            return View(mainCategoryViewModel);
        }

        // POST: MainCategoryViewModels/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var mainCategoryViewModel = await _context.MainCategoryViewModel.SingleOrDefaultAsync(m => m.MainCategoryViewModelId == id);
            _context.MainCategoryViewModel.Remove(mainCategoryViewModel);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool MainCategoryViewModelExists(int id)
        {
            return _context.MainCategoryViewModel.Any(e => e.MainCategoryViewModelId == id);
        }
    }
}
