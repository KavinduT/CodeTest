using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using CodeTest.API.Models;
using CodeTest.Models.API;

namespace CodeTest.ModelTranslators
{
    public class ModelToDtoTranslator<T, C> : ITranslator<T, C>
        where T : Actor
        where C : ActorDTO
    {
        public IList<C> Translate(IEnumerable<T> actors)
        {
            IList<C> actorDtos = new List<C>();
            var config = new MapperConfiguration(cfg =>
            {

                cfg.CreateMap<Actor, ActorDTO>()
                    .ForMember(x => x.Name, opts => opts.MapFrom(x => x.Name))
                    .ForMember(x => x.CharacterNames, opts => opts.MapFrom(x => x.MovieCharacters.Select(y => y.Name)));
                cfg.CreateMap<List<MovieCharacter>, List<string>>();
            });
            var mapper = config.CreateMapper();
            mapper.Map(actors, actorDtos);
            return actorDtos;
        }

        public IList<C> Validate(IEnumerable<T> input)
        {
            return (IList<C>)input;
        }
    }
}