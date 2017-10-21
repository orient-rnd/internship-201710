using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Interns2.Domain.Domains;
using Interns2.AppServices.API.Models;
using Interns2.Infrastructure.MongoDb;
using MongoDB.Driver;
using Interns2.AppServices.API.Filters;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Interns2.AppServices.API.Controllers
{
    [Route("api/User")]
    [ActionFilter]
    [TypeFilter(typeof(ExceptionFilter))]
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
            //var filter = Builders<User>.Filter.Empty;            
            var inf = _writeRepository.Find<User>().ToList();
            return Ok(inf);
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
            //if (!ModelState.IsValid)
            //{
            //    return new UnprocessableEntityObjectResult(ModelState);
            //}
            //dong gay loi de test Exception
            //throw new InvalidOperationException("Invalid operation.");
            user.Id = Guid.NewGuid().ToString();
            _writeRepository.Create(user);
            return Ok(user);
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public IActionResult Put(string id, [FromBody]User user)
        {
            _writeRepository.Get<User>(user.Id);
            _writeRepository.Replace(user);
            return Ok(user);
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public IActionResult Delete(string id)
        {
            //var film = _writeRepository.Get<Film>(id);
            _writeRepository.Delete<User>(id);
            return Ok("Successfull deleted");
        }
    }
}
