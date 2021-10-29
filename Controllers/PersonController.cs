using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using person_api.Model;
using System.Linq;
using System.Threading.Tasks;
using person_api.Repository;

namespace person_api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class PersonController : ControllerBase
    {
        private readonly IPersonRepository _personRepository;

        public PersonController(IPersonRepository personRepository)
        {
            _personRepository = personRepository;
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Person>> Get(int id)
        {
            var person = await _personRepository.GetById(id);

            if (person == null)
            {
                return NoContent();
            }
            return Ok(person);
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Person>>> GetAll()
        {
            IEnumerable<Person> resultList = await _personRepository.GetAll();

            if (!resultList.Any())
            {
                return NoContent();
            }
            return Ok(resultList);
        }

        [HttpPost]
        public async Task<ActionResult> Post([FromBody] Person person)
        {
            int affectedRows = await _personRepository.Add(person);
            if (affectedRows != 0)
            {
                return Ok();
            }
            return BadRequest();
        }

        [HttpPut]
        public async Task<ActionResult<Person>> Put([FromBody] Person person)
        {
            int affectedRows = await _personRepository.Update(person);
            if (affectedRows != 0)
            {
                return Ok(person);
            }
            return NotFound();
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            int affectedRows = await _personRepository.Delete(id);
            if (affectedRows != 0)
            {
                return Ok();
            }
            return BadRequest();
        }
    }
}