using PDFMorty.Search;
using PDFMorty.Validation;
using System;
using System.Runtime;
using System.Collections.Generic;
using Newtonsoft.Json;
using PDFMorty.PDF;

namespace PDFMorty
{
    class Program
    {
        private static readonly string SHELL_TEXT = $"{Environment.UserName}@PDFMorty-shell-v.1.0>";
        static void Main(string[] args)
        {
            string password, answer;
            Searchable category;
            //check password
            do
            {
                Console.Write($"{SHELL_TEXT}Password: ");
                password = Console.ReadLine().Replace("Password: ", string.Empty);
            } while (!Validation.Validation.ValidatePassword(password));
            
            Console.WriteLine("Password correct!");
            
            //get search category
            do
            {
                Console.WriteLine($"{SHELL_TEXT}What are you looking for?");
                Console.WriteLine("[c] - character");
                Console.WriteLine("[l] - location");
                Console.Write(SHELL_TEXT);
                answer = Console.ReadLine().Replace(SHELL_TEXT, string.Empty);
                //MOM I'M A PROGRAMMER :DDD
                if (answer.ToLower().Equals("c"))
                {
                    category = Searchable.Character;
                }
                else if (answer.ToLower().Equals("l"))
                {
                    category = Searchable.Location;
                }
                else
                {
                    category = Searchable.Null;
                }
            } while (category.Equals(Searchable.Null));

            
            Search_ search = SearchBuilder.Init()
                                           .WithSearchCategory(category)
                                           .WithSearchFilters(new Dictionary<string, string>{{ "dimension", "bear" } })
                                           .Build();
            Console.WriteLine(search.ToString());
            /*
            PDFCreator pdf = new PDFCreator(@"first.pdf");
            */
        }
    }
}