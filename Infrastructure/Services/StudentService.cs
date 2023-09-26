using Dapper;
using Domain.DTOs.StudentDto;
using Infrastructure.Context;

namespace Infrastructure.Services;

public class StudentService
{
    private readonly DataContext _context;

    public StudentService(DataContext context)
    {
        _context = context;
    }

    //Add Student
    public async Task<string> AddStudentAsync(AUStudentDto student)
    {
        using (var conn  = _context.CreateConnection()) 
        {
            var command = " insert into students (firstname, lastname, email, phone, address, city) " +
                          " values (@FirstName, @LastName, @Email, @Phone, @Address, @City);";

            var result = await conn.ExecuteAsync(command, new
            {
                FirstName = student.FirstName,
                LastName = student.LastName,
                Email = student.Email,
                Phone = student.Phone,
                Address = student.Address,
                City = student.City,
            });

            return $"Successfully added {result} student(s)";
        }
    }

    //Update Student
    public async Task<string> UpdateStudentAsync(AUStudentDto student)
    {
        using (var conn = _context.CreateConnection()) 
        {
            var command = " update students " +
                          " set firstname = @FirstName, lastname = @LastName, email = @Email, phone = @Phone, address = @Address, city = @City " +
                          " where id = @Id;";

            var result = await conn.ExecuteAsync(command, new
            {
                FirstName = student.FirstName,
                LastName = student.LastName,
                Email = student.Email,
                Phone = student.Phone,
                Address = student.Address,
                City = student.City,
                Id = student.Id
            });

            return $"Successfully updated {result} student(s)";
        }
    }
    
    //Delete Student
    public async Task<string> DeleteStudentAsync(int id)
    {
        using (var conn = _context.CreateConnection()) 
        {
            var command = " delete from students " +
                          " where id = @Id;";

            var result = await conn.ExecuteAsync(command, new
            {
                Id = id
            });

            return $"Successfully deleted {result} student(s)";
        }
    }

    //Get all Students
    public async Task<IEnumerable<GStudentDto>> GetAllStudentsAsync()
    {
        using (var conn = _context.CreateConnection()) 
        {
            var command = " select * " +
                          " from students;";

            var result = await conn.QueryAsync<GStudentDto>(command);

            return result;
        }
    }

    //Get Student by Id
    public async Task<GStudentDto> GetStudentByIdAsync(int id)
    {
        using (var conn = _context.CreateConnection())
        {
            var command = " select * from students " +
                          " where id = @Id;";

            var result = await conn.QuerySingleOrDefaultAsync<GStudentDto>(command, new
            {
                Id = id
            });

            return result;
        }
    }
}
