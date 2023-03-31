
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using MyCommerce.Model;
using MyCommerce.Model.SearchObjects;
using MyCommerce.Services.Database;
using System.Collections.Generic;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;

namespace MyCommerce.Services
{
    public abstract class BaseService<T, TDb, TSearch> : IBaseService<T, TSearch> where T : class where TDb : class where TSearch : BaseSearchObject
    {
        protected readonly EProdajaContext _context;
        protected readonly IMapper _mapper;

        public BaseService(EProdajaContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public virtual IQueryable<TDb> AddFilter(IQueryable<TDb> querry, TSearch? search = null)
        {
            return querry;
        }

        public virtual async Task<PagedResult<T>> Get(TSearch? search = null)
        {
            //var items = await _context.Set<TDb>().ToListAsync();

            //var models = new List<T>();
            //_mapper.Map(items, models);

            //return models;

            var items = _context.Set<TDb>().AsQueryable();

            PagedResult<T> pagedResult = new PagedResult<T>();


            int count =items.Count();

            items = AddFilter(items, search); //ponovo ista kreška teba assign


            if (search?.PageNumber.HasValue == true && search?.PageSize.HasValue == true)
            {
                items = items.Take(search.PageSize.Value).Skip(search.PageNumber.Value * search.PageSize.Value);
            }

            var models = await items.ToListAsync();

            pagedResult.Result = _mapper.Map<List<T>>(models);
            pagedResult.Count= count;

            return pagedResult;
        }

        public virtual async Task<T> GetById(int id)
        {
            var entity = await _context.Set<TDb>().FindAsync(id);

            var model = _mapper.Map<T>(entity);

            return model;
        }
    }
}
