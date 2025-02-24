using Microsoft.AspNetCore.Mvc;
using System.Text.Encodings.Web;
using  PROJECT_NAME.Models;
namespace PROJECT_NAME.Controllers
{
    public class BMIController : Controller
    { 
        // GET: /BMI/
   
        public IActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Index(BMI bmi){
            if (bmi.weight > 0 && bmi.height > 0){
                double BMI = bmi.weight / (bmi.height * bmi.height);
                string category = BMI < 18.5?"Gầy":
                                  BMI < 24.9?"Bình Thường":
                                  BMI < 29.9?"Béo phì":
                ViewBag.BMI=BMI.ToString("0.00");
                ViewBag.Category = category;
            }
            else {
                ViewBag.Error = "Vui lòng nhập chiều cao cân nặng hợp lệ!";
            }
            return View();
        }
    }
}
