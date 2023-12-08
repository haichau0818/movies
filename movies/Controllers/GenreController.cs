using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using movies.Models.Domain;
using movies.Repositories.Abstract;

namespace movies.Controllers
{
    //[Authorize(Roles = "admin")]
    public class GenreController : Controller
    {
        private readonly IGenreService _genreService;
        public GenreController(IGenreService genreService)
        {
            _genreService = genreService;
        }

        [Route("/genre/add")]
        public IActionResult Add()
        {
            return View();
        }

        [HttpPost]
        [Route("/genre/add")]
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

        [Route("/genre/edit")]
        public IActionResult Edit(int id)
        {
            var model = _genreService.GetById(id);
            return View(model);
        }

        [HttpPost]
        [Route("/genre/edit")]
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

        [Route("/genre/all")]
        public IActionResult GenreList()
        {
            var data = _genreService.GetAll().ToList();
            return View(data);
        }

        [Route("/genre/delete")]
        public IActionResult Delete(int id)
        {
            _genreService.Delete(id);
            return RedirectToAction("GenreList","Genre");
        }
    }
}
