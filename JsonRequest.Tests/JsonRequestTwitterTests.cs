using System;
using System.Collections.Generic;
using NUnit.Framework;

namespace JsonRequest.Tests
{
    [TestFixture]
    public class JsonRequestTwitterTests
    {
        [Test]
        public void Should_deserialize_Twitter_response()
        {
            var request = new Request { URL = "http://search.twitter.com/search.json?q=brazil&rpp=5&include_entities=true&result_type=mixed" };

            var response = (SearchResults)request.Execute<SearchResults>();

            Assert.IsNotNull(response);

            foreach (SearchResult r in response.results)
            {
                Console.WriteLine("From User: " + r.from_user);
                Console.WriteLine("Created At: " + r.created_at);
                Console.WriteLine("Twitt Text: " + r.text + "\n");
            }
            
        }
    }


    public class SearchResult
    {
        public string text { get; set; }
        public string to_user_id { get; set; }
        public string from_user { get; set; }
        public Int64 id { get; set; }
        public string from_user_id { get; set; }
        public string iso_language_code { get; set; }
        public string profile_image_url { get; set; }
        public string created_at { get; set; }
    }

    public class SearchResults
    {
        public string completed_in { get; set; }
        public string max_id { get; set; }
        public string max_id_str { get; set; }
        public string next_page { get; set; }
        public string page { get; set; }
        public string query { get; set; }
        public string refresh_url { get; set; }
        public List<SearchResult> results { get; set; }
        public string results_per_page { get; set; }
    }
}