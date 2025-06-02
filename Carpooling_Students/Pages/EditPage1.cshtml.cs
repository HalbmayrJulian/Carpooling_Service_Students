using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Carpooling_Students.Model;

namespace Carpooling_Students.Pages
{
    public class EditFahrtModel : PageModel
    {
        private readonly CarpoolContext _context;

        public EditFahrtModel(CarpoolContext context)
        {
            _context = context;
        }

        [BindProperty(SupportsGet = true)]
        public int Id { get; set; } // FahrtId aus URL

        public Fahrt Fahrt { get; set; }

        public async Task<IActionResult> OnGetAsync()
        {
            Fahrt = await _context.Fahrten
                .Include(f => f.Fahrer)
                .Include(f => f.FahrtPassagiere)
                    .ThenInclude(fp => fp.Passagier)
                .FirstOrDefaultAsync(f => f.FahrtId == Id);

            if (Fahrt == null)
            {
                return NotFound(); // 404, wenn Fahrt nicht existiert
            }

            return Page();
        }
    }
}
