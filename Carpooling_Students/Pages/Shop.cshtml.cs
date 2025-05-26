using Carpooling_Students.Model;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Collections.Generic;
using System.Linq;

public class Shop_cs : PageModel
{
    private readonly CarpoolContext _context;

    public Shop_cs(CarpoolContext context)
    {
        _context = context;
    }

    public List<Item> ArtikelListe { get; set; } = new();
    

    public void OnGet()
    {
        ArtikelListe = _context.Items.ToList();
    }
}
