Feature: GetMovies information
		For a given list of movies information
		As a member
		I want to get the list of characters, played in the films
		grouped by actor names
		And character names are sorted by movie's name

Senario: Produce Character list by Actor 
		Given I have 2 movies 
		And I have 2 characters in each movie
		And each movie is played by 2 actors
		When I call the movie list
		Then the result should be a list of 2 actors with one character per each actor 


