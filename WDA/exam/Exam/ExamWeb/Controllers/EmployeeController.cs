using AutoMapper;
using ExamonimyWeb.Repositories.GenericRepository;
using ExamWeb.Entities;
using ExamWeb.Models;
using Microsoft.AspNetCore.Mvc;
using System.Linq.Expressions;

namespace ExamWeb.Controllers
{
    public class EmployeeController : Controller
    {
        private readonly IGenericRepository<Employee> _employeeRepository;
        private readonly IMapper _mapper;

        public EmployeeController(IGenericRepository<Employee> employeeRepository, IMapper mapper)
        {
            _employeeRepository = employeeRepository;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var employees = await _employeeRepository.GetAsync(null, null, null);
            var departmentsToReturn = employees.Select(d => _mapper.Map<DepartmentGetModel>(d));
            return View(departmentsToReturn);
        }

        [HttpGet]
        public async Task<IActionResult> Single([FromRoute] int id)
        {
            Expression<Func<Employee, bool>> predicate = d => d.Id == id;
            var employee = await _employeeRepository.GetAsync(predicate, null);
            var employeeToReturn = _mapper.Map<EmployeeGetModel>(employee);
            return View(employeeToReturn);
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] EmployeeCreateModel employeeCreateModel)
        {
            var employeeToCreate = _mapper.Map<Employee>(employeeCreateModel);
            await _employeeRepository.InsertAsync(employeeToCreate);
            await _employeeRepository.SaveAsync();
            return RedirectToAction("Index");
        }

        [HttpGet]
        public async Task<IActionResult> Update([FromRoute] int id)
        {
            Expression<Func<Employee, bool>> predicate = d => d.Id == id;
            var employeeToUpdate = await _employeeRepository.GetAsync(predicate, null);
            if (employeeToUpdate is null)
                return NotFound();
            return View(employeeToUpdate);
        }

        [HttpPost]
        public async Task<IActionResult> Update([FromRoute] int id, [FromBody] EmployeeUpdateModel employeeUpdateModel)
        {
            Expression<Func<Employee, bool>> predicate = d => d.Id == id;
            var department = await _employeeRepository.GetAsync(predicate, null);
            if (department is null)
                return NotFound();
            _mapper.Map(employeeUpdateModel, department);
            _employeeRepository.Update(department);
            await _employeeRepository.SaveAsync();
            return RedirectToAction("Single", new { id = department.Id });
        }

        [HttpPost]
        public async Task<IActionResult> Delete([FromRoute] int id)
        {
            Expression<Func<Employee, bool>> predicate = d => d.Id == id;
            var employee = await _employeeRepository.GetAsync(predicate, null);
            if (employee is null)
                return NotFound();

            _employeeRepository.Delete(employee);
            await _employeeRepository.SaveAsync();
            return RedirectToAction("Index");
        }
    }
}
