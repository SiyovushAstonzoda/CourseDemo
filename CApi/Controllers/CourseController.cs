using Domain.DTOs.CourseDto;
using Infrastructure.Services;
using Microsoft.AspNetCore.Mvc;

namespace CApi.Controllers;

[ApiController]
[Route("[controller]")]
public class CourseController :ControllerBase
{
    private readonly CourseService _courseService;

	public CourseController(CourseService courseService)
	{
		_courseService = courseService;
	}

	[HttpPost("Add Course")]
	public async Task<string> AddCourse(AUCourseDto course)
	{
		return await _courseService.AddCourseAsync(course);
	}

	[HttpPut("Update Course")]
	public async Task<string> UpdateCourse(AUCourseDto course)
	{
		return await _courseService.UpdateCourseAsync(course);
	}

	[HttpDelete("Delete Course")]
	public async Task<string> DeleteCourse(int id)
	{
		return await _courseService.DeleteCourseAsync(id);
	}

	[HttpGet("Get all Courses")]
	public async Task<IEnumerable<GCourseDto>> GetAllCourse()
	{
		return await _courseService.GetAllCoursesAsync();
	}

	[HttpGet("Get Course bu Id")]
	public async Task<GCourseDto> GetCourseById(int id)
	{
		return await _courseService.GetCourseByIdAsync(id);
	}
}
