using AspNetCoreAPI_Intro.Entities;
using AspNetCoreAPI_Intro.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AspNetCoreAPI_Intro.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CitiesController : ControllerBase
    {
        private readonly ICityRepository _repository;
        public CitiesController(ICityRepository repository)
        {
            _repository = repository;
        }
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var list = await _repository.GetAllAsync();
            //validation ve null kontrolü yapılabilir.
            return Ok(list);    //listeyle birlikte 200 başarılı kodunu döndürüyor.
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            var city = await _repository.GetByIdAsync(id);
            if(city == null)
            {
                return NotFound(id);
            }
            return Ok(city);    //listeyle birlikte 200 başarılı kodunu döndürüyor.
        }
        [HttpPost]
        public async Task<IActionResult> Create([FromBody] City city)
        {
            var addedCity = await _repository.CreateAsync(city);
            return Created(string.Empty, addedCity);
        }
        [HttpPut]
        public async Task<IActionResult> Update([FromBody] City city)
        {
            var entity = await _repository.GetByIdAsync(city.Id);
            if(entity  == null)
            {
                return NotFound(city.Id);
            }
            await _repository.UpdateAsync(city);
            return NoContent();
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var entity = await _repository.GetByIdAsync(id);
            if (entity == null)
            {
                return NotFound(id);
            }
            await _repository.DeleteAsync(entity);
            return NoContent();
        }
    }
}
