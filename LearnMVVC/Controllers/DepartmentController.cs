using LearnMVVC.Data;
using LearnMVVC.Models.DataModel;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace LearnMVVC.Controllers
{
    public class DepartmentController : Controller
    {
        private readonly EmployeeDbContext _employeeDbContext;

        public DepartmentController(EmployeeDbContext employeeDbContext)
        {
            _employeeDbContext = employeeDbContext;
        }

        public async Task<IActionResult> Index()
        {
            var departments = await _employeeDbContext.Departments.ToListAsync();
            return View(departments);
        }

        public IActionResult AddDepartment()
        {
            return View();
        }

        [HttpPost]
        public IActionResult AddDepartment(Department department)
        {
            if (ModelState.IsValid)
            {
                _employeeDbContext.Departments.Add(department);
                _employeeDbContext.SaveChanges();
                return RedirectToAction("Index");
            }
            return View();
        }
    }
}
