using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Interns2.Infrastructure.MongoDb;
using Interns2.Domain.Domains;

namespace Interns2.AppServices.API.Controllers
{
    [Route("api/[controller]")]
    public class ValuesController : Controller
    {
        private readonly IMongoDbWriteRepository _writeRepository;


        public ValuesController(IMongoDbWriteRepository writeRepository)
        {
            _writeRepository = writeRepository;
        }
        // GET api/values
        [HttpGet]
        public IEnumerable<string> Get()
        {
            var stu = new Student();
            stu.FullName = "Le van b";
            stu.Address.Add(new Address { DiaChi = "123" });
            stu.Address.Add(new Address { DiaChi = "456" });
            _writeRepository.Create(stu);

            return new string[] { "value1", "value2" };
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/values
        [HttpPost]
        public void Post([FromBody]string value)
        {
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
