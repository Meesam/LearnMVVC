using LearnMVVC.Data;
using LearnMVVC.Models;
using LearnMVVC.Models.DataModel;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace LearnMVVC.Controllers
{
    public class EmployeeController : Controller
    {
        private readonly EmployeeDbContext _employeeDbContext;

        public EmployeeController(EmployeeDbContext employeeDbContext)
        {
            _employeeDbContext = employeeDbContext;
        }

        public async Task<IActionResult> Index()
        {
            var employees = await _employeeDbContext.Employees.ToListAsync();
            return View(employees);
        }

        public IActionResult AddEmployee()
        {
            return View();
        }

        [HttpPost]
        public IActionResult AddEmployee(EmployeeVM emp)
        {
            if (ModelState.IsValid)
            {
                var employee = new Employee
                {
                    Name = emp.Name,
                    Email = emp.Email,
                    Dob = emp.Dob
                };
                _employeeDbContext.Employees.Add(employee);
                _employeeDbContext.SaveChanges();
            }
            return View(emp);
        }

        public async Task<IActionResult> EditEmployee(int id)
        {
            var employee = await _employeeDbContext.Employees.FindAsync(id);
            if (employee is not null)
            {
                var employeeVM = new EmployeeVM
                {
                    Email = employee.Email,
                    Name = employee.Name,
                    Dob = employee.Dob,
                    Id = employee.Id
                };
                return View("AddEmployee", employeeVM);
            }
            else
            {
                return View("Index");
            }
        }


    }
}
