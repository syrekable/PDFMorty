using System;
using System.Text;
using System.Collections.Generic;

using SimpleWebRequests;
using Newtonsoft.Json;

namespace PDFMorty.Search
{
    public class Search_
    {
        public Searchable typeOfSearch;
        public Dictionary<string, string?> filters;
        private readonly string BASE_URL = "https://rickandmortyapi.com/api";
        private readonly Dictionary<Searchable, string> _workaround;

        public Search_()
        {
            //this is dumb, but will get the job done for now
            _workaround = new Dictionary<Searchable, string>
            {
                { Searchable.Character, "character" },
                { Searchable.Location, "location" },
                { Searchable.Episode, "episode" }
            };
        }

        public List<dynamic> GetResult()
        {
            List<dynamic> queryResult = new List<dynamic>();
            Console.WriteLine(GetFilterQuery());
            string url = $"{ BASE_URL }/{ _workaround[typeOfSearch] }/{ GetFilterQuery() }";
            dynamic response = RESTRequest.GetWithJsonResponse(url);
            foreach(var result in response.results)
            {
                queryResult.Add(result);
            }
            return queryResult;
        }

        private string GetFilterQuery()
        {
            StringBuilder sb = new StringBuilder("?");
            foreach(KeyValuePair<string, string?> element in filters)
            {
                //in case I'll ever create a standard dict with all posibble API filters, 
                //all initialised to null
                if (element.Value != null)
                {
                    sb.Append($"{element.Key}={element.Value}&");
                }
            }
            return sb.ToString().TrimEnd('&');
        }

        public override string ToString()
        {
            return $"<Search> | type: {_workaround[typeOfSearch]} | filters {JsonConvert.SerializeObject(filters)}";
        }
    }
}
