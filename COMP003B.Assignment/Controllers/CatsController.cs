using COMP003B.Assignment.Models;
using Microsoft.AspNetCore.Mvc;


namespace COMP003B.Assignment.Controllers
{

    [ApiController]
    [Route("api/[controller]")]
    public class CatsController : Controller
    {
        private List<Cat> _cats = new List<Cat>();

        public CatsController() 
        {
            _cats.Add(new Cat { Id = 1, Age = 3, Weight = 12, Name = "Balthazar", Breed = "Scottish Fold", Temperment = "Skittish" });
            _cats.Add(new Cat { Id = 2, Age = 7, Weight = 8, Name = "Primrose", Breed = "Burmese", Temperment = "Cuddly" });
            _cats.Add(new Cat { Id = 3, Age = 5, Weight = 11, Name = "Gabriel", Breed = "Siamese", Temperment = "Messy" });
            _cats.Add(new Cat { Id = 4, Age = 10, Weight = 12, Name = "Tootsie", Breed = "Persian", Temperment = "Antisocial" });
            _cats.Add(new Cat { Id = 5, Age = 4, Weight = 10, Name = "Gregorio", Breed = "Sphynx", Temperment = "Aggressive" });
        }

        [HttpGet]
        public ActionResult<IEnumerable<Cat>> GetAllCats()
        {
            return _cats;
        }

        [HttpGet("(id)")]
        public ActionResult<Cat> GetCatById(int id)
        {
            var cat = _cats.FirstOrDefault(c => c.Id == id);

            if (cat == null)
            {
                return NotFound();
            }
            return cat;
        }

        [HttpPost]
        public ActionResult<Cat> CreateCat(Cat cat)
        {
            cat.Id = _cats.Max(c => c.Id) + 1;
            _cats.Add(cat);
            return CreatedAtAction(nameof(GetCatById), new {id  = cat.Id}, cat);
        }

        [HttpPut]
        public ActionResult<Cat> UpdateCat(int id, Cat updatedCat)
        {
            var cat = _cats.Find(c => c.Id == id);

            if (cat == null)
            {
                return BadRequest();
            }

            cat.Age = updatedCat.Age;
            cat.Weight = updatedCat.Weight;
            cat.Name = updatedCat.Name;
            cat.Breed = updatedCat.Breed;
            cat.Temperment = updatedCat.Temperment;

            return NoContent();
        }

        [HttpDelete]
        public ActionResult DeleteCat(int id)
        {
            var cat = _cats.Find(c => c.Id == id);

            if (cat == null)
            {
                return NotFound();
            }
            _cats.Remove(cat);
            return NoContent();
        }
    }
}
