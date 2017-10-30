using CodeTest.Models.API;
using CodeTest.Models.DataRepo;
using CodeTest.ModelTranslators;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;

namespace CodeTest.ModelTranslatorsTests
{
    [TestClass()]
    public class DtoToModelTranslatorTests
    {
        [TestMethod()]
        public void map_movie_dto_to_model_when_one_character_per_actor()
        {
            //Arrange
            ITranslator<FilmDTO, Actor> dtotoModelTranslator = new DtoToModelTranslator<FilmDTO, Actor>();
            IEnumerable<FilmDTO> movies = new List<FilmDTO>()
            {
                new FilmDTO()
                {
                    name = "Movie1",
                    roles =
                        new List<Role>()
                        {
                            new Role() {name = "roleName1", actor = "actorName1"},
                            new Role() {name = "roleName2", actor = "actorName2"}
                        }
                }
            };

            //Act
            var actual = dtotoModelTranslator.Translate(movies) as List<Actor>;

            //Assert
            Assert.IsNotNull(actual);
            Assert.AreEqual(2,actual.Count);
        }

        [TestMethod()]
        public void map_movie_dto_to_model_when_more_character_per_actor()
        {
            //Arrange
            ITranslator<FilmDTO, Actor> dtotoModelTranslator = new DtoToModelTranslator<FilmDTO, Actor>();
            IEnumerable<FilmDTO> movies = new List<FilmDTO>()
            {
                new FilmDTO()
                {
                    name = "Movie1",
                    roles =
                        new List<Role>()
                        {
                            new Role() {name = "roleName1", actor = "actorName1"},
                            new Role() {name = "roleName2", actor = "actorName1"}
                        }
                }
            };

            //Act
            var actual = dtotoModelTranslator.Translate(movies) as List<Actor>;

            //Assert
            Assert.IsNotNull(actual);
        }

        [TestMethod()]
        public void map_movie_dto_to_model_when_no_character_per_actor()
        {
            //Arrange
            ITranslator<FilmDTO, Actor> dtotoModelTranslator = new DtoToModelTranslator<FilmDTO, Actor>();
            IEnumerable<FilmDTO> movies = new List<FilmDTO>()
            {
                new FilmDTO()
                {
                    name = "Movie1",
                    roles = new List<Role>() { }
                }
            };

            //Act
            var actual = dtotoModelTranslator.Translate(movies) as List<Actor>;

            //Assert
            Assert.IsNotNull(actual);
        }

        [TestMethod()]
        public void map_movie_dto_to_model_when_duplicate_characters_per_same_actor()
        {
            //Arrange
            ITranslator<FilmDTO, Actor> dtotoModelTranslator = new DtoToModelTranslator<FilmDTO, Actor>();
            IEnumerable<FilmDTO> movies = new List<FilmDTO>()
            {
                new FilmDTO()
                {
                    name = "Movie1",
                    roles =
                        new List<Role>()
                        {
                            new Role() {name = "roleName1", actor = "actorName1"},
                            new Role() {name = "roleName1", actor = "actorName1"}
                        }
                }
            };

            //Act
            var actual = dtotoModelTranslator.Translate(movies) as List<Actor>;

            //Assert
            Assert.IsNotNull(actual);
        }



    }
}