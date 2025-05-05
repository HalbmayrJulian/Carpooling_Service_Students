using Carpooling_Students.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.ComponentModel.DataAnnotations;
using System.Globalization;
using System.Linq;
using System.Text.RegularExpressions;

public class Register_cs : PageModel
{
    private readonly CarpoolContext _context;

    public Register_cs(CarpoolContext context)
    {
        _context = context;
    }

    [BindProperty]
    public string Email { get; set; }

    [BindProperty]
    public string Password { get; set; }

    [BindProperty]
    public string Address { get; set; }

    public string Fehler { get; set; }

    private Regex htlwyEmail = new Regex(@"^[a-z\.a-z]+@htlwy\.at$");

    public void OnGet()
    {
    }

    public IActionResult OnPost()
    {
        if (!ModelState.IsValid)
            return Page();

        if (_context.Personen.Any(p => p.Email == Email))
        {
            Fehler = "Diese E-Mail-Adresse ist bereits registriert.";
            return Page();
        }

        if(!htlwyEmail.IsMatch(Email))
        {
            Fehler = "Ungültige E-Mail-Adresse.";
            return Page();
        }
        var nameTeil = Email.Substring(0, Email.IndexOf('@')).Replace('.', ' ');
        var name = CultureInfo.CurrentCulture.TextInfo.ToTitleCase(nameTeil);

        var person = new Person
        {
            Adresse = Address,
            Password = Password, 
            Email = Email,
            GesamtDistanz = 0,
            Coins = 0,
            Name = name
        };

        _context.Personen.Add(person);
        _context.SaveChanges();

        return RedirectToPage("/UserPage");
    }
}
