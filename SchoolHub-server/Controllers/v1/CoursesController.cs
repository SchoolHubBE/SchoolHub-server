using Microsoft.AspNetCore.Mvc;

namespace SchoolHub_server.Controllers.v1;

[ApiController]
[Route("v1/courses")]
public class CoursesController : ControllerBase
{
    [HttpGet]
    public IEnumerable<Course> Get()
    {
        return new[]
        {
            new Course { Id = 1, Name = "Math" },
            new Course { Id = 2, Name = "Science" },
            new Course { Id = 3, Name = "English" },
            new Course { Id = 4, Name = "History" },
        };
    }
}

public class Course
{
    public required int Id { get; set; }
    public required string Name { get; set; }
}
