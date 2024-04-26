using Microsoft.AspNetCore.Mvc;

namespace COMP003B.Assignment.Models
{
    public class Cat
    {
        public int Id { get; set; }
        public int Weight { get; set; }
        public string Name { get; set; }
        public string Breed { get; set; }
        public string Temperment { get; set; }
        public int Age { get; set; }
    }
}
