namespace Domain.DTOs.CourseDto;

public class GCourseDto
{
    public int Id { get; set; }
    public string CourseName { get; set; }
    public string CourseDescription { get; set; }
    public double Fee { get; set; }
    public int Duration { get; set; }
    public DateTime StartDate { get; set; }
    public DateTime EndDate { get; set; }
    public int StudentLimit { get; set; }
}
