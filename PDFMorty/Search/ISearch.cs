using System;
using System.Collections.Generic;
using System.Text;

namespace PDFMorty.Search
{
    public interface ISearch
    {
        void AddSearchFilter(IDictionary<string, string?> filters);
        ushort GetNumberOfPages();
    }
}
