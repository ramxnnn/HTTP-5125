using Cumulative_Project1.Models;
using Microsoft.AspNetCore.Mvc;
using MySql.Data.MySqlClient;

namespace Cumulative_Project1.Controllers
{
    [Route("api/Teacher")]
    [ApiController]
    public class TeacherAPIController : ControllerBase
    {
        private readonly SchoolDbContext _context;

        // Dependency injection of database context
        public TeacherAPIController(SchoolDbContext context)
        {
            _context = context;
        }

        /// <summary>
        /// Returns a list of teachers in the system
        /// </summary>
        [HttpGet]
        [Route("ListTeachers")]
        public List<Teacher> ListTeachers()
        {
            List<Teacher> teachers = new List<Teacher>();

            // Use the correct method AccessDatabase() to get the MySqlConnection
            using (MySqlConnection connection = _context.AccessDatabase())
            {
                connection.Open();
                MySqlCommand command = connection.CreateCommand();
                command.CommandText = "SELECT * FROM teachers";

                using (MySqlDataReader resultSet = command.ExecuteReader())
                {
                    while (resultSet.Read())
                    {
                        Teacher currentTeacher = new Teacher()
                        {
                            TeacherId = Convert.ToInt32(resultSet["teacherid"]),
                            TeacherFirstName = resultSet["teacherfname"].ToString(),
                            TeacherLastName = resultSet["teacherlname"].ToString(),
                            EmployeeNumber = resultSet["employeenumber"].ToString(),
                            HireDate = Convert.ToDateTime(resultSet["hiredate"]),
                            Salary = Convert.ToDecimal(resultSet["salary"])
                        };

                        teachers.Add(currentTeacher);
                    }
                }
            }

            return teachers;
        }

        /// <summary>
        /// Returns a teacher in the database by their ID
        /// </summary>
        [HttpGet]
        [Route("FindTeacher/{id}")]
        public Teacher FindTeacher(int id)
        {
            Teacher selectedTeacher = new Teacher();

            // Use the correct method AccessDatabase() to get the MySqlConnection
            using (MySqlConnection connection = _context.AccessDatabase())
            {
                connection.Open();
                MySqlCommand command = connection.CreateCommand();
                command.CommandText = "SELECT * FROM teachers WHERE teacherid=@id";
                command.Parameters.AddWithValue("@id", id);

                using (MySqlDataReader resultSet = command.ExecuteReader())
                {
                    while (resultSet.Read())
                    {
                        selectedTeacher.TeacherId = Convert.ToInt32(resultSet["teacherid"]);
                        selectedTeacher.TeacherFirstName = resultSet["teacherfname"].ToString();
                        selectedTeacher.TeacherLastName = resultSet["teacherlname"].ToString();
                        selectedTeacher.EmployeeNumber = resultSet["employeenumber"].ToString();
                        selectedTeacher.HireDate = Convert.ToDateTime(resultSet["hiredate"]);
                        selectedTeacher.Salary = Convert.ToDecimal(resultSet["salary"]);
                    }
                }
            }

            return selectedTeacher;
        }
    }
}
