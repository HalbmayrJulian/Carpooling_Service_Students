using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

public class FahrtErstellenModel : PageModel
{
    private readonly CarpoolContext _context;

    public FahrtErstellenModel()
    {
        _context = new CarpoolContext();
    }

    [BindProperty] public string Start { get; set; }
    [BindProperty] public string Ziel { get; set; }
    [BindProperty] public DateTime Zeit { get; set; }
    [BindProperty] public int Plaetze { get; set; }

    public void OnGet() { }

    public IActionResult OnPost()
    {
        


        return RedirectToPage("/Overview"); // Oder Erfolgsmeldung
    }
}
