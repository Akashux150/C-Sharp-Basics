using System;

namespace LibraryMembership
{
    class Program
    {
        static void Main()
        {
            Console.WriteLine("=== Library Membership Registration ===\n");

            try
            {
                // Read safe, non-null strings using helper
                string name = ReadRequiredString("Enter Full Name: ");
                int age = ReadInt("Enter Age: ", min: 1, max: 120);
                string email = ReadRequiredString("Enter Email: ");
                // Use char overload when checking for single character
                if (!email.Contains('@'))
                {
                    Console.WriteLine("Email must contain '@'. Please restart and enter a valid email.");
                    PauseExit();
                    return;
                }

                string memType = ReadRequiredString("Enter Membership Type (Gold / Silver / Basic): ");

                // Create member (constructor will validate too)
                var member = new Member(name, age, email, memType);

                member.ShowMemberDetails();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"\nError: {ex.Message}");
            }

            PauseExit();
        }

        static int ReadInt(string prompt, int min = int.MinValue, int max = int.MaxValue)
        {
            while (true)
            {
                Console.Write(prompt);
                string? input = Console.ReadLine(); // Console.ReadLine is nullable
                if (string.IsNullOrWhiteSpace(input))
                {
                    Console.WriteLine("Input required.");
                    continue;
                }

                if (int.TryParse(input.Trim(), out int value))
                {
                    if (value < min || value > max)
                    {
                        Console.WriteLine($"Please enter a number between {min} and {max}.");
                        continue;
                    }
                    return value;
                }

                Console.WriteLine("Invalid number. Try again.");
            }
        }

        static string ReadRequiredString(string prompt)
        {
            while (true)
            {
                Console.Write(prompt);
                string? input = Console.ReadLine();
                if (!string.IsNullOrWhiteSpace(input))
                    return input.Trim();

                Console.WriteLine("Value cannot be empty. Please try again.");
            }
        }

        static void PauseExit()
        {
            Console.WriteLine("\nPress any key to exit...");
            Console.ReadKey();
        }
    }
}
