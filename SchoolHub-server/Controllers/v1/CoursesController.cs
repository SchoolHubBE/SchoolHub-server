using Microsoft.AspNetCore.Mvc;

namespace SchoolHub_server.Controllers.v1;

[ApiController]
[Route("v1/courses")]
public class CoursesController : ControllerBase
{
    private static readonly Course[] PlaceHolderCourses =
    [
        new() { Id = 1, Name = "Math" },
        new() { Id = 2, Name = "Science" },
        new() { Id = 3, Name = "English" },
        new() { Id = 4, Name = "History" }
    ];
    
    [HttpGet]
    public IEnumerable<Course> Get()
    {
        return PlaceHolderCourses;
    }

    [HttpGet("{courseId}/{topicName}")]
    public Course? GetCourse(int courseId, string topicName)
    {
        return PlaceHolderCourses.FirstOrDefault(c => c.Id == courseId);
    }
}

public class Course
{
    public required int Id { get; set; }
    public required string Name { get; set; }
}