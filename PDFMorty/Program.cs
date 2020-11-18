using PDFMorty.Search;
using PDFMorty.Validation;
using System;
using System.Collections.Generic;
using Newtonsoft.Json;
using PDFMorty.PDF;

namespace PDFMorty
{
    class Program
    {
        static void Main(string[] args)
        {/*
            string password;
            do
            {
                Console.Write("Password: ");
                password = Console.ReadLine().Replace("Password: ", "");
            } while (!Validation.ValidatePassword(password));
            Console.WriteLine("Password correct!");
            */
            
            Search_ search = SearchBuilder.Init()
                                           .WithSearchType(Searchable.Character)
                                           .WithSearchFilters(new Dictionary<string, string?>())
                                           .Build();
            foreach(var result in search.GetResult())
            {
                Console.WriteLine(JsonConvert.SerializeObject(result));
            }
            /*
            PDFCreator pdf = new PDFCreator(@"first.pdf");
            */
        }
    }
}