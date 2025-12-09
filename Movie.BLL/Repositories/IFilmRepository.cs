using Movie.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Movie.BLL.Repositories
{
	public interface IFilmRepository
	{
		int Create(Film film);
		IEnumerable<Film> GetAll();
		Film GetOneById(int id);
		bool Exist(int id);
		bool Update(Film film);
		bool Delete(int id);
	}
}
