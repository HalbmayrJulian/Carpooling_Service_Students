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

        [BindProperty]
        public int? RemovePassagierId { get; set; }

        public async Task<IActionResult> OnGetAsync()
        {
            await LoadFahrt();
            return Page();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (RemovePassagierId.HasValue)
            {
                var eintrag = await _context.FahrtPassagiere
                    .FirstOrDefaultAsync(fp => fp.Id == RemovePassagierId.Value && fp.Fahrt.FahrtId == Id);

                if (eintrag != null)
                {
                    _context.FahrtPassagiere.Remove(eintrag);
                    await _context.SaveChangesAsync();
                }
            }

            return RedirectToPage(new { id = Id }); // Reload mit aktualisierter Liste
        }

        private async Task LoadFahrt()
        {
            Fahrt = await _context.Fahrten
                .Include(f => f.Fahrer)
                .Include(f => f.FahrtPassagiere)
                    .ThenInclude(fp => fp.Passagier)
                .FirstOrDefaultAsync(f => f.FahrtId == Id);
        }
    }
}
