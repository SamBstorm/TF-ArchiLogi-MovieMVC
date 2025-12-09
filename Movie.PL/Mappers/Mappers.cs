using Movie.Domain.Entities;
using Movie.PL.Models;
using Movie.PL.ViewModels;

namespace Movie.PL.Mappers
{
	public static class Mappers
	{
		public static DisplayFilm ToDisplay(this Film film)
		{
			return new DisplayFilm(film.Id, film.Titre, film.DateSortie);
		}

		public static Film ToBLL(this FilmCreateForm form)
		{
			return new Film() { 
				Titre = form.Titre,
				DateSortie = form.DateSortie
			};
		}
	}
}
