using Microsoft.AspNetCore.Mvc;
using movies.Models.DTO;
using movies.Repositories.Abstract;

namespace movies.Controllers
{
    public class GenreController : Controller
    {
        private readonly IGenreService _genreService;
        public GenreController(IGenreService genreService)
        {
            _genreService = genreService;
        }
        public IActionResult Add()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Add(Genre model)
        {
            if (!ModelState.IsValid)
                return View(model);
            var result = _genreService.Add(model);
            if (result)
            {
                TempData["msg"] = "Successfully added!";
                return RedirectToAction(nameof(Add));
            }
            else
            {
                TempData["msg"] = "Could not save...";
                return View();
            }
            
        }

        public IActionResult Edit(int id)
        {
            var model = _genreService.GetById(id);
            return View(model);
        }
        [HttpPost]
        public IActionResult Edit(Genre model)
        {
            if (!ModelState.IsValid)
                return View(model);
            var result = _genreService.Update(model);
            if (result)
            {
                TempData["msg"] = "Successfully updated!";
                return RedirectToAction(nameof(GenreList));
            }
            else
            {
                TempData["msg"] = "Could not save...";
                return View();
            }

        }
        public IActionResult GenreList()
        {
            var data = _genreService.GetAll().ToList();
            return View(data);
        }

        public IActionResult Delete(int id)
        {
            _genreService.Delete(id);
            return View();
        }
    }
}
