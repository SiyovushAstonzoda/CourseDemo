using Dapper;
using Domain.DTOs.GroupDto;
using Infrastructure.Context;

namespace Infrastructure.Services;

public class GroupService
{
    private readonly DataContext _context;

    public GroupService(DataContext context)
    {
        _context = context;
    }


    //Add Group
    public async Task<string> AddGroupAsync(AUGroupDto group)
    {
        using (var conn = _context.CreateConnection())
        {
            var command = " insert into groups (groupname, groupdescription, courseid) " +
                          " values (@GroupName, @GroupDescription, @CourseId);";

            var result = await conn.ExecuteAsync(command, new
            {
                GroupName = group.GroupName,
                GroupDescription = group.GroupDescription,
                CourseId = group.CourseId
            });

            return $"Successfully added {result} group(s)";
        }
    }

    //Update Group
    public async Task<string> UpdateGroupAsync(AUGroupDto group)
    {
        using (var conn = _context.CreateConnection()) 
        {
            var command = " update groups " +
                          " set groupname = @GroupName, groupdescription = @GroupDescription, courseid = @CourseId " +
                          " where id = @Id;";

            var result = await conn.ExecuteAsync(command, new
            {
                GroupName = group.GroupName,
                GroupDescription = group.GroupDescription,
                CourseId = group.CourseId,
                Id = group.Id
            });

            return $"Successfully updated {result} group(s)";
        }
    }

    //Delete Course
    public async Task<string> DeleteCourseAsync(int id)
    {
        using (var conn = _context.CreateConnection()) 
        {
            var command = " delete from groups " +
                          " where id = @Id;";

            var result = await conn.ExecuteAsync(command, new
            {
                Id = id
            });

            return $"Successfully deleted {result} group(s)";
        }
    }

    //Get all Groups
    public async Task<IEnumerable<GGroupDto>> GetAllGroupsAsync()
    {
        using (var conn = _context.CreateConnection())
        {
            var command = " select * " +
                          " from groups;";

            var result = await conn.QueryAsync<GGroupDto>(command);

            return result;
        }
    }

    //Get Group by Id
    public async Task<GGroupDto> GetGroupByIdAsync(int id)
    {
        using (var conn = _context.CreateConnection())
        {
            var command = " select * from groups " +
                          " where id = @Id;";

            var result = await conn.QuerySingleOrDefaultAsync<GGroupDto>(command, new
            {
                Id = id
            });

            return result;
        }
    }

    //Get Groups with CourseName
    public async Task<IEnumerable<GGroupsWithCourseName>> GetGroupsWithCourseNameAsync()
    {
        using (var conn = _context.CreateConnection())
        {
            var command = " select g.groupname, g.groupdescription, c.coursename " +
                          " from groups g " +
                          " join courses c " +
                          " on g.courseid = c.id;";

            var result = await conn.QueryAsync<GGroupsWithCourseName>(command);

            return result;
        }
    }
}
