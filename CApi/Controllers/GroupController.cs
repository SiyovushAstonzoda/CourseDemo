using Domain.DTOs.GroupDto;
using Infrastructure.Services;
using Microsoft.AspNetCore.Mvc;

namespace CApi.Controllers;

[ApiController]
[Route("[controller]")]
public class GroupController : ControllerBase
{
    private readonly GroupService _group;

    public GroupController(GroupService group)
    {
        _group = group;
    }

    [HttpPost("Add Group")]
    public async Task<string> AddGroup(AUGroupDto group)
    {
        return await _group.AddGroupAsync(group);
    }

    [HttpPut("Update Group")]
    public async Task<string> UpdateGroup(AUGroupDto group)
    {
        return await _group.UpdateGroupAsync(group);
    }

    [HttpDelete("Delete Group")]
    public async Task<string> DeleteGroup(int id)
    {
        return await _group.DeleteCourseAsync(id);
    }

    [HttpGet("Get all Groups")]
    public async Task<IEnumerable<GGroupDto>> GetAllGroups()
    {
        return await _group.GetAllGroupsAsync();
    }

    [HttpGet("Get Group by Id")]
    public async Task<GGroupDto> GetGroupById(int id)
    {
        return await _group.GetGroupByIdAsync(id);
    }

    [HttpGet("Get Groups with CourseName")]
    public async Task<IEnumerable<GGroupsWithCourseName>> GetGroupsWithCourseName()
    {
        return await _group.GetGroupsWithCourseNameAsync();
    }
}
