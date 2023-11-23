using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace WebAPI_2.Controllers
{
    [Route("api/[controller]")] // Defines the route for the controller
    [ApiController] // Indicates that this class is a controller
    public class StudentController : ControllerBase
    {
        // Declares a static list to store student data
        static List<Student> students = new List<Student>();

        // GET: api/<StudentController>
        [HttpGet] // Specifies that this method handles HTTP GET requests
        public IEnumerable<Student> Get() // Retrieves all students from the list
        {
            // Returns all students in the list
            return students;
        }

        // GET api/<StudentController>/5
        [HttpGet("{id}")] // Specifies that this method handles HTTP GET requests with an ID parameter
        public Student Get(int id) // Retrieves a specific student based on the ID
        {
            // Finds the student with the specified ID using LINQ
            Student student = students.FirstOrDefault(s => s.Id == id);

            // Returns the found student or null if not found
            return student;
        }

        // POST api/<StudentController>
        [HttpPost] // Specifies that this method handles HTTP POST requests
        public void Post([FromBody] Student value) // Adds a new student to the list
        {
            // Adds the provided student object to the list
            students.Add(value);
        }

        // PUT api/<StudentController>/5
        [HttpPut("{id}")] // Specifies that this method handles HTTP PUT requests with an ID parameter
        public void Put(int id, [FromBody] Student value) // Updates an existing student in the list
        {
            // Finds the index of the student with the specified ID using LINQ
            int index = students.FindIndex(s => s.Id == id);

            // Updates the student's data if the student exists
            if (index >= 0)
            {
                students[index] = value;
            }
        }

        // DELETE api/<StudentController>/5
        [HttpDelete("{id}")] // Specifies that this method handles HTTP DELETE requests with an ID parameter
        public void Delete(int id) // Removes a student from the list based on the ID
        {
            // Removes all students with the specified ID using LINQ
            students.RemoveAll(s => s.Id == id);
        }
    }
}
