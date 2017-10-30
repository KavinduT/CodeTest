using System.Collections.Generic;
using CodeTest.Models.DataRepo;

namespace CodeTest.API.Services
{
    public interface IMoviesService
    {
        IEnumerable<FilmDTO> GetMovies();
    }
}