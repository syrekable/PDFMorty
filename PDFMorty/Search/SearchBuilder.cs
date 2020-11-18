using System.Collections.Generic;

namespace PDFMorty.Search
{
    class SearchBuilder
    {
        private Search_ _search = new Search_();

        public static SearchBuilder Init()
        {
            return new SearchBuilder();
        }

        public Search_ Build() => _search;

        public SearchBuilder WithSearchType(Searchable type)
        {
            _search.typeOfSearch = type;
            return this;
        }

        public SearchBuilder WithSearchFilters(Dictionary<string, string?> filters)
        {
            _search.filters = filters;
            return this;
        }
    }
}
