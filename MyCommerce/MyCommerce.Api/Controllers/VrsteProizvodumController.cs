using MyCommerce.Model;
using MyCommerce.Model.SearchObjects;
using MyCommerce.Services;

namespace MyCommerce.Api.Controllers
{
    public class VrsteProizvodumController : BaseController<Model.VrsteProizvodum,BaseSearchObject>
    {
        public VrsteProizvodumController(IVrsteProizvodumService service, ILogger<VrsteProizvodumController> logger) : base(service, logger)
        {
            
        }
        
    }
}
