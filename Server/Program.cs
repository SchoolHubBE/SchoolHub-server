using SchoolHub_server.Database.Models;

namespace SchoolHub_server
{
    public static class Program
    {
        public static void Main(string[] args)
        {
            DotNetEnv.Env.TraversePath().Load();
            Database.Client.Connect();
            
            if (args.Length == 0)
            {
                StartWebServer();
            }

            else
            {
                var command = args[0];
                switch (command)
                {
                    case "application:serve":
                        StartWebServer();
                        break;
                    case "database:migrate":
                        Database.Client.Migrate();
                        break;
                    case "user:create":
                        CreateUser();
                        break;
                    case "user:remove":
                        RemoveUser();
                        break;
                    case "course:create":
                        CreateCourse();
                        break;
                    case "course:remove":
                        RemoveCourse();
                        break;
                    case "course:add-pupil":
                        AddPupilToCourse();
                        break;
                    default:
                        Console.WriteLine($"Unknown command: {command}");
                        break;
                }
            }
        }

        private static void StartWebServer()
        {
            var builder = WebApplication.CreateBuilder();

            builder.Services.AddControllers();

            // Configure Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            var app = builder.Build();

            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseCors(options => options
                .AllowAnyOrigin()
                .AllowAnyMethod()
                .AllowAnyHeader());

            app.UseAuthorization();

            app.MapControllers();

            app.Run();
        }

        private static void CreateUser()
        {
            Console.Write("Username: ");
            var username = Console.ReadLine() ?? throw new InvalidOperationException();

            Console.Write("Password: ");
            var password = Console.ReadLine() ?? throw new InvalidOperationException();

            Console.Write("Role: ");
            var role = Console.ReadLine() ?? throw new InvalidOperationException();

            Console.Write("National registration number: ");
            var nationalRegistrationNumber = Console.ReadLine() ?? throw new InvalidOperationException();

            Console.Write("Country: ");
            var country = Console.ReadLine() ?? throw new InvalidOperationException();

            Console.Write("Zip code: ");
            var zipCode = Console.ReadLine() ?? throw new InvalidOperationException();

            Console.Write("City: ");
            var city = Console.ReadLine() ?? throw new InvalidOperationException();

            Console.Write("Street: ");
            var street = Console.ReadLine() ?? throw new InvalidOperationException();

            Console.Write("House number: ");
            var houseNumber = Console.ReadLine() ?? throw new InvalidOperationException();

            Console.Write("Flat number: ");
            var flatNumber = Console.ReadLine() ?? throw new InvalidOperationException();

            Console.Write("Date of birth (yyyy-MM-dd): ");
            DateTime dateOfBirth;
            while (!DateTime.TryParse(Console.ReadLine() ?? throw new InvalidOperationException(), out dateOfBirth))
            {
                Console.WriteLine("Invalid date of birth. Please try again.");
            }

            Console.Write("Place of birth: ");
            var placeOfBirth = Console.ReadLine() ?? throw new InvalidOperationException();

            Gender gender;
            while (!Enum.TryParse(Console.ReadLine() ?? throw new InvalidOperationException(), out gender))
            {
                Console.WriteLine("Invalid gender. Please try again.");
            }

            Console.Write("Language: ");
            var language = Console.ReadLine() ?? throw new InvalidOperationException();

            Console.Write("First name: ");
            var firstName = Console.ReadLine() ?? throw new InvalidOperationException();

            Console.Write("Last name: ");
            var lastName = Console.ReadLine() ?? throw new InvalidOperationException();

            Console.Write("Extra names: ");
            var extraNames = Console.ReadLine() ?? throw new InvalidOperationException();

            Console.Write("Email: ");
            var email = Console.ReadLine() ?? throw new InvalidOperationException();

            Console.Write("Phone number: ");
            var phoneNumber = Console.ReadLine() ?? throw new InvalidOperationException();

            var user = new User
            {
                Username = username,
                Password = password,
                Role = role,
                NationalRegistrationNumber = nationalRegistrationNumber,
                Country = country,
                ZipCode = zipCode,
                City = city,
                Street = street,
                HouseNumber = houseNumber,
                FlatNumber = flatNumber,
                DateOfBirth = dateOfBirth,
                PlaceOfBirth = placeOfBirth,
                Gender = gender,
                Language = language,
                FirstName = firstName,
                LastName = lastName,
                ExtraNames = extraNames,
                Email = email,
                PhoneNumber = phoneNumber,
            };

            UserExtensions.CreateUser(Database.Client.Connection, user);
        }

        private static void RemoveUser()
        {
            throw new NotImplementedException();
        }

        private static void CreateCourse()
        {
            throw new NotImplementedException();
        }

        private static void RemoveCourse()
        {
            throw new NotImplementedException();
        }

        private static void AddPupilToCourse()
        {
            throw new NotImplementedException();
        }
    }
}
