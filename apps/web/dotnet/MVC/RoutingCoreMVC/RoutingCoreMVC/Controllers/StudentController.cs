using Microsoft.AspNetCore.Mvc;
using RoutingCoreMVC.Models;

namespace RoutingCoreMVC.Controllers
{
    public class StudentController : Controller
    {
        //This is going to be our data source
        //In Real-Time you will get the data from the database
        static List<Student> students = new List<Student>()
        {
            new Student() { Id = 1, Name = "Pranaya" },
            new Student() { Id = 2, Name = "Priyanka" },
            new Student() { Id = 3, Name = "Anurag" },
            new Student() { Id = 4, Name = "Sambit" }
        };
        //This method is going to return all the Students
        //URL Pattern: /Student/All
        [Route("Student/All")]
        public List<Student> GetAllStudents()
        {
            return students;
        }
        //This method is going to return a student based on the student id
        //URL Pattern: /Student/1/Details
        [Route("Student/{studentID:alphanumeric}/Details")]
        public Student GetStudentById(int studentId)
        {
            Student? studentDetails = students.FirstOrDefault(s => s.Id == studentId);
            return studentDetails ?? new Student();
        }
        //This method is going to return the courses of a student based on the student id
        //URL Pattern: /Student/1/Courses
        [Route("Student/{studentID:alphanumeric}/Courses")]
        public List<string> GetStudentCourses(int studentID)
        {
            //Real-Time you will get the courses from database, here we have hardcoded the data
            List<string> CourseList = new List<string>();
            if (studentID == 1)
                CourseList = new List<string>() { "ASP.NET Core", "C#.NET", "SQL Server" };
            else if (studentID == 2)
                CourseList = new List<string>() { "ASP.NET Core MVC", "C#.NET", "ADO.NET Core" };
            else if (studentID == 3)
                CourseList = new List<string>() { "ASP.NET Core WEB API", "C#.NET", "Entity Framework Core" };
            else
                CourseList = new List<string>() { "Bootstrap", "jQuery", "AngularJs" };

            return CourseList;
        }
    }
}
