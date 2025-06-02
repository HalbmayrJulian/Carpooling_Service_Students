namespace Carpooling_Students.Model
{
    public class Bestellposition
    {
        public int Id { get; set; }

        public int BestellungId { get; set; }
        public Bestellung Bestellung { get; set; }

        public int ItemId { get; set; }
        public Item Item { get; set; }
    }
}
