using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Storage;
using MyCommerce.Model.Requests;
using MyCommerce.Services.Database;
using MyCommerce.Services.Interfaces;

namespace MyCommerce.Api.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class KorisniciController : ControllerBase
    {
        private readonly IKorisniciService service;

        public KorisniciController(IKorisniciService korisniciService)
        {
            this.service = korisniciService;
        }

        [HttpGet(Name ="GetKorisnici")]
        public async Task<IEnumerable<Model.Korisnici>> Get()
        {
            return await service.Get();
        }

        [HttpPost(Name ="InsertKorisnika")]
        public Model.Korisnici Insert([FromBody] KorisniciInsertRequest request)
        {
            return service.Insert(request);
        }

        [HttpPut("{id}")]
        public Model.Korisnici Update(int id, KorisniciUpdateRequest request)
        {
            return service.Update(id, request);
        }

        [HttpDelete("{id}")]
        public Model.Korisnici Delete(int id)
        {
            return service.Delete(id);
        }
    }
}
