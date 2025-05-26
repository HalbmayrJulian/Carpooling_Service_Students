using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Carpooling_Students.Model;

public class JoinDrive_cs : PageModel
{
    private readonly CarpoolContext _context;

    public List<Fahrt> Fahrten { get; set; }

    public JoinDrive_cs(CarpoolContext context)
    {
        _context = context;
    }

    public async Task OnGetAsync()
    {
        int? userId = HttpContext.Session.GetInt32("UserId");
        var aktuellerBenutzer = await _context.Personen
            .FirstOrDefaultAsync(p => p.PersonId == userId);

        Fahrten = _context.Fahrten
            .Include(f => f.Route)
            .Include(f => f.Fahrer)
            .Include(f => f.Passagiere)
            .Where(f => !f.Abgeschlossen && f.EndDatum > DateTime.Now && f.Fahrer!=aktuellerBenutzer)
            .ToList();
    }

    [BindProperty]
    public int FahrtId { get; set; }

    public async Task<IActionResult> OnPostAsync()
    {
        int? userId = HttpContext.Session.GetInt32("UserId");
        var aktuellerBenutzer = await _context.Personen
            .FirstOrDefaultAsync(p => p.PersonId==userId);
        if (aktuellerBenutzer == null)
        {
            return Unauthorized();
        }

        var fahrt = await _context.Fahrten
            .Include(f => f.Passagiere)
            .Include(f => f.Fahrer)
            .FirstOrDefaultAsync(f => f.FahrtId == FahrtId);

        if (fahrt == null)
        {
            return NotFound("Fahrt nicht gefunden.");
        }

        if (fahrt.Passagiere.Count >= fahrt.Sitze)
        {
            ModelState.AddModelError("", "Keine Plätze mehr verfügbar.");
            return Page();
        }
        fahrt.Passagiere.Add(aktuellerBenutzer);
        await _context.SaveChangesAsync();

        TempData["Erfolg"] = "Du wurdest erfolgreich angemeldet.";
        return RedirectToPage("/JoinDrive");
    }
}
