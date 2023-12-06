using AutoMapper;
using ExamWeb.Repositories.GenericRepository;
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
        private readonly IGenericRepository<Department> _departmentRepository;

        public EmployeeController(IGenericRepository<Employee> employeeRepository, IMapper mapper, IGenericRepository<Department> departmentRepository)
        {
            _employeeRepository = employeeRepository;
            _mapper = mapper;
            _departmentRepository = departmentRepository;
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var employees = await _employeeRepository.GetAsync(null, null, new List<string> { "Department" });
            var employeesToReturn = employees.Select(e => _mapper.Map<EmployeeGetModel>(e));
            return View(employeesToReturn);
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
        public async Task<IActionResult> Create()
        {
            var departments = await _departmentRepository.GetAsync(null, null, null);
            var departmentsToReturn = departments.Select(d => _mapper.Map<DepartmentGetModel>(d));
            return View(departmentsToReturn);
        }

        [HttpPost]
        public async Task<IActionResult> Create(EmployeeCreateModel employeeCreateModel)
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
            var employee = await _employeeRepository.GetAsync(predicate, null);
            if (employee is null)
                return NotFound();
            var employeeToUpdate = _mapper.Map<EmployeeUpdateModel>(employee);
            var departments = await _departmentRepository.GetAsync(null, null, null);
            var departmentsToReturn = departments.Select(d => _mapper.Map<DepartmentGetModel>(d));
            var employeeUpdateViewModel = new EmployeeUpdateViewModel
            {
                EmployeeUpdateModel = employeeToUpdate,
                DepartmentGetModels = departmentsToReturn
            };
            ViewData["Id"] = id;
            return View(employeeUpdateViewModel);
        }

        [HttpPost]
        public async Task<IActionResult> Update([FromRoute] int id, EmployeeUpdateModel employeeUpdateModel)
        {
            Expression<Func<Employee, bool>> predicate = d => d.Id == id;
            var department = await _employeeRepository.GetAsync(predicate, null);
            if (department is null)
                return NotFound();
            _mapper.Map(employeeUpdateModel, department);
            _employeeRepository.Update(department);
            await _employeeRepository.SaveAsync();
            return RedirectToAction("Index");
        }

        [HttpGet]
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
