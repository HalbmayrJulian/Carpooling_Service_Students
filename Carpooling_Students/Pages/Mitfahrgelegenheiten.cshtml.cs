using Carpooling_Students.Model;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Http;
using System.Collections.Generic;

public class Mitfahrgelegenheiten_cs : PageModel
{
    private readonly CarpoolContext _context;

    public Mitfahrgelegenheiten_cs(CarpoolContext context)
    {
        _context = context;
    }

    public List<Fahrt> Autofahrten { get; set; } = new();

    public void OnGet()
    {
        int? userId = HttpContext.Session.GetInt32("UserId");
        var user = _context.Personen.FirstOrDefault(p => p.PersonId == userId);

        if (userId != null)
        {
            Autofahrten = _context.Fahrten
                .Include(f => f.Route)
                .Include(f => f.Fahrer)
                .Where(f => f.Passagiere.Contains(user))
                .ToList();
        }
    }
}
