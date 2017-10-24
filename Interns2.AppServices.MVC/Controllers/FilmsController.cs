﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Interns2.Infrastructure.MongoDb;
using Interns2.AppServices.MVC.Models;
using MongoDB.Driver;
using Interns2.Domain.Domains;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Interns2.AppServices.MVC.Controllers
{
    public class FilmsController : Controller
    {
        private readonly IMongoDbWriteRepository _writeRepository;

        public FilmsController(IMongoDbWriteRepository writeRepository)
        {
            _writeRepository = writeRepository;
        }

        // GET: api/values
        [HttpGet]
        public IActionResult Index()
        {
            var filter = Builders<Film>.Filter.Empty;

            var films = _writeRepository.Find(filter).ToList();

            //if (request.IsNewest.HasValue && request.IsNewest.Value)
            //{
            //    films = films.OrderBy(n => n.DatePublish).ToList();
            //}

            //if (request.IsHighestRate.HasValue && request.IsHighestRate.Value)
            //{
            //    films = films.OrderBy(n => n.Rate).ToList();
            //}

            //films.FirstOrDefault().Type = Domain.Enum.FilmType.TinhCam;
            ViewBag.extraData = films;
            return View(films);
        }

        // GET api/values/5
        //[HttpGet("{id}")]
        public IActionResult Detail(string id)
        {
            var film = _writeRepository.Get<Film>(id);
            return View(film);
        }

        // POST api/values
        [HttpPost]
        public IActionResult Post([FromBody]Film film)
        {
            film.Id = Guid.NewGuid().ToString();
            _writeRepository.Create(film);
            return Ok();
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public IActionResult Put(string id, [FromBody]Film film)
        {
            _writeRepository.Replace(film);
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
