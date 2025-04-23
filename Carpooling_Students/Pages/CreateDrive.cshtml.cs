using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

public class FahrtErstellenModel : PageModel
{
    [BindProperty] public string Start { get; set; }
    [BindProperty] public string Ziel { get; set; }
    [BindProperty] public DateTime Zeit { get; set; }
    [BindProperty] public int Plaetze { get; set; }

    public void OnGet() { }

    public IActionResult OnPost()
    {
        // Hier kannst du die Daten in die Datenbank speichern:
        // z. B. _db.AddFahrt(Start, Ziel, Zeit, Plaetze);

        return RedirectToPage("/Overview"); // Oder Erfolgsmeldung
    }
}
