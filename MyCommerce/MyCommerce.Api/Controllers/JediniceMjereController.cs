using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MyCommerce.Model;
using MyCommerce.Model.SearchObjects;
using MyCommerce.Services.Interfaces;

namespace MyCommerce.Api.Controllers
{
    public class JediniceMjereController : BaseController<Model.JediniceMjere,JediniceMjereSearchObject>
    {
        public JediniceMjereController(IJediniceMjereService service, ILogger<JediniceMjereController> logger) : base(service, logger) { }

    }
}
