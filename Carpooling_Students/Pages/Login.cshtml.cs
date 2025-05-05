using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc;
using System.Text.RegularExpressions;

public class Login_cs : PageModel
{
    private readonly CarpoolContext _db;

    public Login_cs(CarpoolContext db)
    {
        _db = db;
    }

    private Regex htlwyEmail= new Regex(@"^[a-z\.a-z]+@htlwy\.at$");

    [BindProperty]
    public string Email { get; set; }

    [BindProperty]
    public string Password { get; set; }

    public string Fehler { get; set; }

    public void OnGet()
    {
        
    }
    

    public IActionResult OnPost()
    {
        if (htlwyEmail.IsMatch(Email)) {
            var person = _db.Personen
                .FirstOrDefault(p => p.Email == Email && p.Password == Password);

            if (person != null)
            {
                Fehler = string.Empty;
                HttpContext.Session.SetInt32("UserId", person.PersonId); // Nach erfolgreichem Login oder Registrierung
                return RedirectToPage("/UserPage");
            }
            Fehler = "Ungültige Anmeldedaten.";
        }
        else 
            Fehler = "Ungültige Email.";

        return Page();
    }
}
