using Microsoft.AspNetCore.Mvc;
using Movie.BLL.Repositories;
using Movie.PL.Mappers;
using Movie.PL.Models;
using Movie.PL.ViewModels;

namespace Movie.PL.Controllers
{
	public class FilmController : Controller
	{
		private readonly IFilmRepository _filmRepository;
		public FilmController(IFilmRepository filmRepository) { 
			_filmRepository = filmRepository;
		}

		public IActionResult Index()
		{

			// IEnumerable<DisplayFilm> films = _filmRepository.GetAll().Select(
			//	film => new DisplayFilm(film.Id, film.Titre, film.DateSortie)
			// );
			IEnumerable<DisplayFilm> films = _filmRepository.GetAll().Select(film => film.ToDisplay());
			return View(films);
		}

		public IActionResult Details(int id)
		{
			DisplayFilm film = _filmRepository.GetOneById(id).ToDisplay();
			return View(film);
		}

		public IActionResult Create()
		{
			return View();
		}

		[HttpPost]
		public IActionResult Create(FilmCreateForm form)
		{
			try
			{
				if (!ModelState.IsValid) throw new ArgumentException(nameof(form));
				int id = _filmRepository.Create(form.ToBLL());
				return RedirectToAction(nameof(Details), "Film", new { id });
			}
			catch (Exception)
			{
				return View();
			}
		}

		/* Méthode propre au controlleur qui n'a pas le comportement d'une action
		[NonAction]
		private string AfficheMonNom() {
			return "Samuel";
		}
		*/
	}
}
