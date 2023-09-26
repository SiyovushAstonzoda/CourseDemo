using Domain.DTOs.StudentDto;
using Infrastructure.Services;
using Microsoft.AspNetCore.Mvc;

namespace CApi.Controllers;

[ApiController]
[Route("[controller]")]
public class StudentController : ControllerBase
{
    private readonly StudentService _student;

    public StudentController(StudentService student)
    {
        _student = student;
    }

    [HttpPost("Add Student")]
    public async Task<string> AddStudent(AUStudentDto student)
    {
        return await _student.AddStudentAsync(student);
    }

    [HttpPut("Update Student")]
    public async Task<string> UpdateStudent(AUStudentDto student)
    {
        return await _student.UpdateStudentAsync(student);
    }

    [HttpDelete("Delete Student")]
    public async Task<string> DeleteStudent(int id)
    {
        return await _student.DeleteStudentAsync(id);
    }

    [HttpGet("Get all Students")]
    public async Task<IEnumerable<GStudentDto>> GetAllStudents()
    {
        return await _student.GetAllStudentsAsync();
    }

    [HttpGet("Get Student by Id")]
    public async Task<GStudentDto> GetStudentById(int id)
    {
        return await _student.GetStudentByIdAsync(id);
    }
}
