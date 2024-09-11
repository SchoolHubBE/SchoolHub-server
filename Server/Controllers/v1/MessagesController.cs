using Microsoft.AspNetCore.Mvc;

namespace SchoolHub_server.Controllers.v1;

[ApiController]
[Route("v1/messages")]
public class MessagesController : ControllerBase
{
    private Message[] _placeHolderMessages =
    [
        new() { Id = 1, From = "john@example.com", To = new[] { "me@example.com" }, Cc = Array.Empty<string>(), Bcc = Array.Empty<string>(), Subject = "Meeting Tomorrow", Content = "Hi, let's meet tomorrow at 2 PM to discuss the project.", Date = "2023-05-15" },
        new() { Id = 2, From = "sarah@example.com", To = new[] { "me@example.com" }, Cc = new[] { "team@example.com" }, Bcc = Array.Empty<string>(), Subject = "Project Update", Content = "Here's the latest update on the project. We're making good progress.", Date = "2023-05-14" },
        new() { Id = 3, From = "mike@example.com", To = new[] { "me@example.com" }, Cc = Array.Empty<string>(), Bcc = new[] { "manager@example.com" }, Subject = "Question about API", Content = "I have a question about the new API. Can we schedule a call?", Date = "2023-05-13" },
    ];

    [HttpGet]
    public IEnumerable<Message> Get()
    {
        return _placeHolderMessages;
    }

    [HttpGet("{id}")]
    public Message? GetMessage(int id)
    {
        return _placeHolderMessages.FirstOrDefault(c => c.Id == id);
    }

    [HttpPost]
    public IActionResult Post([FromBody]CreateMessageRequest request)
    {
        var message = new Message
        {
            Id = _placeHolderMessages.Length + 1,
            From = "me@example.com",
            To = request.To,
            Cc = request.Cc,
            Bcc = request.Bcc,
            Subject = request.Subject,
            Content = request.Content,
            Date = DateTime.Now.ToString("yyyy-MM-dd"),
        };

        _placeHolderMessages = _placeHolderMessages.Concat([message]).ToArray();
        
        Console.WriteLine($"""New message created: {message}""");

        return CreatedAtAction(nameof(GetMessage), new { id = message.Id }, message);
    }
}

public record CreateMessageRequest
{
    public required string[] To { get; set; }
    public required string[] Cc { get; set; }
    public required string[] Bcc { get; set; }
    public required string Subject { get; set; }
    public required string Content { get; set; }
}

public record Message
{
    public required int Id { get; init; }
    public required string From { get; set; }
    public required string[] To { get; set; }
    public required string[] Cc { get; set; }
    public required string[] Bcc { get; set; }
    public required string Subject { get; set; }
    public required string Content { get; set; }
    public required string Date { get; set; }
}
