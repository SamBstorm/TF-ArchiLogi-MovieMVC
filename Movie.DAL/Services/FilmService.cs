using Movie.DAL.Mappers;
using Movie.DAL.Repositories;
using Movie.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Text;

namespace Movie.DAL.Services
{
	public class FilmService : IFilmRepository
	{
		private readonly DbConnection _connection;
		public FilmService(DbConnection connection) {
			_connection = connection;
		}

		int IFilmRepository.Create(Film film)
		{
			throw new NotImplementedException();
		}

		bool IFilmRepository.Delete(int id)
		{
			throw new NotImplementedException();
		}

		IEnumerable<Film> IFilmRepository.GetAll()
		{
			List<Film> films = new List<Film>();
			_connection.Open();

			using (DbCommand command = _connection.CreateCommand())
			{
				command.CommandText = "SELECT * FROM Film";

				using (DbDataReader reader = command.ExecuteReader())
				{
					while (reader.Read())
					{
						films.Add(reader.ToFilm());
					}
				}
			}

			_connection.Close();

			return films;
		}

		Film? IFilmRepository.GetOneById(int id)
		{
			Film? film = null;

			_connection.Open();

			using (DbCommand command = _connection.CreateCommand())
			{
				command.CommandText = "SELECT * FROM Film WHERE Id = @id";

				DbParameter dbParameter = command.CreateParameter();
				dbParameter.ParameterName = "id";
				dbParameter.Value = id;
				command.Parameters.Add(dbParameter);

				using (DbDataReader reader = command.ExecuteReader())
				{
					while (reader.Read())
					{
						film = reader.ToFilm();
					}
				}
			}

			_connection.Close();

			return film;
		}

		bool IFilmRepository.Update(int id, Film film)
		{
			throw new NotImplementedException();
		}
	}
}
