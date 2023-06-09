﻿using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MyCommerce.Model;
using MyCommerce.Services.Interfaces;

namespace MyCommerce.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProizvodiController : ControllerBase
    {
        private readonly IProizvodiService _proizvodiService;

        public ProizvodiController(IProizvodiService proizvodiService)
        {
            _proizvodiService = proizvodiService;
        }

        [HttpGet(Name = "GetProizvodi")]
        public IEnumerable<Model.Proizvodi> Get()
        {
            return _proizvodiService.Get();
        }
    }
}
