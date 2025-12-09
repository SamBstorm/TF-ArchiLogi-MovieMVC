using System;
using System.Collections.Generic;
using System.Text;

namespace Movie.Domain.Entities
{
	public class Film
	{
		public int Id { get; set; }

		public string Titre { get; set; }

		public DateTime DateSortie { get; set; }

		public Film() { }
		public Film(int id, string titre, DateTime dateSortie) : this (titre, dateSortie)
		{
			Id = id;
		}

        public Film(string titre, DateTime dateSortie)
        {
            Titre = titre;
            DateSortie = dateSortie;
        }
    }
}
