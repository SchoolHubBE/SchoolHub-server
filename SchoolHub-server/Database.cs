using Npgsql;

namespace SchoolHub_server;

public static class Database
{
    private static NpgsqlConnection? _conn;

    public static void Connect()
    {
        if (_conn != null) return;
        var host = Environment.GetEnvironmentVariable("POSTGRES_HOST") ?? "127.0.0.1";
        var port = Environment.GetEnvironmentVariable("POSTGRES_PORT") ?? "5432";
        var database = Environment.GetEnvironmentVariable("POSTGRES_DB") ?? "postgres";
        var user = Environment.GetEnvironmentVariable("POSTGRES_USER") ?? "postgres";
        var password = Environment.GetEnvironmentVariable("POSTGRES_PASSWORD") ?? "pwd";

        _conn = new NpgsqlConnection($"Server={host}:{port};User Id={user};Password={password};Database={database};");
        _conn.Open();
        Console.WriteLine($"Connected to database: {database}");
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