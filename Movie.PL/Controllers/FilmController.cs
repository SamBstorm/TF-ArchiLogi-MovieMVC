using Microsoft.AspNetCore.Mvc;
using Movie.BLL.Repositories;
using Movie.PL.Mappers;
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
	}
}
