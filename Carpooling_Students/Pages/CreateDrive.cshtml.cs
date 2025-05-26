using Carpooling_Students.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

public class FahrtErstellenModel : PageModel
{
    private readonly CarpoolContext _context;

    public FahrtErstellenModel(CarpoolContext context)
    {
        _context = context;
        Start = string.Empty; 
        Ziel = string.Empty; 
    }

    [BindProperty] public string Start { get; set; } = string.Empty;
    [BindProperty] public string Ziel { get; set; } = string.Empty;  
    [BindProperty] public DateTime Zeit { get; set; }
    [BindProperty] public int Plaetze { get; set; }
    [BindProperty] public TransportTyp Typ { get; set; } = TransportTyp.Auto; // Standardwert

    public void OnGet() { }

    public IActionResult OnPost()
    {
        int? userId = HttpContext.Session.GetInt32("UserId");
        var Route = new Routen
        {
            StartOrt = Start,
            ZielOrt = Ziel,
            Distanz = 0, // Sollte berechnet werden, z.B. mit Google Maps API
            Weg = "" // Platzhalter für Routenbeschreibung
        };

        var Fahrt = new Fahrt
        {
            Typ = Typ,
            StartDatum = Zeit,
            EndDatum = Zeit.AddHours(10),
            Abgeschlossen = false,
            Fahrer = _context.Personen.FirstOrDefault(p => p.PersonId == userId),
            Route = Route,
            Sitze = Plaetze
        };

        _context.Routen.Add(Route);
        _context.Fahrten.Add(Fahrt);

        _context.SaveChanges();

        return RedirectToPage("/UserPage"); // Oder Erfolgsnachricht
    }
}
