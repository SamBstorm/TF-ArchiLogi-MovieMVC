using Movie.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Movie.DAL.Repositories
{
	public interface IFilmRepository
	{
		// crud
		// Create
		int Create(Film film);

		// Read
		IEnumerable<Film> GetAll();
		Film? GetOneById(int id);

		// Update
		bool Update(int id, Film film);

		// Delete
		bool Delete(int id);
	}
}
