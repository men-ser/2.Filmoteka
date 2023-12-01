using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Filmoteka.Models;

namespace Filmoteka.Controllers
{
    public class FilmController : Controller

    {
        private readonly FilmContext _context;

        public FilmController(FilmContext context)
        {
            _context = context;
        }

        // GET: FilmController
        public async Task<IActionResult> Index()
        {
            return _context.Films != null ?
                        View(await _context.Films.ToListAsync()) :
                        Problem("Entity set 'FilmContext.Films'  is null.");
        }


        // GET: FilmController/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Films == null)
            {
                return NotFound();
            }

            var film = await _context.Films.FirstOrDefaultAsync(f => f.Id == id);
            if (film == null)
            {
                return NotFound();
            }

            return View(film);
        }

        // GET: FilmController/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: FilmController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Name,Director,Genre,Year,Poster,Description")] Film film)
        {
            if (ModelState.IsValid)
            {
                _context.Add(film);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View();

        }
        
        // GET: FilmController/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Films == null)
            {
                return NotFound();
            }

            var film = await _context.Films.FindAsync(id);
            if (film == null)
            {
                return NotFound();
            }
            return View(film);
        }

        // POST: FilmController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Name,Director,Genre,Year,Poster,Description")] Film film)
        {
            if (id != film.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(film);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (_context.Films.Any(e => e.Id == film.Id))
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
            return View(film);
        }

        // GET: FilmController/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var film = await _context.Films.SingleOrDefaultAsync(m => m.Id == id);
            if (film == null)
            {
                return NotFound();
            }

            return View(film);
        }

        // POST: FilmController/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var film = await _context.Films.SingleOrDefaultAsync(m => m.Id == id);
            _context.Films.Remove(film);
            await _context.SaveChangesAsync();
            return RedirectToAction("Index");
        }    }
}
