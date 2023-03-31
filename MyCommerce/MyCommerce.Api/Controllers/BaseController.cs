using Microsoft.AspNetCore.Mvc;
using MyCommerce.Model;
using MyCommerce.Model.SearchObjects;
using MyCommerce.Services;

namespace MyCommerce.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BaseController<T,TSearch> : ControllerBase  where T : class where TSearch : BaseSearchObject
    {
        private readonly IBaseService<T, TSearch> _service;
        private readonly ILogger<BaseController<T, TSearch>> _logger;

        public BaseController(IBaseService<T, TSearch> service, ILogger<BaseController<T, TSearch>> logger)
        {
            _service = service;
            _logger = logger;
        }

        [HttpGet]
        public async Task<PagedResult<T>> Get([FromQuery] TSearch? search=null)
        {
            return await _service.Get(search);
        }

        [HttpGet("{id}")]
        public async Task<T> GetById(int id)
        {
            return await _service.GetById(id);
        }
    }
}
