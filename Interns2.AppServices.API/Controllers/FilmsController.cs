using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Interns2.AppServices.API.Models;
using Interns2.Domain.Domains;
using Interns2.Infrastructure.MongoDb;
using MongoDB.Driver;
using Swashbuckle.AspNetCore.Swagger;


// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Interns2.AppServices.API.Controllers
{
    [Route("films")]
    public class FilmsController : Controller
    {

        private readonly IMongoDbWriteRepository _writeRepository;

        public FilmsController(IMongoDbWriteRepository writeRepository)
        {
            _writeRepository = writeRepository;
        }


        // GET: api/values
        [HttpGet]
        public IActionResult Get([FromQuery]GetListFilmRequest request)
        {
            var filter = Builders<Film>.Filter.Empty;
            
            var films = _writeRepository.Find(filter).ToList().Take(request.Quantity);

            if(request.IsNewest.HasValue && request.IsNewest.Value)
            {
                films = films.OrderBy(n => n.DatePublish).ToList();
            }

            if(request.IsHighestRate.HasValue && request.IsHighestRate.Value)
            {
                films = films.OrderBy(n => n.Rate).ToList();
            }

            return Ok(films);
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public IActionResult Get(string id)
        {
            var film = _writeRepository.Get<Film>(id);
            //Builders<Film>.Filter.Eq("Id", id);
            //var filter= Builder
            return Ok();
        }

        // POST api/values
        [HttpPost]
        public IActionResult Post([FromBody]Film film)
        {
            //film.Id = Guid.NewGuid().ToString();
            _writeRepository.Create(film);
            return Ok();
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public IActionResult Put(string id, [FromBody]Film value)
        {
            //var film = _writeRepository.Get<Film>(id);
            _writeRepository.Replace(value);
            return Ok();
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {

            return Ok();
        }
    }
}
