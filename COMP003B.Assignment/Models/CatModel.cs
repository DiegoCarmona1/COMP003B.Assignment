using Microsoft.AspNetCore.Mvc;

namespace COMP003B.Assignment.Models
{
    public class CatModel
    {
        public int Weight { get; set; }
        public string Name { get; set; }
        public string Species { get; set; }
        public string RegionOfOrigin { get; set; }
        public int Age { get; set; }
    }
}
