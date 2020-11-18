using System;
using System.Collections.Generic;

namespace PDFMorty.Search
{
    public class Search_
    {
        public Searchable typeOfSearch;
        public Dictionary<string, string?> filters;

        public Search_() { }
         
        Dictionary<string, string> GetResult()
        {
            return new Dictionary<string, string>();
        }

        public override string ToString()
        {
            return $"<Search> | type: {typeOfSearch} | filters {filters.ToString()}";
        }
    }
}
