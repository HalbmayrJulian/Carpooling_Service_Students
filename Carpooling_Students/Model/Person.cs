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

        // Navigationseigenschaft: Fahrten, die die Person fährt
        public List<Fahrt> GefahreneFahrten { get; set; } = new();

        // Navigationseigenschaft: Fahrten, an denen die Person teilnimmt (als Passagier)
        public List<FahrtPassagier> Mitfahrten { get; set; } = new();
    }
}
