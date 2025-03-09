using Microsoft.AspNetCore.Mvc;
using PROJECT_NAME.Data;
using PROJECT_NAME.Models;

namespace PROJECT_NAME.Controllers
{
    public class PersonController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
        [HttpPost]
    
        public IActionResult Index(Person ps)
        {
            string str0utput = "Xin chao " + ps.PersonId + "-" + ps.FullName + "-" +ps.Address;
            ViewBag.infoPerson = str0utput;
            return View();
        }
}
}