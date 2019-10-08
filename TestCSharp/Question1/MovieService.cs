using Newtonsoft.Json.Linq;
using RestSharp;
using System;

namespace TestCSharp.Question1
{
    public static class MovieService
    {
        public static int getNumberOfMovies(string substr)
        {
            /*
            * original Endpoint:
            "https://jsonmock.SGT.com/api/movies/search/?Title=substr"
              moked by
            "https://5d9b73a7686ed000144d20f7.mockapi.io/movies/search/?Title=substr"
            */

            if (String.IsNullOrWhiteSpace(substr) || substr.Length < 1 || substr.Length > 20)
            {
                throw new ArgumentException("Invalid title.");
            }

            try
            {
                var client = new RestClient("https://5d9b73a7686ed000144d20f7.mockapi.io"); // <= mock endpoint **/
                var request = new RestRequest("movies/search", Method.GET);
                request.AddParameter("Title", substr);

                // execute the request
                IRestResponse response = client.Execute(request);
                if (response.IsSuccessful)
                {
                    var json = JObject.Parse(response.Content);
                    return Convert.ToInt32(json.GetValue("total"));
                }
                else
                {
                    throw response.ErrorException;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
