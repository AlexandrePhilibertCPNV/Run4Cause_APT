using Microsoft.AspNetCore.Mvc.RazorPages;
using Run4Cause.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Run4Cause.Pages
{
    public class ProfileModel : PageModel
    {
        private readonly Run4Cause.Data.Run4CauseContext _context;

        public ProfileModel(Run4Cause.Data.Run4CauseContext context)
        {
            _context = context;
        }

        public User? User { get; set; }

        public async Task<IActionResult> OnGetAsync(int userId)
        {
            User = await _context.Users.Include(u => u.Profile)
                .AsNoTracking()
                .FirstOrDefaultAsync(u => u.Id == userId);

            /**
             * The user needs to have a profile in order to display the page.
             */
            if (User == null || User.Profile == null)
            {
                return NotFound();
            }

            return Page();
        }
    }
}