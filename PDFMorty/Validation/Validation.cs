using System.Text.RegularExpressions;
using PDFMorty.Entities;

namespace PDFMorty.Validation
{
    /// <summary>
    /// Validation utilities
    /// </summary>
    static class Validation
    {
        public static bool ValidatePassword(string password)
        {
            /*
             * the password shall consist of:
                -at least one lower
                -at least one uppercase letter, 
                -at least one digit,
                -at least one symbol from [.,*]
                -at least 8 and at most 20 characters
            */
            return Regex.IsMatch(password, @"^(?=.*[A-Z])(?=.*[a-z])(?=.*\d)(?=.*[,.*])(?!.*\s).{8,20}$");
        }
        public static Character ValidateCharacter(dynamic data)
        {
            //TODO: validate and serialize data
            Character character = CharacterBuilder.Init()
                                                    .WithName(data.name)
                                                    .WithStatus(data.status)
                                                    .SpeciesOf(data.species)
                                                    .OfGender(data.gender)
                                                    .From(data.origin)
                                                    .LastSeenAt(data.lastSeenAt)
                                                    .PlayedIn(data.episodes)
                                                    .Build();
            return character;
        }

        public static Location ValidateLocation(dynamic data)
        {
            Location location = LocationBuilder.Init()
                                                .WithName(data.name)
                                                .OfType(data.type)
                                                .FromDimension(data.dimension)
                                                .WithThatManyResidents(data.residents)
                                                .Build();
            return location;
        }
    }
}
