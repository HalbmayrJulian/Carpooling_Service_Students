using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Carpooling_Students.Model;

public class MyRides_cs : PageModel
{
    private readonly CarpoolContext _context;

    public List<Fahrt> Rides { get; set; } = new();

    public MyRides_cs(CarpoolContext context)
    {
        _context = context;
    }

    public async Task OnGetAsync()
    {
        Rides = await _context.Fahrten
        .Include(f => f.Route)
        .ToListAsync();

        var updateCandidates = Rides.Where(f => f.EndDatum < DateTime.Now && !f.Abgeschlossen).ToList();

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
