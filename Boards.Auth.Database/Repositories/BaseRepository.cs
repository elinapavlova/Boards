using System;
using System.Linq;
using System.Threading.Tasks;
using Boards.Auth.Common.Base;
using Microsoft.EntityFrameworkCore;

namespace Boards.Auth.Database.Repositories
{
    public class BaseRepository : IBaseRepository
    {
        private readonly AppDbContext _context;

        public BaseRepository(AppDbContext context)
        {
            _context = context;
        }
        
        public TModel GetOne<TModel>(Func<TModel, bool> predicate) where TModel : BaseModel
        {
            return _context.Set<TModel>().AsNoTracking().FirstOrDefault(predicate);
        }
        
        public async Task<TModel> Create<TModel>(TModel item) where TModel : BaseModel
        {
            item.DateCreated = DateTime.UtcNow;
            await _context.Set<TModel>().AddAsync(item);
            await _context.SaveChangesAsync();
            return item;
        }
    }
}