using Microsoft.AspNetCore.Mvc;
using Project.Core.Domain.Students;
using Project.Services.Students;
using Project.Web.Models.Students;
using System.Linq;

namespace Project.Web.Controllers
{
    public class StudentController : Controller
    {
        #region Fields

        private readonly IStudentService _studentService;

        #endregion

        #region Constructor

        public StudentController(IStudentService studentService)
        {
            _studentService = studentService;
        }

        #endregion

        #region Methods

        [HttpGet]
        public IActionResult Index()
        {
            return RedirectToAction("List");
        }

        [HttpGet]
        public IActionResult List()
        {
            var students = _studentService.GetStudents();
            var list = students.Select(student =>
            {
                var model = new StudentModel() { Id = student.Id, Name = student.Name, State = student.State, City = student.City };
                return model;
            });
            return View(list);
        }

        [HttpGet]
        public IActionResult Create()
        {
            StudentModel model = new StudentModel();
            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(StudentModel model)
        {
            if (ModelState.IsValid)
            {
                var entity = new Student() { Name = model.Name, City = model.City, State = model.State };
                _studentService.InsertStudent(entity);
                return RedirectToAction("List");
            }
            return View(model);
        }

        [HttpGet]
        public IActionResult Edit(int id)
        {
            var entity = _studentService.GetStudent(id);

            if (entity == null)
            {
                return RedirectToAction("List");
            }

            StudentModel model = new StudentModel()
            {
                Id = entity.Id,
                Name = entity.Name,
                City = entity.City,
                State = entity.City
            };

            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(StudentModel model)
        {
            if (ModelState.IsValid)
            {
                var entity = _studentService.GetStudent(model.Id);
                if (entity == null)
                {
                    return RedirectToAction("List");
                }

                entity.Name = model.Name;
                entity.City = model.City;
                entity.State = model.State;

                _studentService.UpdateStudent(entity);
                return RedirectToAction("List");
            }
            return View(model);
        }

        #endregion
    }
}
