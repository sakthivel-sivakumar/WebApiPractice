using WebApiPractice.DTOs;
using WebApiPractice.Models;

namespace WebApiPractice.Services;

public interface IStudentService
{
    List<StudentDto> GetAllStudents();

    StudentDto? GetStudentById(int id);

    StudentDto AddStudent(CreateStudentDto studentDto);

    StudentDto? UpdateStudent(int id, UpdateStudentDto studentDto);

    bool DeleteStudent(int id);
}