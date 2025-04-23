using Microsoft.AspNetCore.Mvc.RazorPages;

public class UserPage_cs : PageModel
{
    public void OnGet()
    {
        // Beispiel: Daten aus Session laden oder Coins setzen
        // ViewData["Coins"] = HttpContext.Session.GetInt32("Coins") ?? 0;
    }
}
