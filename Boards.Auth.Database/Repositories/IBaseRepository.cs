﻿using System;
using System.Threading.Tasks;
using Boards.Auth.Common.Base;

namespace Boards.Auth.Database.Repositories
{
    public interface IBaseRepository
    {
        TModel GetOne<TModel>(Func<TModel, bool> predicate) where TModel : BaseModel;
        Task<TModel> Create<TModel>(TModel item) where TModel : BaseModel;
    }
}