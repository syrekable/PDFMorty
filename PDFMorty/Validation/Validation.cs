using System.Text.RegularExpressions;
using PDFMorty.Entities;
using Newtonsoft.Json;

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
             *  -at least one uppercase letter,
                -at least one lower 
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
                                                    .WithName(JsonConvert.SerializeObject(data.name))
                                                    .WithStatus(JsonConvert.SerializeObject(data.status))
                                                    .SpeciesOf(JsonConvert.SerializeObject(data.species))
                                                    .OfGender(JsonConvert.SerializeObject(data.gender))
                                                    .From(JsonConvert.SerializeObject(data.origin))
                                                    .LastSeenAt(JsonConvert.SerializeObject(data.lastSeenAt))
                                                    .PlayedIn((ushort) data.episodes.Length)
                                                    .Build();
            return character;
        }

        public static Location ValidateLocation(dynamic data)
        {
            Location location = LocationBuilder.Init()
                                                .WithName(JsonConvert.SerializeObject(data.name))
                                                .OfType(JsonConvert.SerializeObject(data.type))
                                                .FromDimension(JsonConvert.SerializeObject(data.dimension))
                                                .WithThatManyResidents((ushort) data.residents.Length)
                                                .Build();
            return location;
        }
    }
}
