using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Movie.PL.Models
{
    public class FilmCreateForm
    {
        [DisplayName("Titre du film : ")]
        [Required(ErrorMessage = "Veuillez remplir le champs Titre.")]
        [MaxLength(100, ErrorMessage = "Le Titre doit contenir au maximum 100 caractères.")]
        [MinLength(1,ErrorMessage = "Au minimum, 1 caractère est requis.")]
        public string Titre { get; set; }
        [DisplayName("Date de sortie : ")]
        [Required(ErrorMessage = "Veuillez remplir le champs Date de sortie.")]
        [DataType("datetime-locale")]
        public DateTime DateSortie { get; set; }
    }
}
