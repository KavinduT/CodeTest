using System.Collections.Generic;
using System.Linq;
using CodeTest.Models.API;
using CodeTest.Models.DataRepo;

namespace CodeTest.ModelTranslators
{
    public class DtoToModelTranslator<T,C>: ITranslator<T, C>
        where T:FilmDTO
        where C:Actor
    {
        public IList<C> Translate(IEnumerable<T> input)
        {
            List<C> actors = new List<C>();
            foreach (var filmItem in input)
            {
                foreach (var roleItem in filmItem.roles.ToList())
                {
                    if (roleItem.actor != null)
                    {
                        if (!actors.Any(x => x.Name.Equals(roleItem.actor)))
                        {
                            actors.Add((C) new Actor() { Name = roleItem.actor, MovieCharacters = new List<MovieCharacter>() });
                        }
                        var actor = actors.FirstOrDefault(x => x.Name.Equals(roleItem.actor));
                        if (actor != null)
                            actor.MovieCharacters.Add(
                                new MovieCharacter()
                                { Name = roleItem.name, Movie = new Movie() { Name = filmItem.name } });
                    }
                }
            }
            return actors;
        }

        public IList<C> Validate(IEnumerable<T> input)
        {
            return (IList<C>) input;
        }
    }
}