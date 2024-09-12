using Npgsql;

namespace SchoolHub_server.Database.Models
{
    public struct User
    {
        public string Username { get; set; }
        public string Password { get; set; }

        public string Role { get; set; }
        public string NationalRegistrationNumber { get; set; }

        public string Country { get; set; }
        public string ZipCode { get; set; }
        public string City { get; set; }
        public string Street { get; set; }
        public string HouseNumber { get; set; }
        public string FlatNumber { get; set; }
        
        public DateTime? DateOfBirth { get; set; }
        public string PlaceOfBirth { get; set; }
        
        public Gender Gender { get; set; }
        
        public string Language { get; set; }
        
        public DateTime? RegistrationDate { get; set; }
        public DateTime? LastLoginDate { get; set; }

        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string ExtraNames { get; set; }
        public string Email { get; set; }

        public string PhoneNumber { get; set; }
    }

    public enum Gender
    {
        Male,
        Female
    }

    public static class UserExtensions
    {
        private static string CreateTableString { get; } = @"
            CREATE TABLE users (
                id SERIAL PRIMARY KEY,
                username VARCHAR(32) NOT NULL UNIQUE,
                password VARCHAR(128) NOT NULL,
                role VARCHAR(32) NOT NULL,
                national_registration_number VARCHAR(32) NOT NULL,

                country VARCHAR(64) NOT NULL,
                zip_code VARCHAR(16) NOT NULL,
                city VARCHAR(64) NOT NULL,
                street VARCHAR(128) NOT NULL,
                house_number VARCHAR(16) NOT NULL,
                flat_number VARCHAR(16) NOT NULL,

                date_of_birth DATE,
                place_of_birth VARCHAR(128),
                
                gender VARCHAR(16) NOT NULL,
                
                language VARCHAR(16) NOT NULL,
                
                registration_date TIMESTAMP NOT NULL DEFAULT CURRENT_TIMESTAMP,
                last_login_date TIMESTAMP,

                first_name VARCHAR(64) NOT NULL,
                last_name VARCHAR(64) NOT NULL,
                extra_names VARCHAR(64),
                email VARCHAR(128) NOT NULL,

                phone_number VARCHAR(32)
            );
        ";
        
        public static void Migrate(NpgsqlConnection connection)
        {
            Console.WriteLine("Migrating User model...");
            using var command = new NpgsqlCommand(CreateTableString, connection);
            command.ExecuteNonQuery();
            Console.WriteLine("User model migrated.");
        }

        public static void CreateUser(NpgsqlConnection connection, User user)
        {
            using var command = new NpgsqlCommand(@"
            INSERT INTO users (
                username, password, role, national_registration_number,
                country, zip_code, city, street, house_number, flat_number,
                date_of_birth, place_of_birth, gender, language,
                registration_date, last_login_date, first_name, last_name, extra_names,
                email, phone_number
            ) VALUES (
                @username, @password, @role, @national_registration_number,
                @country, @zip_code, @city, @street, @house_number, @flat_number,
                @date_of_birth, @place_of_birth, @gender, @language,
                @registration_date, @last_login_date, @first_name, @last_name, @extra_names,
                @email, @phone_number
            );
            ", connection);

            command.Parameters.AddWithValue("username", user.Username);
            command.Parameters.AddWithValue("password", user.Password);
            command.Parameters.AddWithValue("role", user.Role);
            command.Parameters.AddWithValue("national_registration_number", user.NationalRegistrationNumber);

            command.Parameters.AddWithValue("country", user.Country);
            command.Parameters.AddWithValue("zip_code", user.ZipCode);
            command.Parameters.AddWithValue("city", user.City);
            command.Parameters.AddWithValue("street", user.Street);
            command.Parameters.AddWithValue("house_number", user.HouseNumber);
            command.Parameters.AddWithValue("flat_number", user.FlatNumber);

            command.Parameters.AddWithValue("date_of_birth", user.DateOfBirth ?? throw new InvalidOperationException());
            command.Parameters.AddWithValue("place_of_birth", user.PlaceOfBirth);

            command.Parameters.AddWithValue("gender", user.Gender.ToString());
            command.Parameters.AddWithValue("language", user.Language);

            command.Parameters.AddWithValue("registration_date", user.RegistrationDate ?? DateTime.Now);
            command.Parameters.AddWithValue("last_login_date", user.LastLoginDate ?? DateTime.Now);

            command.Parameters.AddWithValue("first_name", user.FirstName);
            command.Parameters.AddWithValue("last_name", user.LastName);
            command.Parameters.AddWithValue("extra_names", user.ExtraNames);
            command.Parameters.AddWithValue("email", user.Email);
            command.Parameters.AddWithValue("phone_number", user.PhoneNumber);

            command.ExecuteNonQuery();
        }

        public static User? GetUserById(NpgsqlConnection connection, int id)
        {
            using var command = new NpgsqlCommand(@"
            SELECT * FROM users WHERE id = @id;
            ", connection);

            command.Parameters.AddWithValue("id", id);

            using var reader = command.ExecuteReader();

            if (reader.Read())
            {
                return new User
                {
                    Username = reader["username"].ToString()!,
                    Password = reader["password"].ToString()!,
                    Role = reader["role"].ToString()!,
                    NationalRegistrationNumber = reader["national_registration_number"].ToString()!,

                    Country = reader["country"].ToString()!,
                    ZipCode = reader["zip_code"].ToString()!,
                    City = reader["city"].ToString()!,
                    Street = reader["street"].ToString()!,
                    HouseNumber = reader["house_number"].ToString()!,
                    FlatNumber = reader["flat_number"].ToString()!,

                    DateOfBirth = reader["date_of_birth"] as DateTime?,
                    PlaceOfBirth = reader["place_of_birth"].ToString()!,

                    Gender = (Gender)Enum.Parse(typeof(Gender), reader["gender"].ToString()!),
                    Language = reader["language"].ToString()!,

                    RegistrationDate = reader["registration_date"] as DateTime?,
                    LastLoginDate = reader["last_login_date"] as DateTime?,

                    FirstName = reader["first_name"].ToString()!,
                    LastName = reader["last_name"].ToString()!,
                    ExtraNames = reader["extra_names"].ToString()!,
                    Email = reader["email"].ToString()!,
                    PhoneNumber = reader["phone_number"].ToString()!
                };
            }

            return null;
        }
    }
}