using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Students_Announcement.Models
{
    public class Announcement
    {
        public int id { get; set; }

        [Display(Name = "Uczelnia")]
        [RegularExpression(@"^[A-Z]*$")]
        [Required(ErrorMessage = "Proszę wpisać nazwę uczelni w postaci np. UG.")]
        public string uczelnia { get; set; }

        [Display(Name = "Wydział")]
        [Required(ErrorMessage = "Proszę wpisać nazwę wydziału w postaci np. WZR")]
        public string wydzial { get; set; }

        [Display(Name = "Autor")]
        [Required(ErrorMessage = "Proszę podac imię, nazwisko lub nick")]
        public string autor { get; set; }

        [Display(Name = "Tytuł")]
        [Required(ErrorMessage = "Proszę podać tytuł")]
        public string tytul { get; set; }

        [Display(Name = "Kategornia")]
        [Required(ErrorMessage = "Proszę wybrać kategorię")]
        public string kategoria { get; set; }

        [Display(Name = "Ogłoszenie")]
        [StringLength(200, MinimumLength = 3)]
        [Required(ErrorMessage = "Proszę wpisać ogłoszenie")]
        public string opis { get; set; }
    }
}
