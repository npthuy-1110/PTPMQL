using Microsoft.AspNetCore.Mvc;
using System.Text.Encodings.Web;
using  PROJECT_NAME.Models;
namespace PROJECT_NAME.Controllers
{
    public class BillController : Controller
    { 
        public IActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Index(Bill model)
        {
             if (ModelState.IsValid)
            {
                model.TotalAmount = model.Quantity * model.UnitPrice;

                ViewBag.TotalAmount = model.TotalAmount;
                ViewBag.Message = "Hoá đơn đã được tính toán thành công!";

                return View(model); 
            }

            ViewBag.Message = "Vui lòng nhập thông tin hợp lệ!";
            return View();
        }
    }
}