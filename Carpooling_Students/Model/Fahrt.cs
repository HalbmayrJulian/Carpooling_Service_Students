using Carpooling_Students.Model;

public class Fahrt
{
    public int FahrtId { get; set; }
    public DateTime StartDatum { get; set; }
    public DateTime EndDatum { get; set; }
    public bool Abgeschlossen { get; set; }

    public Person Fahrer { get; set; }
    public Routen Route { get; set; }
    public int Sitze { get; set; }
    public List<Person> Passagiere { get; set; }
    public TransportTyp Typ { get; set; }
}
public enum TransportTyp
{
    Fahrrad,
    Auto,
    Moped,
    Fuß
}
