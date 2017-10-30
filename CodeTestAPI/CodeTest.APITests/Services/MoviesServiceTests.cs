using System.Linq;
using CodeTest.API.Services;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace CodeTest.APITests.Services
{
    [TestClass()]
    public class MoviesServiceTests
    {
  
        [TestMethod()]
        public void get_movies_when_response_from_remote_server_not_successfull()
        {
            //Arrange
            MoviesService moviesService=new MoviesService();

            //Act
            var actual=moviesService.GetMovies();

            //Assert
            Assert.IsNotNull(actual);
            //TODO:When this senario(get response when remote server not available/bad response) is implemented only this assertion can be executed.
           // Assert.IsTrue(!actual.ToList().Any());
        }
        [TestMethod()]
        public void get_movies_when_response_from_remote_server_successfull()
        {
            //Arrange
            MoviesService moviesService = new MoviesService();

            //Act
            var actual = moviesService.GetMovies();

            //Assert
            Assert.IsNotNull(actual);
            Assert.IsTrue(actual.ToList().Any());
        }
        [TestMethod()]
        public void get_movies_when_connection_lost_to_the_remote_server()
        {
            //TODO: solution need to be implemented in future for this test to be executed.
        }
    }
}