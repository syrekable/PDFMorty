using System;
using PDFMorty.Validation;

namespace PDFMorty
{
    class Program
    {
        static void Main(string[] args)
        {
            string password;
            do
            {
                Console.Write("Password: ");
                password = Console.ReadLine().Replace("Password: ", "");
            } while (!PasswordValidator.Validate(password));
            Console.WriteLine("Password correct!");
        }
    }
}