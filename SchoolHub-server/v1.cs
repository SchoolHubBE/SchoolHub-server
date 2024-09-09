namespace SchoolHub_server
{
    public class v1
    {
        public string Status { get; set; }
        public string Version { get; set; }

        public v1()
        {
            Status = "OK";
            Version = Environment.GetEnvironmentVariable("SCHOOLHUB_VERSION") ?? "Unknown";
        }
    }
}
