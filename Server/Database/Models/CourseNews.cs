namespace SchoolHub_server.Database.Models;

public struct CourseNews(Course course, string title, string content)
{
    public Course Course { get; set; } = course;
    
    
    public string Title { get; set; } = title;
    public string Content { get; set; } = content;

    public DateTime? CreatedDate { get; set; } = null;
    public DateTime? UpdatedDate { get; set; } = null;
}
