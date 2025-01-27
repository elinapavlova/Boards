﻿using System;
using System.Threading.Tasks;
using Boards.Auth.Common.Error;
using Boards.Auth.Common.Result;
using Microsoft.AspNetCore.Mvc;

namespace Boards.Auth.Api.Controllers
{
    public class BaseController : Controller
    {
        protected async Task<ActionResult> ReturnResult<T, TM>(Task<T> task) where T : ResultContainer<TM>
        {
            var result = await task;
            
            if (result.ErrorType.HasValue)
            {
                return result.ErrorType switch
                {
                    ErrorType.NotFound => NotFound(),
                    ErrorType.BadRequest => BadRequest(),
                    ErrorType.Unauthorized => Unauthorized(),
                    _ => throw new ArgumentOutOfRangeException()
                };
            }

            if (result.Data == null) 
                return NoContent();
            
            return Ok(result.Data);
        }
    }
}