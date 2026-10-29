using Microsoft.AspNetCore.Mvc;
using WebApiPractice.DTOs;
using WebApiPractice.Services;

namespace WebApiPractice.Controllers;

[ApiController]
[Route("api/students")]
public class StudentController : ControllerBase
{
    private readonly IStudentService _studentService;

    public StudentController(IStudentService studentService)
    {
        _studentService = studentService;
    }

    // GET: api/students
    [HttpGet]
    public ActionResult<List<StudentDto>> GetAllStudents()
    {
        return Ok(_studentService.GetAllStudents());
    }

    // GET: api/students/1
    [HttpGet("{id}")]
    public ActionResult<StudentDto> GetStudentById(int id)
    {
        var student = _studentService.GetStudentById(id);

        if (student == null)
            return NotFound(new { message = "Student not found." });

        return Ok(student);
    }

    // POST: api/students
    [HttpPost]
    public ActionResult<StudentDto> AddStudent(CreateStudentDto studentDto)
    {
        var createdStudent = _studentService.AddStudent(studentDto);

        return CreatedAtAction(
            nameof(GetStudentById),
            new { id = createdStudent.Id },
            createdStudent);
    }

    // PUT: api/students/1
    [HttpPut("{id}")]
    public ActionResult<StudentDto> UpdateStudent(
        int id,
        UpdateStudentDto studentDto)
    {
        var updatedStudent = _studentService.UpdateStudent(id, studentDto);

        if (updatedStudent == null)
            return NotFound(new { message = "Student not found." });

        return Ok(updatedStudent);
    }

    // DELETE: api/students/1
    [HttpDelete("{id}")]
    public IActionResult DeleteStudent(int id)
    {
        var deleted = _studentService.DeleteStudent(id);

        if (!deleted)
            return NotFound(new { message = "Student not found." });

        return NoContent();
    }
}