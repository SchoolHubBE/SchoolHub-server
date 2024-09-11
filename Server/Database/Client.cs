using Npgsql;

namespace SchoolHub_server.Database;

public static class Client
{
    private static NpgsqlConnection? _conn;

    public static void Connect()
    {
        if (_conn != null) return;

        var csb = new NpgsqlConnectionStringBuilder
        {
            Host = Environment.GetEnvironmentVariable("POSTGRES_HOST") ?? "127.0.0.1",
            Port = int.Parse(Environment.GetEnvironmentVariable("POSTGRES_PORT") ?? "5432"),
            Database = Environment.GetEnvironmentVariable("POSTGRES_DB") ?? "postgres",
            Username = Environment.GetEnvironmentVariable("POSTGRES_USER") ?? "postgres",
            Password = Environment.GetEnvironmentVariable("POSTGRES_PASSWORD") ?? "pwd",
        };

        _conn = new NpgsqlConnection(csb.ToString());
        _conn.Open();
        Console.WriteLine($"Connected to database: {csb.Database}");
    }

    public static NpgsqlConnection Connection => _conn ?? throw new InvalidOperationException("Database connection is not initialized");

    public static void Close()
    {
        if (_conn != null)
        {
            _conn.Close();
            _conn = null;
        }
    }
}
