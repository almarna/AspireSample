using Dapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;

namespace DotnetAspire.WebApi.Controllers;

[ApiController]
[Route("[controller]")]
public class CoursesController(ILogger<CoursesController> logger, SqlConnection sqlConnection) : ControllerBase
{
    [HttpGet(Name = "GetCourses")]
    public IEnumerable<CourseDto> Get()
    {
        logger.LogInformation("Getting courses again!");

        const string sql = "select * from Course";

        try
        {
            var courses = sqlConnection.Query<CourseDto>(sql);
            return courses;
        }
        catch (Exception e)
        {

            logger.LogError(e, "Can not create table!");
            return [];
        }
    }

    public class CourseDto
    {
        public int Id { get; set; }
        public required string Name { get; set; }
        public int HoleCount { get; set; }

    }
}
