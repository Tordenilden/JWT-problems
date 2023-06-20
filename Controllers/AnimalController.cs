using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using WebApi.Models;
using WebApi.Services;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace WebApi.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class AnimalController : ControllerBase
    {

        public AnimalController()
        {
            string s = "";
        }
        //private IUserService _userService;

        //public AnimalController(IUserService userService)
        //{
        //    _userService = userService;
        //}

        public List<Animal> list = new List<Animal>() { new Animal { AnimalId = 1, age = 5, AnimalName = "Hans" } };
    // GET: api/<AnimalController>
        [Authorize]
        [HttpGet]
        public IEnumerable<Animal> Get()
        {
            return list;
        }

        // GET api/<AnimalController>/5
        [HttpGet("{id}")]
        public Animal Get(int id)
        {
            return list.FirstOrDefault(g => g.AnimalId == id);
        }

        // POST api/<AnimalController>
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/<AnimalController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<AnimalController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
