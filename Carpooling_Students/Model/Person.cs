using System.Data.Entity.Core.Metadata.Edm;

namespace Carpooling_Students.Model
{
    public class Person
    {
        public int PersonId { get; set; }
        public string Name { get; set; }
        public string Adresse { get; set; }
        public string Password { get; set; }
        public string Email { get; set; }
        public int GesamtDistanz { get; set; }
        public int Coins { get; set; }

        public List<Fahrt> Fahrten { get; set; }
        public List<AutofahrtPassagier> Mitfahrten { get; set; }
    }
}
