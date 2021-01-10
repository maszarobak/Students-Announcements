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

        [RegularExpression(@"^[A-Za-z0-9]*$", ErrorMessage = "Proszę wpisać uczelnie.")]
        public string uczelnia { get; set; }
        [RegularExpression(@"^[A-Za-z0-9]*$", ErrorMessage = "Proszę wpisać wydział")]
        public string wydzial { get; set; }
        [RegularExpression(@"^[A-Za-z0-9]*$", ErrorMessage = "Proszę podac imię, nazwisko lub nick")]
        public string autor { get; set; }
        [RegularExpression(@"^[A-Za-z0-9]*$", ErrorMessage = "Proszę podać tytuł")]
        public string tytul { get; set; }
        [RegularExpression(@"^[A-Za-z0-9]*$", ErrorMessage = "Proszę wybrać kategorię")]
        public string kategoria { get; set; }
        [RegularExpression(@"^[A-Za-z0-9]*$", ErrorMessage = "Proszę wpisać ogłoszenie")]
        public string opis { get; set; }
    }
}
