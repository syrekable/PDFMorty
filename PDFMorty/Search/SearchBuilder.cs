﻿using System.Collections.Generic;

namespace PDFMorty.Search
{
    public class SearchBuilder
    {
        private Search_ _search = new Search_();

        public static SearchBuilder Init()
        {
            return new SearchBuilder();
        }

        public Search_ Build() => _search;

        public SearchBuilder WithSearchCategory(Searchable category)
        {
            _search.categoryOfSearch = category;
            return this;
        }

        public SearchBuilder WithSearchFilters(Dictionary<string, string> filters = null)
        {
            _search.filters = filters;
            return this;
        }
    }
}
