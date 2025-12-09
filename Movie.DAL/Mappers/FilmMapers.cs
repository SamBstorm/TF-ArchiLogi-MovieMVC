using Movie.Domain.Entities;
using System.Data;

namespace Movie.DAL.Mappers
{
	public static class FilmMapers
	{
		public static Film ToFilm(this IDataRecord record)
		{
			return new Film
			{
				Id = (int)record["Id"],
				Titre = (string)record["Titre"],
				DateSortie = (DateTime)record["DateSortie"]
			};
		}
	}
}
