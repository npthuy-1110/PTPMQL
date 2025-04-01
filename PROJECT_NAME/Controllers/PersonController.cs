using System.Data;
using DemoMVC.Models.Process;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using OfficeOpenXml;
using PROJECT_NAME.Data;
using PROJECT_NAME.Models;

namespace PROJECT_NAME.Controllers
{
    public class PersonController : Controller
    {
        private readonly ApplicationDbContext _context;
        private ExcelProcess _excelProcess = new ExcelProcess();

        public PersonController(ApplicationDbContext context)
        {
            _context = context;
        }
        [HttpGet]
        public IActionResult Download()
        {
          var fileName = "YourFileName" + ".xlsx";
          using (ExcelPackage excelPackage = new ExcelPackage())
          {
               ExcelWorksheet worksheet = excelPackage.Workbook.Worksheets.Add("Sheet 1");
               worksheet.Cells["A1"].Value = "PersonID";
               worksheet.Cells["B1"].Value = "FullName";
               worksheet.Cells["C1"].Value = "Address";
               var personList = _context.Person.ToList();
               worksheet.Cells["A2"].LoadFromCollection(personList);
               var stream = new MemoryStream(excelPackage.GetAsByteArray());
               return File(stream, "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet", fileName);
          }
        }
        public async Task<IActionResult> Index()
        {
            var model = await _context.Person.ToListAsync();
            return View(model);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("PersonId, FullName, Address, Email")] Person person)
        {
            if (ModelState.IsValid)
            {
                _context.Add(person);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(person);
        }

        public async Task<IActionResult> Edit(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var person = await _context.Person.FindAsync(id);
            if (person == null)
            {
                return NotFound();
            }

            return View(person);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(string id, [Bind("PersonId, FullName, Address, Email")] Person person)
        {
            if (id != person.PersonId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(person);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!PersonExists(person.PersonId))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(person);
        }

        public async Task<IActionResult> Delete(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var person = await _context.Person.FirstOrDefaultAsync(m => m.PersonId == id);
            if (person == null)
            {
                return NotFound();
            }

            return View(person);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(string id)
        {
            var person = await _context.Person.FindAsync(id);
            if (person == null)
            {
                return NotFound();
            }

            _context.Person.Remove(person);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool PersonExists(string id)
        {
            return _context.Person.Any(e => e.PersonId == id);
        }

        public IActionResult Upload()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Upload(IFormFile file)
        {
            if (file == null || file.Length == 0)
            {
                ModelState.AddModelError("", "No file selected!");
                return View();
            }

            string fileExtension = Path.GetExtension(file.FileName);
            if (fileExtension != ".xls" && fileExtension != ".xlsx")
            {
                ModelState.AddModelError("", "Please choose an Excel file to upload!");
                return View();
            }

            // Tạo thư mục lưu trữ nếu chưa tồn tại
            var uploadDir = Path.Combine(Directory.GetCurrentDirectory(), "Uploads", "Excels");
            if (!Directory.Exists(uploadDir))
            {
                Directory.CreateDirectory(uploadDir);
            }

            // Đặt tên file
            var fileName = DateTime.Now.ToString("yyyyMMdd_HHmmss") + fileExtension;
            var filePath = Path.Combine(uploadDir, fileName);
            
            // Lưu file vào server
            using (var stream = new FileStream(filePath, FileMode.Create))
            {
                await file.CopyToAsync(stream);
            }

            // Đọc dữ liệu từ file Excel
            var dt = _excelProcess.ExcelToDataTable(filePath);
            List<Person> people = new List<Person>();

            for (int i = 0; i < dt.Rows.Count; i++)
            {
                var ps = new Person
                {
                    PersonId = dt.Rows[i][0].ToString(),
                    FullName = dt.Rows[i][1].ToString(),
                    Address = dt.Rows[i][2].ToString()
                };

                // Kiểm tra xem PersonId đã tồn tại chưa
                if (!_context.Person.Any(p => p.PersonId == ps.PersonId))
                {
                    people.Add(ps);
                }
            }

            // Thêm danh sách vào database
            if (people.Count > 0)
            {
                _context.AddRange(people);
                await _context.SaveChangesAsync();
            }

            return RedirectToAction(nameof(Index));
        }
    }
}
