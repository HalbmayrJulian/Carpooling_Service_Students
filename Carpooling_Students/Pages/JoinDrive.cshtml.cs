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

    [BindProperty]
    public int FahrtId { get; set; }

    public async Task<IActionResult> OnGetAsync()
    {
        int? userId = HttpContext.Session.GetInt32("UserId");
        if (userId == null)
        {
            return RedirectToPage("/Login");
        }

        var aktuellerBenutzer = await _context.Personen
            .FirstOrDefaultAsync(p => p.PersonId == userId);

        if (aktuellerBenutzer == null)
        {
            return Unauthorized();
        }

        Fahrten = await _context.Fahrten
            .Include(f => f.Route)
            .Include(f => f.Fahrer)
            .Include(f => f.FahrtPassagiere)
                .ThenInclude(fp => fp.Passagier)
            .Where(f => !f.Abgeschlossen &&
                        f.EndDatum > DateTime.Now &&
                        f.Fahrer != aktuellerBenutzer &&
                        f.FahrtPassagiere.Any(fp => fp.Passagier.PersonId != aktuellerBenutzer.PersonId))
            .ToListAsync();

        return Page();
    }

    public async Task<IActionResult> OnPostAsync()
    {
        int? userId = HttpContext.Session.GetInt32("UserId");
        if (userId == null)
        {
            return RedirectToPage("/Login");
        }

        var aktuellerBenutzer = await _context.Personen
            .FirstOrDefaultAsync(p => p.PersonId == userId);

        if (aktuellerBenutzer == null)
        {
            return Unauthorized();
        }

        var fahrt = await _context.Fahrten
            .Include(f => f.FahrtPassagiere)
                .ThenInclude(fp => fp.Passagier)
            .FirstOrDefaultAsync(f => f.FahrtId == FahrtId);

        if (fahrt == null)
        {
            return NotFound("Fahrt nicht gefunden.");
        }

        if (fahrt.FahrtPassagiere.Count >= fahrt.Sitze)
        {
            ModelState.AddModelError("", "Keine Plätze mehr verfügbar.");
            await OnGetAsync();
            return Page();
        }

        fahrt.FahrtPassagiere.Add(new FahrtPassagier
        {
            Fahrt = fahrt,
            Passagier = aktuellerBenutzer
        });

        await _context.SaveChangesAsync();

        TempData["Erfolg"] = "Du wurdest erfolgreich angemeldet.";
        return RedirectToPage("/JoinDrive");
    }
}
