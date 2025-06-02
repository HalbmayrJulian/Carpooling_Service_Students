using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Carpooling_Students.Model;
using System.Collections.Generic;
using System.Linq;
using System;

public class Ranking_cs : PageModel
{
    private readonly CarpoolContext _context;

    public Ranking_cs(CarpoolContext context)
    {
        _context = context;
    }

    public List<Person> PersonenMitRanking { get; set; } = new();
    public Person? AktuellerBenutzer { get; set; }
    public int? AktuellerRang { get; set; }

    public void OnGet()
    {
        int? userId = HttpContext.Session.GetInt32("UserId");

        PersonenMitRanking = _context.Personen.Include(p => p.GefahreneFahrten)
            .OrderByDescending(p => p.GefahreneFahrten.Count)
            .ToList();

        if (userId.HasValue)
        {
            AktuellerBenutzer = PersonenMitRanking
                .FirstOrDefault(p => p.PersonId == userId.Value);

            if (AktuellerBenutzer != null)
            {
                AktuellerRang = PersonenMitRanking.IndexOf(AktuellerBenutzer) + 1;
            }
        }
    }
}
