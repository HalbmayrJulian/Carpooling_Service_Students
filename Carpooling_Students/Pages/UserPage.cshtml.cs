using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Carpooling_Students.Model;

public class UserPage_cs : PageModel
{
    private readonly CarpoolContext _context;

    public UserPage_cs(CarpoolContext context)
    {
        _context = context;
    }

    public Person AngemeldetePerson { get; set; }

    public IActionResult OnGet()
    {
        int? userId = HttpContext.Session.GetInt32("UserId");

        if (userId == null)
            return RedirectToPage("/Login");

        AngemeldetePerson = _context.Personen.FirstOrDefault(p => p.PersonId == userId);

        if (AngemeldetePerson == null)
            return RedirectToPage("/Login");

        return Page();
    }
}
