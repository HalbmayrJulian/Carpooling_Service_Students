using Carpooling_Students.Model;
using Microsoft.AspNetCore.Mvc.RazorPages;

public class Profil_cs : PageModel
{
    private readonly CarpoolContext _context;
    public Person user { get; set; }
    public string Benutzername => user?.Name ?? "Unbekannter Nutzer";

    public Profil_cs(CarpoolContext context)
    {
        _context = context;
    }
    public void OnGet()
    {
        int? userId = HttpContext.Session.GetInt32("UserId");
        user = _context.Personen.FirstOrDefault(p => p.PersonId == userId);
    }
}
