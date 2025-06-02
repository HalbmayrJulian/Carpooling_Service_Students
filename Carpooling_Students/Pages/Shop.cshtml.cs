using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Carpooling_Students.Model;
using Microsoft.EntityFrameworkCore;

namespace Carpooling_Students.Pages
{
    public class Shop_cs : PageModel
    {
        private readonly CarpoolContext _context;

        public Shop_cs(CarpoolContext context)
        {
            _context = context;
        }

        public List<Item> ArtikelListe { get; set; } = new();
        public Person Benutzer { get; set; }

        public async Task<IActionResult> OnGetAsync()
        {
            int? userId = HttpContext.Session.GetInt32("UserId");
            if (userId == null)
                return RedirectToPage("/Login");

            Benutzer = await _context.Personen.FirstOrDefaultAsync(p => p.PersonId == userId);
            if (Benutzer == null)
                return NotFound();

            ArtikelListe = await _context.Items.ToListAsync();
            return Page();
        }

        public async Task<IActionResult> OnPostBuyAsync(int itemId)
        {
            int? userId = HttpContext.Session.GetInt32("UserId");
            if (userId == null)
                return RedirectToPage("/Login");

            var user = await _context.Personen.FindAsync(userId);
            if (user == null)
                return NotFound();

            var item = await _context.Items.FindAsync(itemId);
            if (item == null)
                return NotFound();

            if (user.Coins < item.Price)
            {
                TempData["Error"] = "Du hast nicht genug Coins!";
                return RedirectToPage();
            }

            // Coins abziehen
            user.Coins -= item.Price;

            // Bestellung + Position erstellen
            var bestellung = new Bestellung
            {
                UserId = user.PersonId,
                Bestelldatum = DateTime.Now,
                Artikel = new List<Bestellposition>
                {
                    new Bestellposition
                    {
                        ItemId = item.ItemId
                    }
                }
            };

            _context.Bestellungen.Add(bestellung);
            await _context.SaveChangesAsync();

            return RedirectToPage();
        }
    }
}
