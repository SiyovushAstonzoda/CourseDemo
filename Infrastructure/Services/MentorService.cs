using Dapper;
using Domain.DTOs.MentorDto;
using Infrastructure.Context;

namespace Infrastructure.Services;

public class MentorService
{
    private readonly DataContext _context;

    public MentorService(DataContext context)
    {
        _context = context;
    }

    //Add Mentor
    public async Task<string> AddMentorAsync(AUMentorDto mentor)
    {
        using (var conn = _context.CreateConnection()) 
        {
            var command = " insert into mentors (firstname, lastname, email, phone, address, city) " +
                          " values (@FirstName, @LastName, @Email, @Phone, @Address, @City);";

            var result = await conn.ExecuteAsync(command, new
            {
                FirstName = mentor.FirstName,
                LastName = mentor.LastName,
                Email = mentor.Email,
                Phone = mentor.Phone,
                Address = mentor.Address,
                City = mentor.City,
            });

            return $"Successfully added {result} mentor(s)";
        }
    }

    //Update Mentor
    public async Task<string> UpdateMentorAsync(AUMentorDto mentor)
    {
        using (var conn = _context.CreateConnection()) 
        {
            var command = " update mentors " +
                          " set firstname = @FirstName, lastname = @LastName, email = @Email, phone = @Phone, address = @Address, city = @City " +
                          " where id = @Id;";

            var result = await conn.ExecuteAsync(command, new
            {
                Id = mentor.Id,
                FirstName = mentor.FirstName,
                LastName = mentor.LastName,
                Email = mentor.Email,
                Phone = mentor.Phone,
                Address = mentor.Address,
                City = mentor.City,
            });

            return $"Successfully updated {result} mentor(s)";
        }
    }

    //Delete Mentor
    public async Task<string> DeleteMentorAsync(int id)
    {
        using (var conn = _context.CreateConnection()) 
        {
            var command = " delete from mentors " +
                          " where id = @Id;";

            var result = await conn.ExecuteAsync(command, new
            {
                Id = id,
            });

            return $"Successfully deleted {result} mentor(s)";
        }
    }

    //Get all Mentors
    public async Task<IEnumerable<GMentorDto>> GetAllMentorsAsync()
    {
        using (var conn = _context.CreateConnection()) 
        {
            var command = " select * " +
                          " from mentors;";

            var result = await conn.QueryAsync<GMentorDto>(command);

            return result;
        }
    }

    //Get Mentor by Id
    public async Task<GMentorDto> GetMentorByIdAsync(int id)
    {
        using (var conn = _context.CreateConnection()) 
        {
            var command = " select * from mentors " +
                          " where id = @Id;";

            var result = await conn.QuerySingleOrDefaultAsync<GMentorDto>(command, new
            {
                Id = id
            });

            return result;
        }
    }
}
