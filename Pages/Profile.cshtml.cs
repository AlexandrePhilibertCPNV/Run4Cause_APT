using Microsoft.AspNetCore.Mvc.RazorPages;
using Run4Cause.Models;
using Microsoft.Extensions.Logging;
using System;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
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

        public User User { get; set; }

        public async Task<IActionResult> OnGetAsync()
        {
            // get the user with id 1
            User = await _context.Users.FirstOrDefaultAsync(u => u.Id == 1);

            return Page();
        }
    }
}