using AutoMapper;
using ExamWeb.Repositories.GenericRepository;
using ExamWeb.Entities;
using ExamWeb.Models;
using Microsoft.AspNetCore.Mvc;
using System.Linq.Expressions;

namespace ExamWeb.Controllers
{
    public class DepartmentController : Controller
    {
        private readonly IGenericRepository<Department> _departmentRepository;
        private readonly IMapper _mapper;

        public DepartmentController(IGenericRepository<Department> departmentRepository, IMapper mapper)
        {
            _departmentRepository = departmentRepository;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var departments = await _departmentRepository.GetAsync(null, null, null);
            var departmentsToReturn = departments.Select(d => _mapper.Map<DepartmentGetModel>(d));
            return View(departmentsToReturn);
        }

        [HttpGet]
        public async Task<IActionResult> Single([FromRoute] int id)
        {
            Expression<Func<Department, bool>> predicate = d => d.Id == id;
            var department = await _departmentRepository.GetAsync(predicate, null);
            var departmentToReturn = _mapper.Map<DepartmentGetModel>(department);
            return View(departmentToReturn);
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(DepartmentCreateModel departmentCreateModel)
        {
            var departmentToCreate = _mapper.Map<Department>(departmentCreateModel);
            await _departmentRepository.InsertAsync(departmentToCreate);
            await _departmentRepository.SaveAsync();
            return RedirectToAction("Index");
        }

        [HttpGet]
        public async Task<IActionResult> Update([FromRoute] int id)
        {
            Expression<Func<Department, bool>> predicate = d => d.Id == id;
            var department = await _departmentRepository.GetAsync(predicate, null);
            if (department is null)
                return NotFound();
            var departmentToUpdate = _mapper.Map<DepartmentUpdateModel>(department);
            ViewData["Id"] = id;
            return View(departmentToUpdate);
        }

        [HttpPost]
        public async Task<IActionResult> Update([FromRoute] int id, DepartmentUpdateModel departmentUpdateModel)
        {
            Expression<Func<Department, bool>> predicate = d => d.Id == id;
            var department = await _departmentRepository.GetAsync(predicate, null);
            if (department is null)
                return NotFound();
            _mapper.Map(departmentUpdateModel, department);
            _departmentRepository.Update(department);
            await _departmentRepository.SaveAsync();
            return RedirectToAction("Index");
        }

        [HttpGet]
        public async Task<IActionResult> Delete([FromRoute] int id)
        {
            Expression<Func<Department, bool>> predicate = d => d.Id == id;
            var department = await _departmentRepository.GetAsync(predicate, null);
            if (department is null)
                return NotFound();

            _departmentRepository.Delete(department);
            await _departmentRepository.SaveAsync();
            return RedirectToAction("Index");
        }
    }
}
