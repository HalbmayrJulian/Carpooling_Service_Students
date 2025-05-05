public class AlternativeFahrt : Fahrt
{
    public TransportTyp Typ { get; set; }
}

public enum TransportTyp
{
    Fahrrad,
    Moped,
    Fuß
}