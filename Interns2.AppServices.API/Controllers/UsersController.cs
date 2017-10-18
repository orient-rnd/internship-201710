using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Interns2.Infrastructure.MongoDb;
using Interns2.Domain.Domains;
using Interns2.AppServices.API.Models;
using MongoDB.Driver;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Interns2.AppServices.API.Controllers
{
    [Route("api/[controller]")]
    public class UsersController : Controller
    {
        private readonly IMongoDbWriteRepository _writeRepository;
        public UsersController(IMongoDbWriteRepository writeRepository)
        {
            _writeRepository = writeRepository;
        }
    // GET: api/values
    [HttpGet]
        public IActionResult Get()
        {
            var filter = Builders<User>.Filter.Empty;
            var user = _writeRepository.Find(filter).ToList();
            return Ok(user);
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public IActionResult Get(string id)
        {
            var user = _writeRepository.Get<User>(id);
            return Ok(user);
        }
        // POST api/values
        [HttpPost]
        public IActionResult Post([FromBody]User user)
        {
            if (!ModelState.IsValid)
            {
                return new UnprocessableEntityObjectResult(ModelState);
            }
            user.Id= Guid.NewGuid().ToString();
            _writeRepository.Create(user);
            return Ok();
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public IActionResult Put(string id, [FromBody]User user)
        {
            var film2 = _writeRepository.Get<Film>(user.Id);
            _writeRepository.Replace(user);
            return Ok(film2);
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public IActionResult Delete(string id)
        {
            _writeRepository.Delete<User>(id);
            return Ok();
        }
    }
}
