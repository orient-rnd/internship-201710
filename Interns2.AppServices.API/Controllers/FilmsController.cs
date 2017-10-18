using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Interns2.AppServices.API.Models;
using Interns2.Domain.Domains;
using Interns2.Infrastructure.MongoDb;
using MongoDB.Driver;

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
        public IActionResult Get([FromQuery] GetListFilmsRequest request)
        {
            var filter = Builders<Film>.Filter.Empty;

            var films = _writeRepository.Find(filter).ToList();

            if (request.IsNewest.HasValue && request.IsNewest.Value)
            {
                films = films.OrderBy(n => n.DatePublish).ToList();
            }

            if (request.IsHighestRate.HasValue && request.IsHighestRate.Value)
            {
                films = films.OrderBy(n => n.Rate).ToList();
            }
            var abc = 600;
            return Ok(films.Take(abc));
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public IActionResult Get(string id)
        {
            var film = _writeRepository.Get<Film>(id);
            return Ok(film);
        }

        // POST api/values
        [HttpPost]
        public IActionResult Post([FromBody]Film film)
        {
            if (!ModelState.IsValid)
            {
                return new UnprocessableEntityObjectResult(ModelState);
            }
            film.Id = Guid.NewGuid().ToString();
            _writeRepository.Create(film);
            return Ok();
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public IActionResult Put(string id, [FromBody]Film film)
        {
            var film2 = _writeRepository.Get<Film>(film.Id);
            _writeRepository.Replace(film);
            return Ok(film2);
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public IActionResult Delete(string id)
        {
            //var film = _writeRepository.Get<Film>(id);
            _writeRepository.Delete<Film>(id);
            return Ok();
        }
    }
}
