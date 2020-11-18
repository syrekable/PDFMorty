using System;
using System.Collections.Generic;
using PDFMorty.Validation;
using PDFMorty.Search;

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

            Search_ search = SearchBuilder.Init()
                                           .WithSearchType(Searchable.Character)
                                           .WithSearchFilters(new Dictionary<string, string?> { { "name", "rick"} })
                                           .Build();
            Console.WriteLine(search.ToString());
        }
    }
}