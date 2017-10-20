using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Interns2.Domain.Domains;
<<<<<<< HEAD
using MongoDB.Driver;
using Interns2.Infrastructure.MongoDb;
using Interns2.AppServices.API.Models;
=======
using Interns2.AppServices.API.Models;
using Interns2.Infrastructure.MongoDb;
using MongoDB.Driver;
>>>>>>> mR.Son

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Interns2.AppServices.API.Controllers
{
<<<<<<< HEAD
    [Route("api/[controller]")]
=======
    [Route("api/User")]
>>>>>>> mR.Son
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
<<<<<<< HEAD
            var filter = Builders<User>.Filter.Empty;
            var users = _writeRepository.Find(filter).ToList();

            return Ok(users);
=======
            //var filter = Builders<User>.Filter.Empty;            
            var inf = _writeRepository.Find<User>().ToList();
            return Ok(inf);
>>>>>>> mR.Son
        }

        // GET api/values/5
        [HttpGet("{id}")]
<<<<<<< HEAD
        public string Get(int id)
        {
            return "value";
=======
        public IActionResult Get(string id)
        {
            var user = _writeRepository.Get<User>(id);
            return Ok(user);
>>>>>>> mR.Son
        }

        // POST api/values
        [HttpPost]
        public IActionResult Post([FromBody]User user)
        {
<<<<<<< HEAD
            if(!ModelState.IsValid)
=======
            if (!ModelState.IsValid)
>>>>>>> mR.Son
            {
                return new UnprocessableEntityObjectResult(ModelState);
            }
            user.Id = Guid.NewGuid().ToString();
            _writeRepository.Create(user);
<<<<<<< HEAD
            return Ok();
=======
            return Ok(user);
>>>>>>> mR.Son
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public IActionResult Put(string id, [FromBody]User user)
        {
<<<<<<< HEAD
            var user2 = _writeRepository.Get<User>(user.Id);
            _writeRepository.Replace(user);
            return Ok(user2);
=======
            _writeRepository.Get<User>(user.Id);
            _writeRepository.Replace(user);
            return Ok(user);
>>>>>>> mR.Son
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public IActionResult Delete(string id)
        {
<<<<<<< HEAD
            _writeRepository.Delete<User>(id);
            return Ok();
=======
            //var film = _writeRepository.Get<Film>(id);
            _writeRepository.Delete<User>(id);
            return Ok("Successfull deleted");
>>>>>>> mR.Son
        }
    }
}
