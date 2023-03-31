
using AutoMapper;
using MyCommerce.Model.SearchObjects;
using MyCommerce.Services.Database;

namespace MyCommerce.Services
{
    public class VrsteProizvodumService:BaseService<Model.VrsteProizvodum,VrsteProizvodum,BaseSearchObject>, IVrsteProizvodumService
    {
        public VrsteProizvodumService(EProdajaContext context , IMapper mapper) :base(context ,mapper) { }
       
    }
}
