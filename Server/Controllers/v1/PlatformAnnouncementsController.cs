using Microsoft.AspNetCore.Mvc;

namespace SchoolHub_server.Controllers.v1;

[ApiController]
[Route("v1/platform-announcements")]
public class PlatformAnnouncementsController : ControllerBase
{
    private static readonly PlatformAnnouncement[] PlaceHolderPlatformAnnouncements =
    {
        new() { Id = 1, Title = "Welkom bij SchoolHub", Description = "SchoolHub, gemaakt door SchoolHubBE, is een platform om studenten en leraren te laten delen. Het is open-source, gratis en makkelijk in te stellen." },
        new() { Id = 2, Title = "SchoolHub is in de nieuwste fase", Description = "SchoolHub is nog zeer nieuw. Onze platform is in de nieuwste fase. Daardoor zullen jullie hoogst waarschijnlijk problemen ondervinden." },
        new() { Id = 3, Title = "Sluit je aan bij onze community", Description = "https://discord.gg/TjAE6PkYs4" }
    };
    
    [HttpGet]
    public IEnumerable<PlatformAnnouncement> Get()
    {
        return PlaceHolderPlatformAnnouncements;
    }

    [HttpGet("{id}")]
    public PlatformAnnouncement? Get(int id)
    {
        return PlaceHolderPlatformAnnouncements.FirstOrDefault(c => c.Id == id);
    }
}

public class PlatformAnnouncement
{
    public required int Id { get; set; }
    public required string Title { get; set; }
    public required string Description { get; set; }
}
