using Microsoft.AspNetCore.Mvc;

namespace Run4Cause.Controllers;

public class ProfileController : Controller
{
    public IActionResult Index(int Id)
    {
        Console.Out.WriteLine(Id.ToString());

        return View();
    }
}