using Microsoft.AspNetCore.Mvc.RazorPages;

public class EditFahrtModel : PageModel
{
    public List<string> Mitfahrer { get; set; }

    public void OnGet()
    {
        // Datenbankzugriff o. Ä.
        Mitfahrer = new List<string> { "Lisa", "Jonas", "Anna" };
    }
}
