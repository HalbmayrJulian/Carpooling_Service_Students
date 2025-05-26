using Carpooling_Students.Model;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Http;
using System.Collections.Generic;
using System.Linq;

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
        if (userId != null)
        {
            Autofahrten = _context.Fahrten
                .Include(f => f.Route)
                .Include(f => f.Fahrer)
                .Include(f => f.FahrtPassagiere)
                    .ThenInclude(fp => fp.Passagier)
                .Where(f => f.FahrtPassagiere.Any(fp => fp.Passagier.PersonId == userId))
                .ToList();
        }
    }
}
