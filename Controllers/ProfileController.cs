using Microsoft.AspNetCore.Mvc;

namespace run4cause.Controllers;

public class ProfileController : Controller
{
    public IActionResult Index(int Id)
    {
        Console.Out.WriteLine(Id.ToString());

        return View();
    }
}