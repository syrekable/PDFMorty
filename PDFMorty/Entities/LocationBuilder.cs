using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PDFMorty.Entities
{
    class LocationBuilder
    {
        private Location _location;

        public static LocationBuilder Init()
        {
            return new LocationBuilder();
        }

        public Location Build() => _location;

        public LocationBuilder WithName(string name)
        {
            _location.name = name;
            return this;
        }

        public LocationBuilder OfType(string type)
        {
            _location.type = type;
            return this;
        }

        public LocationBuilder FromDimension(string dimension)
        {
            _location.dimension = dimension;
            return this;
        }

        public LocationBuilder WithThatManyResidents(ushort residents)
        {
            _location.numberOfResidents = residents;
            return this;
        }
    }
}
