using Carpooling_Students.Model;

public class AutofahrtPassagier
{
    public int AutofahrtPassagierId { get; set; }
    public Fahrt Fahrt { get; set; }
    public Autofahrt Autofahrt { get; set; }
    public Person Passagier { get; set; }
}