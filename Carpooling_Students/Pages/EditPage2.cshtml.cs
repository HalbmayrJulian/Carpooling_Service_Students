using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Carpooling_Students.Model;

namespace Carpooling_Students.Pages
{
    public class EditPage2_cs : PageModel
    {
        private readonly CarpoolContext _context;

        public EditPage2_cs(CarpoolContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Fahrt Fahrt { get; set; }

        public async Task<IActionResult> OnGetAsync(int id)
        {
            Fahrt = await _context.Fahrten
                .Include(f => f.Route)
                .FirstOrDefaultAsync(f => f.FahrtId == id);

            if (Fahrt == null)
                return NotFound();

            return Page();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            var fahrtInDb = await _context.Fahrten
                .Include(f => f.Route)
                .FirstOrDefaultAsync(f => f.FahrtId == Fahrt.FahrtId);

            if (fahrtInDb == null)
                return NotFound();

            fahrtInDb.Sitze = Fahrt.Sitze;
            fahrtInDb.StartDatum = Fahrt.StartDatum;

            if (fahrtInDb.Route != null && Fahrt.Route != null)
            {
                fahrtInDb.Route.StartOrt = Fahrt.Route.StartOrt;
                fahrtInDb.Route.ZielOrt = Fahrt.Route.ZielOrt;
            }

            await _context.SaveChangesAsync();

            return RedirectToPage("/MyRides");
        }
    }
}
