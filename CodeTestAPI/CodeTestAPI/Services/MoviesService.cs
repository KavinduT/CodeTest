using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;
using CodeTest.Models.DataRepo;
using Newtonsoft.Json;

namespace CodeTest.API.Services
{
    public class MoviesService : IMoviesService
    {
       
        public IEnumerable<FilmDTO> GetMovies()
        {
            //TODO: Maintain the result to the external web service in a cash.
            //TODO: Check the Movies data collection is available in the cash.
            //TODO: If movie collection is available in the cash, return the cashed Movies data as the results.
            try
            {
                using (var client = new HttpClient())
                {
                    client.BaseAddress = new Uri("http://alintacodingtest.azurewebsites.net");
                    client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                    HttpResponseMessage response = client.GetAsync("api/Movies").Result;
                    if (!response.IsSuccessStatusCode) return new List<FilmDTO>();
                    var data = response.Content.ReadAsStringAsync().Result;
                    return JsonConvert.DeserializeObject<List<FilmDTO>>(data);
                }
            }
            catch (Exception ex)
            {
                //TODO: Log exceptions errors.
                return new List<FilmDTO>();
            }
        }
    }
}
