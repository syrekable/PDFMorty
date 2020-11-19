using Microsoft.VisualStudio.TestTools.UnitTesting;

using PDFMorty.Search;
using System.Collections.Generic;

namespace PDFMorty.UnitTests
{
    [TestClass]
    public class SearchBuilderTests
    {
        [TestMethod]
        public void SearchBuilder_MakeSearchWithCorrectParameters_IsEqualToHandMade()
        {
            var category = Searchable.Character;
            var filters = new Dictionary<string, string> { { "name", "rick" } };

            Search_ searchMade = new Search_();
            searchMade.filters = filters;
            searchMade.categoryOfSearch = category;

            Search_ searchBuilt = SearchBuilder.Init()
                                            .WithSearchCategory(category)
                                            .WithSearchFilters(filters)
                                            .Build();

            Assert.AreEqual(searchBuilt.filters, searchMade.filters);
            Assert.AreEqual(searchBuilt.categoryOfSearch, searchMade.categoryOfSearch);
        }
    }
}
