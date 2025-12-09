using Movie.BLL.Repositories;
using idal=Movie.DAL.Repositories;
using Movie.Domain.Entities;


namespace Movie.BLL.Services
{
	public class FilmService : IFilmRepository
	{
		private readonly idal.IFilmRepository _filmRepository;
		public FilmService(idal.IFilmRepository filmRepository) {
			_filmRepository = filmRepository;
		}
		int IFilmRepository.Create(Film film)
		{
			throw new NotImplementedException();
		}

		bool IFilmRepository.Delete(int id)
		{
			throw new NotImplementedException();
		}

		bool IFilmRepository.Exist(int id)
		{
			throw new NotImplementedException();
		}

		IEnumerable<Film> IFilmRepository.GetAll()
		{
			return _filmRepository.GetAll();
		}

		Film IFilmRepository.GetOneById(int id)
		{
			Film? film = _filmRepository.GetOneById(id);
			if (film is not null)
			{
				return film;
			}
			else
			{
				// TODO créer une excepion personnalisé
				throw new NotImplementedException();
			}
		}

		bool IFilmRepository.Update(Film film)
		{
			throw new NotImplementedException();
		}
	}
}
