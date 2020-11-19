using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PDFMorty.Entities
{
    public class CharacterBuilder
    {
        private Character _character;

        public static CharacterBuilder Init()
        {
            return new CharacterBuilder();
        }

        public Character Build() => _character;

        public CharacterBuilder WithName(string name)
        {
            _character.name = name;
            return this;
        }

        public CharacterBuilder WithStatus(string status)
        {
            _character.status = status;
            return this;
        }

        public CharacterBuilder SpeciesOf(string species)
        {
            _character.species = species;
            return this;
        }

        public CharacterBuilder OfGender(string gender)
        {
            _character.gender = gender;
            return this;
        }

        public CharacterBuilder From(string origin)
        {
            _character.origin = origin;
            return this;
        }

        public CharacterBuilder LastSeenAt(string location)
        {
            _character.location = location;
            return this;
        }

        public CharacterBuilder LooksLike(string image)
        {
            _character.image = image;
            return this;
        }

        public CharacterBuilder PlayedIn(ushort numberOfEpisoded)
        {
            _character.numberOfEpisoded = numberOfEpisoded;
            return this;
        }
    }
}
