using Microsoft.AspNetCore.Mvc;

namespace SchoolHub_server.Controllers.v1;

[ApiController]
[Route("v1/platform-quick-links")]
public class PlatformQuickLinksController : ControllerBase
{
    private static readonly PlatformQuickLink[] PlaceHolderPlatformQuickLinks =
    {
        new() { Id = 1, Name = "WatWat", Description = "", Url = "https://www.watwat.be/" },
        new() { Id = 2, Name = "Zelfmoordlijn", Description = "", Url = "https://www.zelfmoord1813.be/" },
        new() { Id = 3, Name = "Diddit", Description = "", Url = "https://www.diddit.be/" }
    };
    
    [HttpGet]
    public IEnumerable<PlatformQuickLink> Get()
    {
        return PlaceHolderPlatformQuickLinks;
    }

    [HttpGet("{id}")]
    public PlatformQuickLink? Get(int id)
    {
        return PlaceHolderPlatformQuickLinks.FirstOrDefault(c => c.Id == id);
    }
}

public class PlatformQuickLink
{
    public required int Id { get; set; }
    public required string Name { get; set; }
    public required string Description { get; set; }
    public required string Url { get; set; }
}
