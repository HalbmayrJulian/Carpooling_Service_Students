using Carpooling_Students.Model;

public abstract class Fahrt
{
    public int FahrtId { get; set; }
    public DateTime StartDatum { get; set; }
    public DateTime EndDatum { get; set; }
    public bool Abgeschlossen { get; set; }

    public Person Fahrer { get; set; }
    public Routen Route { get; set; }
}