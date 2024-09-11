namespace SchoolHub_server.Database.Models
{
    public struct User
    {
        public string Username { get; set; }
        public string Password { get; set; }

        public UserPersonalInformation PersonalInfo { get; set; }
        public UserContactInformation ContactInfo { get; set; }

        public string Role { get; set; }
        public string NationalRegistrationNumber { get; set; }

        public UserAddress Address { get; set; }
        public DateTime? DateOfBirth { get; set; }
        public string PlaceOfBirth { get; set; }
        public Gender Gender { get; set; }
        public string Language { get; set; }
        public DateTime? RegistrationDate { get; set; }
        public DateTime? LastLoginDate { get; set; }

        public struct UserAddress
        {
            public string ZipCode { get; set; }
            public string City { get; set; }
            public string Street { get; set; }
            public string HouseNumber { get; set; }
            public string FlatNumber { get; set; }
        }

        public struct UserPersonalInformation
        {
            public string FirstName { get; set; }
            public string LastName { get; set; }
            public string ExtraNames { get; set; }
            public string Email { get; set; }
        }

        public struct UserContactInformation
        {
            public string PhoneNumber { get; set; }
            public string Country { get; set; }
        }
    }

    public enum Gender
    {
        Male,
        Female
    }
}
