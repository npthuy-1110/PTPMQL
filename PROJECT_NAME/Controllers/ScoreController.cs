using Microsoft.AspNetCore.Mvc;
using System.Text.Encodings.Web;
using  PROJECT_NAME.Models;
namespace PROJECT_NAME.Controllers
{
    public class ScoreController : Controller
    {
        public IActionResult Index()
        {
          return View();
        }
        [HttpPost]
        public IActionResult Index(Score model)
        {
            double totalScore = (model.ScoreA * 0.6) + (model.ScoreB * 0.3) + (model.ScoreC * 0.1);
            string message = totalScore >= 5 ? "Bạn đã đỗ môn học!": "Bạn đã trượt môn học!";
            ViewBag.TotalScore = totalScore;
            ViewBag.Message = message;

        return View();
        }
    }
}