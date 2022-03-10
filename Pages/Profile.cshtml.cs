using Microsoft.AspNetCore.Mvc.RazorPages;
using Run4Cause.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace Run4Cause.Pages
{
    public class ProfileModel : PageModel
    {
        private readonly Run4Cause.Data.Run4CauseContext _context;

        public ProfileModel(Run4Cause.Data.Run4CauseContext context)
        {
            _context = context;
        }

        public User User { get; set; }

        [BindProperty]
        public InputModel Input { get; set; }

        public async Task<IActionResult> OnPostAsync(int userId)
        {
            User? user = await _context.Users.Include(u => u.Profile)
                .FirstOrDefaultAsync(u => u.Id == userId);

            /**
              * The user needs to have a profile in order to display the page.
              */
            if (user == null || user.Profile == null)
            {
                return NotFound();
            }

            if (!ModelState.IsValid)
            {
                return Page();
            }

            user.FirstName = Input.FirstName;
            user.LastName = Input.LastName;
            user.Profile.Description = Input.Description;

            await _context.SaveChangesAsync();

            User = user;

            return Page();
        }

        public async Task<IActionResult> OnGetAsync(int userId)
        {
            User? user = await _context.Users.Include(u => u.Profile)
                .AsNoTracking()
                .FirstOrDefaultAsync(u => u.Id == userId);

            /**
             * The user needs to have a profile in order to display the page.
             */
            if (user == null || user.Profile == null)
            {
                return NotFound();
            }

            User = user;

            return Page();
        }

        public class InputModel
        {

            [Required]
            [Display(Name = "FirstName")]
            public string FirstName { get; set; }

            [Required]
            [Display(Name = "LastName")]
            public string LastName { get; set; }

            [Required]
            [Display(Name = "Descritpion")]
            public string Description { get; set; }
        }
    }
}