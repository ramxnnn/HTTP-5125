using Cumulative_Project1.Models;
using Microsoft.AspNetCore.Mvc;

namespace Cumulative_Project1.Controllers
{
    public class TeacherPageController : Controller
    {
        private readonly TeacherAPIController _api;

        // Dependency injection of the TeacherAPIController
        public TeacherPageController(TeacherAPIController api)
        {
            _api = api;
        }

        // GET : TeacherPage/List
        public IActionResult List()
        {
            // Retrieve a list of teachers via the API
            List<Teacher> teachers = _api.ListTeachers();
            return View(teachers); // Return a view with the list of teachers
        }

        // GET : TeacherPage/Show/{id}
        public IActionResult Show(int id)
        {
            // Retrieve a specific teacher via the API
            Teacher selectedTeacher = _api.FindTeacher(id);
            return View(selectedTeacher); // Return a view with the selected teacher details
        }
    }
}
