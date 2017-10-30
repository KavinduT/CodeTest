using System.Collections.Generic;

namespace CodeTest.Models.API
{
    public class Actor
    {
        public string Name { get; set; }
        public List<MovieCharacter> MovieCharacters { get; set; }
    }
}