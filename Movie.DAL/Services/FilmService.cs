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
            using (DbCommand command = _connection.CreateCommand())
            {
				command.CommandText = $"INSERT INTO [Film]([Titre], [DateSortie]) OUTPUT [inserted].[Id] VALUES (@{nameof(film.Titre)}, @{nameof(film.DateSortie)})";

				DbParameter param_titre = command.CreateParameter();
				param_titre.ParameterName = nameof(film.Titre);
				param_titre.Value = film.Titre;

                DbParameter param_date = command.CreateParameter();
                param_date.ParameterName = nameof(film.DateSortie);
                param_date.Value = film.DateSortie;

				command.Parameters.Add(param_titre);
				command.Parameters.Add(param_date);

				_connection.Open();

				film.Id = (int?)command.ExecuteScalar() ?? throw new InvalidOperationException();

				_connection.Close();
            }
			return film.Id;
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
