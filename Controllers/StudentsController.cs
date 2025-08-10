using CRUDAPI.Data;
using CRUDAPI.Model;
using CRUDAPI.Model.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CRUDAPI.Controllers
{
    //localhost:xxxx/api/students
    [Route("api/[controller]")]
    [ApiController]
    public class StudentsController : ControllerBase
    {
        private readonly ApplicationDbContext dbContext;

        public StudentsController(ApplicationDbContext dbContext)
        {
            this.dbContext = dbContext;
        }


        [HttpGet]
        public IActionResult GetAllStudents()
        {
           var allStudent =  dbContext.StudentDb.ToList();
            return Ok(allStudent);
        }

        [HttpGet]
        [Route("{id:guid}")]

        public IActionResult GetStudentById(Guid id) 
        {
            var student = dbContext.StudentDb.Find(id);

            if (student is null)
            {
                return NotFound();
            }
            return Ok(student);
        }

        [HttpPost]
        public IActionResult AddStudent(AddStudentDto addStudentDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var studentEntity = new Student()
            {
                Name = addStudentDto.Name,
                Email = addStudentDto.Email,
                Phone = addStudentDto.Phone,
                Fees = addStudentDto.Fees

            };

            dbContext.StudentDb.Add(studentEntity);
            dbContext.SaveChanges();
            return Ok(studentEntity);
        }

        [HttpPut]
        [Route("{id:guid}")]
        public IActionResult UpdateStudent(Guid id, UpdateStudentDto updateStudentDto)
        {

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var student = dbContext.StudentDb.Find(id);

            if (student is null)
            {
                return NotFound();
            }

            student.Name = updateStudentDto.Name;
            student.Email = updateStudentDto.Email;
            student.Phone = updateStudentDto.Phone;
            student.Fees = updateStudentDto.Fees;

            dbContext.SaveChanges();

            return Ok(student);
        }

        [HttpDelete]
        [Route("{id:guid}")]
        public IActionResult DeleteStudent(Guid id)
        {
            var student = dbContext.StudentDb.Find(id);

            if (student is null)
            {
                return NotFound();
            }

            dbContext.StudentDb.Remove(student);
            dbContext.SaveChanges();

            return Ok("Student Deleted Successfully"); 
        }

    }
}
