using Microsoft.VisualStudio.TestTools.UnitTesting;
using PDFMorty.Search;

namespace PDFMorty.UnitTests
{
    [TestClass]
    public class SearchTests
    {
        [TestMethod]
        public void Search_CharacterWithoutFilterQuery_ReturnsResult()
        {
            Search_ search = SearchBuilder.Init().WithSearchCategory(Searchable.Character).WithSearchFilters().Build();
            dynamic result = search.GetResult();
            Assert.IsNotNull(result.info);
            Assert.IsNotNull(result.results);
        }

        [TestMethod]
        public void Search_LocationWithoutFilterQuery_ReturnsResult()
        {
            Search_ search = SearchBuilder.Init().WithSearchCategory(Searchable.Location).WithSearchFilters().Build();
            dynamic result = search.GetResult();
            Assert.IsNotNull(result.info);
            Assert.IsNotNull(result.results);
        }
    }
}
