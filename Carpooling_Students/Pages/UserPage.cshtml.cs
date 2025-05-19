using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Carpooling_Students.Model;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;

public class UserPage_cs : PageModel
{
    private readonly CarpoolContext _context;

    public UserPage_cs(CarpoolContext context)
    {
        _context = context;
    }

    public Person AngemeldetePerson { get; set; }

    public List<Fahrt> LetzteFahrten { get; set; }

    public IActionResult OnGet()
    {
        int? userId = HttpContext.Session.GetInt32("UserId");

        if (userId == null)
            return RedirectToPage("/Login");

        AngemeldetePerson = _context.Personen.FirstOrDefault(p => p.PersonId == userId);

        if (AngemeldetePerson == null)
            return RedirectToPage("/Login");

        // Die letzten 5 Fahrten des Benutzers als Fahrer
        LetzteFahrten = _context.Fahrten
            .Include(f => f.Route)
            .Where(f => f.Fahrer.PersonId == userId)
            .OrderByDescending(f => f.StartDatum)
            .Take(5)
            .ToList();

        return Page();
    }
}
