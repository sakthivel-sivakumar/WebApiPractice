using WebApiPractice.Models;

namespace WebApiPractice.Services;

public interface IStudentService
{
    List<Student> GetAllStudents();

    Student? GetStudentById(int id);

    Student AddStudent(Student student);

    Student? UpdateStudent(int id, Student updatedStudent);

    bool DeleteStudent(int id);
}