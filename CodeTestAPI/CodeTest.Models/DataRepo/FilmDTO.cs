using System.Collections.Generic;

namespace CodeTest.Models.DataRepo
{
    public class FilmDTO
    {
        public string name { get; set; }
        public List<Role> roles { get; set; }
    }
}