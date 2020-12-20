using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Students_Announcement.Models
{
    public class Announcement
    {
        public int id { get; set; }
        public string uczelnia { get; set; }
        public string wydzial { get; set; }
        public string autor { get; set; }
        public string tytul { get; set; }
        public string kategoria { get; set; }
        public string opis { get; set; }
    }
}
