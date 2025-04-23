using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

public class Register_cs : PageModel
{
    [BindProperty]
    public string Email { get; set; }

    [BindProperty]
    public string Password { get; set; }

    [BindProperty]
    public string Address { get; set; }

    public void OnGet()
    {
        // Optional: z. B. Session prüfen oder Daten vorbereiten
    }

    public IActionResult OnPost()
    {
        if (!ModelState.IsValid)
            return Page();

        // TODO: Benutzer speichern (z. B. in DB)
        // Beispiel:
        // userService.CreateUser(Email, Password, Address);

        return RedirectToPage("/UserPage");
    }
}
