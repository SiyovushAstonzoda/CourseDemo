using Dapper;
using Domain.DTOs.CourseDto;
using Infrastructure.Context;

namespace Infrastructure.Services;

public class CourseService
{
    private readonly DataContext _context;

    public CourseService(DataContext context)
    {
        _context = context;
    }

    //Add Course
    public async Task<string> AddCourseAsync(AUCourseDto course)
    {
        using (var conn = _context.CreateConnection())
        {
            var command = " insert into courses (coursename, coursedescription, fee, duration, startdate, enddate, studentlimit) " +
                          " values (@CourseName, @CourseDescription, @Fee, @Duration, @StartDate, @EndDate, @StudentLimit);";

            var result = await conn.ExecuteAsync(command, new
            {
                CourseName = course.CourseName,
                CourseDescription = course.CourseDescription,
                Fee = course.Fee,
                Duration = course.Duration,
                StartDate = course.StartDate,
                EndDate = course.EndDate,
                StudentLimit = course.StudentLimit
            });

            return $"Successfully added {result} course(s)";
        }
    }

    //Update Course
    public async Task<string> UpdateCourseAsync(AUCourseDto course)
    {
        using (var conn = _context.CreateConnection())
        {
            var command = " update courses " +
                          " set coursename = @CourseName, coursedescription = @CourseDescription, fee = @Fee, duration = @Duration, startdate = @StartDate, enddate = @EndDate, studentlimit = @StudentLimit " +
                          " where id = @Id;";

            var result = await conn.ExecuteAsync(command, new
            {
                Id = course.Id,
                CourseName = course.CourseName,
                CourseDescription = course.CourseDescription,
                Fee = course.Fee,
                Duration = course.Duration,
                StartDate = course.StartDate,
                EndDate = course.EndDate,
                StudentLimit = course.StudentLimit
            });

            return $"Successfully updated {result} course(s)";
        }
    }

    //Delete Course
    public async Task<string> DeleteCourseAsync(int id)
    {
        using (var conn = _context.CreateConnection()) 
        {
            var command = " delete from courses " +
                          " where id = @Id;";

            var result = await conn.ExecuteAsync(command, new
            {
                Id = id
            });

            return $"Successfully deleted {result} course(s)";
        }
    }

    //Get all Courses
    public async Task<IEnumerable<GCourseDto>> GetAllCoursesAsync()
    {
        using (var conn = _context.CreateConnection()) 
        {
            var command = " select * " +
                          " from courses;";

            var result = await conn.QueryAsync<GCourseDto>(command);

            return result;
        }
    }

    //Get Course by Id
    public async Task<GCourseDto> GetCourseByIdAsync(int id)
    {
        using (var conn = _context.CreateConnection())
        {
            var command = " select *  " +
                          " from courses" +
                          " where id = @Id;";

            var result = await conn.QuerySingleOrDefaultAsync<GCourseDto>(command, new
            {
                Id = id
            });

            return result;
        }
    }
}
