using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Carpooling_Students.Model;
using Microsoft.EntityFrameworkCore;

public class shoppingcart_cs : PageModel
{
    private readonly CarpoolContext _context;

    public shoppingcart_cs(CarpoolContext context)
    {
        _context = context;
    }

    public Person Benutzer { get; set; } = new Person();

    public void OnGet()
    {
        int? userId = HttpContext.Session.GetInt32("UserId");
        if (userId != null)
        {
            Benutzer = _context.Personen.FirstOrDefault(p => p.PersonId == userId) ?? new Person();
        }
    }

    public class CartItemDto
    {
        public string Name { get; set; } = "";
        public double Price { get; set; }
    }

    public async Task<IActionResult> OnPostAsync([FromBody] List<CartItemDto> cart)
    {
        int? userId = HttpContext.Session.GetInt32("UserId");

        if (userId == null)
            return new JsonResult(new { success = false, message = "Nicht eingeloggt." });

        var user = await _context.Personen.FindAsync(userId);
        if (user == null)
            return new JsonResult(new { success = false, message = "Benutzer nicht gefunden." });

        double total = cart.Sum(i => i.Price);

        if (user.Coins < total)
            return new JsonResult(new { success = false, message = "Nicht genug Coins." });

        var bestellung = new Bestellung
        {
            UserId = user.PersonId,
            Bestelldatum = DateTime.Now,
            Artikel = new List<Bestellposition>()
        };

        foreach (var itemDto in cart)
        {
            var item = await _context.Items.FirstOrDefaultAsync(i => i.Name == itemDto.Name);
            if (item == null)
                return new JsonResult(new { success = false, message = $"Artikel '{itemDto.Name}' existiert nicht." });

            bestellung.Artikel.Add(new Bestellposition
            {
                ItemId = item.ItemId
            });
        }

        user.Coins -= (int)total;
        _context.Bestellungen.Add(bestellung);
        await _context.SaveChangesAsync();

        return new JsonResult(new { success = true, remaining = user.Coins });
    }
}
