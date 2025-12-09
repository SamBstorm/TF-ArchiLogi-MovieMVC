namespace Movie.PL.ViewModels
{
	public class DisplayFilm
	{
		public int Id { get; set; }
		public string Titre { get; set; }
		public DateTime DateSortie { get; set; }

		public DisplayFilm(int id, string titre, DateTime dateSortie)
		{
			Id = id;
			Titre = titre;
			DateSortie = dateSortie;
		}
	}
}
