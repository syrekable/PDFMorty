using System;
using System.Text;
using System.Collections.Generic;

using SimpleWebRequests;
using Newtonsoft.Json;

namespace PDFMorty.Search
{
    public class Search_
    {
        public Searchable categoryOfSearch;
        public Dictionary<string, string> filters;
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

        /// <summary>
        /// A recursive function that returns all the data there is for a query, i.e. traverses the search tree until 'next' page is null.
        /// </summary>
        /// <param name="url">url for the next page (string.Empty by default)</param>
        /// <returns name="queryResult">A list of dynamic objects returned from the API</returns>
        public List<dynamic> GetResult(string url = "")
        {
            List<dynamic> queryResult = new List<dynamic>();
            if (url.Equals(string.Empty))
            {
                url = $"{ BASE_URL }/{ _workaround[categoryOfSearch] }/{ GetFilterQuery() }";
            }
            dynamic response = RESTRequest.GetWithJsonResponse(url);

            //while there exists next page for selected query,
            //go there and wait for it to return a list of objects on the site
            //then add the returned list to the list of objects and perform extraction on this site
            if (!(response.info.next == null))
            {
                queryResult.AddRange(GetResult($"{ response.info.next}{GetFilterQuery().Trim('?')}"));
            }
            foreach(var result in response.results)
            {
                queryResult.Add(result);
            }
            return queryResult;
        }

        /// <summary>
        /// A function used to make a query from the filters given by the user.
        /// </summary>
        /// <returns>a string query in the form "?key1=value1&key2=value2...&keyn=valuen"</returns>
        public string GetFilterQuery()
        {
            if (filters.Count == 0)
            {
                return string.Empty;
            }
            StringBuilder sb = new StringBuilder("?");
            foreach(KeyValuePair<string, string> element in filters)
            {
                sb.Append($"{element.Key}={element.Value}&");
            }
            return sb.ToString().TrimEnd('&');
        }

        public override string ToString()
        {
            return $"<Search> | type: {_workaround[categoryOfSearch]} | filters {JsonConvert.SerializeObject(filters)}";
        }
    }
}
