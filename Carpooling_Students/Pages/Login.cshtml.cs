using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

public class Login_cs : PageModel
{
    [BindProperty]
    public string Email { get; set; }

    [BindProperty]
    public string Password { get; set; }

    public void OnGet()
    {
        // Wird aufgerufen, wenn die Seite geladen wird
    }

    public IActionResult OnPost()
    {
        // Hier später Logik zur Benutzerprüfung einbauen (z. B. DB-Abfrage)
        if (Email == "admin@example.com" && Password == "1234")
        {
            return RedirectToPage("/UserPage");
        }

        ModelState.AddModelError(string.Empty, "Ungültige Anmeldedaten.");
        return Page();
    }
}
