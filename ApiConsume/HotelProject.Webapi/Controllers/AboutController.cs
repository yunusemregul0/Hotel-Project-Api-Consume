﻿using HotelProject.BusinessLayer.Abstract;
using HotelProject.EntityLayer.Concrete;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace HotelProject.Webapi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AboutController : ControllerBase
    {
        private readonly IAboutService _aboutService;

        public AboutController(IAboutService aboutService)
        {
            _aboutService = aboutService;
        }

        [HttpGet]
        public IActionResult ServiceList()
        {
            var values = _aboutService.GetList();
            return Ok(values);
        }

        [HttpPost]
        public IActionResult AddService(About about)
        {
            _aboutService.TInsert(about);
            return Ok();
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteService(int id)
        {
            var values = _aboutService.TGetById(id);
            _aboutService.TDelete(values);
            return Ok();
        }

        [HttpPut]
        public IActionResult UpdateService(About about)
        {
            _aboutService.TUpdate(about);
            return Ok();
        }

        [HttpGet("{id}")]
        public IActionResult GetService(int id)
        {
            var values = _aboutService.TGetById(id);
            return Ok(values);
        }
    }
}
