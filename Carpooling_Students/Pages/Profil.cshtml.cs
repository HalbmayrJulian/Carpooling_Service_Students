using Microsoft.AspNetCore.Mvc.RazorPages;

public class Profil_cs : PageModel
{
    public void OnGet()
    {
        // Optional: Benutzername dynamisch laden z.?B. aus Session oder DB
        // Beispiel: ViewData["Username"] = HttpContext.Session.GetString("User");
    }
}
