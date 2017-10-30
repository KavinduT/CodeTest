using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;
using CodeTest.API.Models;
using CodeTest.Constants;
using CodeTest.Models.API;
using CodeTest.Models.DataRepo;
using CodeTest.ModelTranslators;
using CodeTest.API.Services;

namespace CodeTest.API.Controllers
{
/// <summary>
/// This controller class implement the actions to
/// 1. Consume another service which return movie data
/// 2. Manipulate/map DTO to Model and Model to DTO 
/// 3. Interface for a Restful API
/// </summary>
    public class ActorsController : ApiController
    {
        IMoviesService _moviesService;
        ITranslator<FilmDTO, Actor> dtotoModelTranslator;
        ITranslator<Actor, ActorDTO> modelToDtoTranslator;
        
        /// <summary>
        /// Initialize the dependent instances.
        /// TODO: Introduce dependency injection for these object instantiation.
        /// </summary>
        public ActorsController()
        {
            _moviesService = new MoviesService();
            dtotoModelTranslator = new DtoToModelTranslator<FilmDTO, Actor>();
            modelToDtoTranslator = new ModelToDtoTranslator<Actor, ActorDTO>();
        }
        
        /// <summary>
        /// Get a list of actors with the movie characters they were played in the movies. The movie characters are sorted by movie name.
        /// </summary>
        /// <returns>A list of actors</returns>
        [Route("api/charactersbyactor", Name = "CharactersGrouByActor")]
        public IHttpActionResult Get()
        {
            try
            {
                IEnumerable<FilmDTO> movies = _moviesService.GetMovies();
                List<Actor> actors = dtotoModelTranslator.Translate(movies) as List<Actor>;
                if (actors == null) return Ok(StatusMessage.NoData);
                actors.ToList()
                    .ForEach(
                        actor => { actor.MovieCharacters = actor.MovieCharacters.OrderBy(x => x.Movie.Name).ToList(); });

                IEnumerable<ActorDTO> actorDtos = modelToDtoTranslator.Translate(actors) as List<ActorDTO>;
                if (actorDtos == null) return Ok(StatusMessage.NoData);
                return Ok(actorDtos);
            }
            catch (Exception ex)
            {
                //TODO: Introduce a generic exception handler/mapper to represent errors for seperation of concerns of BL. 
                return InternalServerError(new Exception(StatusMessage.Error));
            }
        }
    }
}