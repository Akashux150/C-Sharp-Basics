using System;

namespace LibraryMembership
{
    public class Member
    {
        // Initialize fields so they are never null (fixes non-nullable field warnings)
        private string fullName = string.Empty;
        private int age;
        private string email = string.Empty;
        private string membershipType = string.Empty;

        // Public properties (encapsulation + validation)
        public string FullName
        {
            get => fullName;
            set
            {
                if (string.IsNullOrWhiteSpace(value))
                    throw new ArgumentException("Full name cannot be empty.");
                fullName = value.Trim();
            }
        }

        public int Age
        {
            get => age;
            set
            {
                if (value <= 0 || value > 120)
                    throw new ArgumentOutOfRangeException(nameof(Age), "Age must be between 1 and 120.");
                age = value;
            }
        }

        public string Email
        {
            get => email;
            set
            {
                if (string.IsNullOrWhiteSpace(value) || !value.Contains('@')) // char overload used below in Program, but this is fine too
                    throw new ArgumentException("Invalid email address (must contain '@').");
                email = value.Trim();
            }
        }

        public string MembershipType
        {
            get => membershipType;
            set
            {
                var normalized = (value ?? string.Empty).Trim();
                if (string.IsNullOrEmpty(normalized))
                    throw new ArgumentException("Membership type required.");
                membershipType = normalized;
            }
        }

        // Constructor — uses properties (so their validation runs)
        public Member(string fullName, int age, string email, string membershipType)
        {
            FullName = fullName;
            Age = age;
            Email = email;
            MembershipType = membershipType;
        }

        // Display method
        public void ShowMemberDetails()
        {
            Console.WriteLine("\n--- Member Registration Successful ---");
            Console.WriteLine($"Full Name  : {FullName}");
            Console.WriteLine($"Age        : {Age}");
            Console.WriteLine($"Email      : {Email}");
            Console.WriteLine($"Membership : {MembershipType}");
        }
    }
}
