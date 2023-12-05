using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Filmoteka.Models;

namespace Filmoteka.Controllers
{
    public class FilmController : Controller

    {
        private readonly FilmContext _context;
        readonly IWebHostEnvironment _appEnvironment;

        public FilmController(FilmContext context, IWebHostEnvironment appEnvironment)
        {
            _context = context;
            _appEnvironment = appEnvironment;
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
        public async Task<IActionResult> Create([Bind("Id,Name,Director,Genre,Year,Poster,Description")] Film film, IFormFile uploadedFile)
        {
            if (film.Description == null || film.Description.Length < 10)
                ModelState.AddModelError("", "Описание фильма должно быть более 10 символов.");
            if (film.Director == null || !film.Director.Contains(" "))
                ModelState.AddModelError("", "В строке режиссер должна быть указано Имя и Фамилия");


            if (uploadedFile != null)
            {
                string path = "/image/" + uploadedFile.FileName;

                using (var fileStream = new FileStream(_appEnvironment.WebRootPath + path, FileMode.Create))
                {
                    await uploadedFile.CopyToAsync(fileStream); 
                }

                film.Poster =  '~'+path ;
                if (ModelState.IsValid)
                {
                    _context.Add(film);
                    await _context.SaveChangesAsync();
                    return RedirectToAction(nameof(Index));
                }

            }
            else ModelState.AddModelError("", "Необходимо добавить файл для Постера");

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
        public async Task<IActionResult> Edit(int id, [Bind("Id,Name,Director,Genre,Year,Poster,Description")] Film film, IFormFile uploadedFile)
        {
            if (id != film.Id)
            {
                return NotFound();
            }

            if (uploadedFile != null)
            {
                if (ModelState.IsValid)
                {
                
                try
                {
                    string path = "/image/" + uploadedFile.FileName; // имя файла

                    using (var fileStream = new FileStream(_appEnvironment.WebRootPath + path, FileMode.Create))
                    {
                        await uploadedFile.CopyToAsync(fileStream); // копируем файл в поток
                    }

                    film.Poster = '~' + path;
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
            }
            else ModelState.AddModelError("", "Необходимо добавить файл для Постера");

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
