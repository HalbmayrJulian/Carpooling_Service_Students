using System;
using System.Collections.Generic;

namespace Carpooling_Students.Model
{
    public class Bestellung
    {
        public int Id { get; set; }

        public DateTime Bestelldatum { get; set; } = DateTime.Now;

        public int UserId { get; set; }
        public Person User { get; set; }

        public List<Bestellposition> Artikel { get; set; } = new();
    }
}
