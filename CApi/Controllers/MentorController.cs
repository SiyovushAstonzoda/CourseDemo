using Domain.DTOs.MentorDto;
using Infrastructure.Services;
using Microsoft.AspNetCore.Mvc;

namespace CApi.Controllers;

[ApiController]
[Route("[controller]")]
public class MentorController : ControllerBase
{
    private readonly MentorService _mentor;

    public MentorController(MentorService mentor)
    {
        _mentor = mentor;
    }

    [HttpPost("Add Mentor")]
    public async Task<string> AddMentor(AUMentorDto mentor)
    {
        return await _mentor.AddMentorAsync(mentor);
    }

    [HttpPut("Update Mentor")]
    public async Task<string> UpdateMentor(AUMentorDto mentor)
    {
        return await _mentor.UpdateMentorAsync(mentor);
    }

    [HttpDelete("Delete Mentor")]
    public async Task<string> DeleteMentor(int id)
    {
        return await _mentor.DeleteMentorAsync(id);
    }

    [HttpGet("Get all Mentors")]
    public async Task<IEnumerable<GMentorDto>> GetAllMentors()
    {
        return await _mentor.GetAllMentorsAsync();
    }

    [HttpGet("Get Mentor by Id")]
    public async Task<GMentorDto> GetMentorById(int id)
    {
        return await _mentor.GetMentorByIdAsync(id);
    }
}
