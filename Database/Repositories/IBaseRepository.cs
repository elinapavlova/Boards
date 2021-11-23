using System;
using System.Threading.Tasks;
using Common.Base;

namespace Core.Repositories
{
    public interface IBaseRepository
    {
        TModel GetOne<TModel>(Func<TModel, bool> predicate) where TModel : BaseModel;
        Task<TModel> Create<TModel>(TModel item) where TModel : BaseModel;
    }
}