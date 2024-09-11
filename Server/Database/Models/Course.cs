namespace SchoolHub_server.Database.Models;

public abstract class Course
{
    public required string Name { get; set; }
    public required string Description { get; set; }
    public required User Teacher { get; set; }
    public List<User> Students { get; set; } = [];
    
    public DateTime? CreationDate { get; set; }
    public DateTime? UpdatedDate { get; set; }
}
