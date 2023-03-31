
using AutoMapper;
using MyCommerce.Model.Requests;

namespace MyCommerce.Services
{
    public class MappingProfile:Profile
    {
        public MappingProfile()
        {
            CreateMap<Database.Korisnici,Model.Korisnici>();
            CreateMap<KorisniciInsertRequest, Database.Korisnici>();
            CreateMap<KorisniciUpdateRequest, Database.Korisnici>();
            CreateMap<Database.JediniceMjere, Model.JediniceMjere>();
            CreateMap<Database.VrsteProizvodum, Model.VrsteProizvodum>();
        }
    }
}
