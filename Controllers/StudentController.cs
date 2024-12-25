using APIDemoStudent.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using System;

namespace APIDemoStudent.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class StudentController : ControllerBase
    {

        public readonly IStudentRepository StudentRepository;

        public StudentController(IStudentRepository studentRepository)
        {
            this.StudentRepository = studentRepository;

        }


        [HttpGet("{search}")]

        public async Task<ActionResult<IEnumerable<Student>>> Search(string name, Gender? gender) //Uses name and gender as arguments to search
        {
            
            try
            {
                var result = await StudentRepository.Search(name, gender); //Gets results for each using gender and name

                if (result.Any()) //if the results  is any of the name and gender that exist
                {
                    return Ok(result);

                }
                return NotFound();


            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                    "Error retriveing datafrom database");

            }
        }


        [HttpGet]
        public async Task<ActionResult> GetStudents()
        {
            try
            {
                return Ok(await StudentRepository.GetStudents());
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                    "Error retriveing datafrom database");
            }
        }


        [HttpGet("id:int")]
        public async Task<ActionResult<Student>> GetStudent(int id) //requests id
        {
            try
            {
                var result = await StudentRepository.GetStudent(id); //returns only the entry representing that id

                if(result == null)
                {
                    return NotFound();
                }
                return result;
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                    "Error retriveing datafrom database");
            }

        }


        [HttpPost]
        public async Task<ActionResult<Student>> CreateStudent(Student student)
        {
            try
            {

                if (student == null)
                {
                    return BadRequest();
                }
                var stu = await StudentRepository.GetStudentByEmail(student.Email);

                if (stu != null)
                {
                    ModelState.AddModelError("Email", "Student email already in use");
                    return BadRequest(ModelState);
                }

                var createdStudent = await StudentRepository.AddStudent(student);

                return CreatedAtAction(nameof(CreateStudent),
                    new { id = createdStudent.StudentId}, createdStudent); //Automatically provides srudentI

            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                    "Error creating new student record");
            }
        }


        [HttpPut("{id:int}")]
        public async Task<ActionResult<Student>> UpdateStudent(int id, Student student)
        {
            try
            {
                if(id != student.StudentId) //If the student id doesn't match with the id we are trying to update then return bad request
                    return BadRequest("Student ID mismatch");

                var studentToUpdate = await StudentRepository.GetStudent(id);

                if (studentToUpdate == null)
                {
                    return NotFound($"Student with id = {id} not found");
                }

                return await StudentRepository.UpdateStudent(student);

             
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                    "Error retriveing datafrom database");
            }
        }

        [HttpDelete("{id:int}")]
        public async Task<ActionResult> DeleteStudent(int id)
        {
            try
            {
                var studentDelete = await StudentRepository.GetStudent(id);

                if(studentDelete == null)
                {
                    return BadRequest($"Student with Id = {id} not found");
                }

                await StudentRepository.DeleteStudent(id);

                return Ok($"Student with id = {id} deleted");

            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                    "Error deleting Student record");
            }
        }
   
    }
}
