﻿using System.Threading.Tasks;
using Common.Result;
using Core.Authenticate;
using Core.Dto.Authenticate;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers
{
    [ApiVersion("1.0")]
    [ApiController]
    [Route("/api/v{version:apiVersion}/[controller]/[action]")]
    public class AuthController : BaseController
    {
        private readonly IAuthenticateService _authenticateService;
        
        public AuthController(IAuthenticateService authenticateService)
        {
            _authenticateService = authenticateService;
        }
        
        /// <summary>
        /// Register user
        /// </summary>
        /// <param name="user"></param>
        /// <response code="200">Return user Id and token</response>
        /// <response code="400">If the user already exists or Email is not valid</response>
        [HttpPost]
        [AllowAnonymous]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<ResultContainer<UserRegisterResponseDto>>> Register(UserRegisterRequestDto user)
        {
            return await ReturnResult<ResultContainer<UserRegisterResponseDto>, UserRegisterResponseDto>
                (_authenticateService.Register(user));
        }

        /// <summary>
        /// Login user
        /// </summary>
        /// <param name="user"></param>
        /// <response code="200">Return access token, refresh tokens and expiration</response>
        /// <response code="404">If the user doesn't exist</response>
        /// <response code="400">If the password is not right</response>
        [HttpPost]
        [AllowAnonymous]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<ResultContainer<UserLoginResponseDto>>> Login(UserLoginRequestDto user)
        {
            return await ReturnResult<ResultContainer<UserLoginResponseDto>, UserLoginResponseDto>
                (_authenticateService.Login(user));
        }
    }
}