using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Carpooling_Students.Model;

public class MyRides_cs : PageModel
{
    private readonly CarpoolContext _context;

    public List<Fahrt> Fahrten { get; set; }

    public MyRides_cs(CarpoolContext context)
    {
        _context = context;
    }

    public async Task OnGetAsync()
    {
        int? userId = HttpContext.Session.GetInt32("UserId");
        var aktuellerBenutzer = await _context.Personen
            .FirstOrDefaultAsync(p => p.PersonId == userId);

        Fahrten = await _context.Fahrten
            .Include(f => f.Route)
            .Include(f => f.Fahrer)
            .Include(f => f.Passagiere)
            .Where(f => f.Fahrer == aktuellerBenutzer)
            .ToListAsync();

        var updateCandidates = Fahrten.Where(f => f.EndDatum < DateTime.Now && !f.Abgeschlossen).ToList();

        if (updateCandidates.Any())
        {
            foreach (var ride in updateCandidates)
            {
                ride.Abgeschlossen = true;
            }

            await _context.SaveChangesAsync();
        }
    }
}
