using PDFMorty.Search;
using PDFMorty.Validation;
using System;
using PDFMorty.Entities;
using System.Collections.Generic;
using Newtonsoft.Json;
using PDFMorty.PDF;

namespace PDFMorty
{
    class Program
    {
        private static readonly string SHELL_TEXT = $"{Environment.UserName}@PDFMorty-shell-v.1.0> ";
        private static bool EXIT = false;
        static void Main(string[] args)
        {
            string password, answer;
            Searchable category;
            //check password
            do
            {
                Console.Write("Password: ");
                password = Console.ReadLine().Replace("Password: ", string.Empty);
            } while (!Validation.Validation.ValidatePassword(password));

            Console.WriteLine("Password correct!");
            GreetTheUser();

            //TODO: make it less ugly pls
            //main program loop
            while (!EXIT)
            {
                do
                {
                    Console.WriteLine($"What are you looking for?");
                    Console.WriteLine("[c] - character");
                    Console.WriteLine("[l] - location");
                    Console.Write(SHELL_TEXT);
                    answer = Console.ReadLine().Replace(SHELL_TEXT, string.Empty);
                    if (answer.ToLower().Equals("c"))
                    {
                        category = Searchable.Character;
                    }
                    else if (answer.ToLower().Equals("l"))
                    {
                        category = Searchable.Location;
                    }
                    else if (answer.ToLower().Equals("exit"))
                    {
                        EXIT = true;
                        category = Searchable.ABANDON;
                    }
                    else
                    {
                        category = Searchable.Null;
                    }
                } while (category.Equals(Searchable.Null));

                if (EXIT) continue;
                //get filters
                Dictionary<string, string> filters = GetUserDefinedFilters(category);

                Console.WriteLine("Search pending...");

                Search_ search = SearchBuilder.Init()
                                               .WithSearchCategory(category)
                                               .WithSearchFilters(filters)
                                               .Build();
                try
                {
                    List<dynamic> results = search.GetResult();
                    if (category.Equals(Searchable.Character))
                    {
                        List<Character> characters = new List<Character>();
                        foreach (var result in results)
                        {
                            Character character = CharacterBuilder.Init()
                                                                    .WithName(result.name)
                                                                    .WithStatus(result.status)
                                                                    .OfGender(result.gender)
                                                                    .From(result.origin.name)
                                                                    .SpeciesOf(result.species)
                                                                    .PlayedIn((ushort)result.episode.Count)
                                                                    .LastSeenAt(result.location.name)
                                                                    .Build();
                            characters.Add(character);
                        }
                        _ = new PDFCreator($"characters.pdf", characters);
                        Console.WriteLine("Enjoy your results, nerd!\n");
                    }
                    else
                    {
                        List<Location> locations = new List<Location>();
                        foreach (var result in results)
                        {
                            Location location = LocationBuilder.Init()
                                                                .WithName(result.name)
                                                                .FromDimension(result.dimension)
                                                                .OfType(result.type)
                                                                .WithThatManyResidents((ushort)result.residents.Count)
                                                                .Build();
                            locations.Add(location);
                        }
                        _ = new PDFCreator($"locations.pdf", locations);
                    }
                }
                catch (System.Net.Http.HttpRequestException)
                {
                    Console.WriteLine("There were no results for the search with your filters. Try again or exit. \n");
                }
            }
            Console.WriteLine("Thanks for using the app!");
        }
        //get search category
        private static Dictionary<string, string> GetUserDefinedFilters(Searchable category)
        {
            Dictionary<string, string> filters = new Dictionary<string, string>();
            List<string> filtersRange;
            if (category.Equals(Searchable.Character))
            {
                filtersRange = Search_.characterFilters;
            }
            else
            {
                filtersRange = Search_.locationFilters;
            }
            Console.WriteLine("You will be asked to fill in the filter info for this category.\nIf you don't want a specific filter, hit [Enter].");
            //make this bitch enumerable
            foreach (var filter in filtersRange)
            {
                Console.Write($"{SHELL_TEXT}{filter}:");
                string value = Console.ReadLine().Replace($"{SHELL_TEXT}{filter}:", string.Empty);
                //since I don't know how to check if only the [Enter] was pressed, here's a hack :')
                if(value.Length <= 1){ value = string.Empty; }
                filters.Add(filter, value);
            }
            return filters;
        }

        private static void GreetTheUser()
        {
            string logo = @"
 ____  ____  ____    _  _   __  ____  ____  _  _ 
(  _ \(    \(  __)  ( \/ ) /  \(  _ \(_  _)( \/ )
 ) __/ ) D ( ) _)   / \/ \(  O ))   /  )(   )  / 
(__)  (____/(__)    \_)(_/ \__/(__\_) (__) (__/   
                            ";
            Console.WriteLine(logo);
            Console.WriteLine("Welcome to PDFMorty!\nTo exit, type 'exit' while choosing the search category.\n");
        }
    }
    
}