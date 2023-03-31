
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using MyCommerce.Model;
using MyCommerce.Model.SearchObjects;
using MyCommerce.Services.Database;
using MyCommerce.Services.Interfaces;

namespace MyCommerce.Services.Services
{
    public class JediniceMjereService : BaseService<Model.JediniceMjere, Database.JediniceMjere, JediniceMjereSearchObject>, IJediniceMjereService
    {
        public JediniceMjereService(EProdajaContext context, IMapper mapper) : base(context, mapper) { }

       

        public override IQueryable<Database.JediniceMjere> AddFilter(IQueryable<Database.JediniceMjere> querry, JediniceMjereSearchObject? search = null)
        {
            if (!string.IsNullOrWhiteSpace(search?.Naziv))
            {
                querry = querry.Where(i => i.Naziv.StartsWith(search.Naziv)); //gre[ka treba assignati
            }

            if (!string.IsNullOrWhiteSpace(search?.FTS))
            {
                querry = querry.Where(i => i.Naziv.Contains(search.FTS)); //gre[ka treba assignati
            }

            return base.AddFilter(querry, search);
        }
    }
}
