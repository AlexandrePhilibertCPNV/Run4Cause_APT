using Microsoft.AspNetCore.Mvc;
using Run4Cause.Models;
using Microsoft.EntityFrameworkCore;

namespace Run4Cause.ViewComponents
{
    public class SponsorModal : ViewComponent
    {
        private readonly Run4Cause.Data.Run4CauseContext _context;

        public SponsorModal(Run4Cause.Data.Run4CauseContext context)
        {
            _context = context;
        }

        public IViewComponentResult Invoke(User user)
        {
            return View(user);
        }
    }
}