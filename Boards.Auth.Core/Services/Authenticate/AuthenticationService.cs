﻿using System;
using System.Threading.Tasks;
using AutoMapper;
using Boards.Auth.Common.Error;
using Boards.Auth.Common.Result;
using Boards.Auth.Core.Dto.Authenticate;
using Boards.Auth.Core.Services.Token;
using Boards.Auth.Core.Token;
using Boards.Auth.Core.Validator;
using Boards.Auth.Database.Models.User;
using Boards.Auth.Database.Repositories;
using Common.Hashing;

namespace Boards.Auth.Core.Services.Authenticate
{
    public class AuthenticationService : IAuthenticateService
    {
        private readonly ITokenService _tokenService;
        private readonly IMapper _mapper;
        private readonly IPasswordHasher _passwordHasher;
        private readonly IBaseRepository _repository;

        public AuthenticationService 
        (
            ITokenService tokenService,
            IMapper mapper,
            IPasswordHasher passwordHasher,
            IBaseRepository repository
        )
        {
            _tokenService = tokenService;
            _mapper = mapper;
            _passwordHasher = passwordHasher;
            _repository = repository;
        }
        
        public async Task<ResultContainer<UserRegisterResponseDto>> Register(UserRegisterRequestDto data)
        {
            var result = new ResultContainer<UserRegisterResponseDto>();
            var isEmailValid = EmailValidator.EmailIsValid(data.Email);
            
            var user = _repository.GetOne<UserModel>(u => u.Email == data.Email);
            if (user != null || !isEmailValid)
            {
                result.ErrorType = ErrorType.BadRequest;
                return result;
            }

            user = _mapper.Map<UserModel>(data);
            user.Password = _passwordHasher.HashPassword(data.Password);
            user.DateCreated = DateTime.Now;

            result = _mapper.Map<ResultContainer<UserRegisterResponseDto>>(await _repository.Create(user));
            result.Data.AccessToken = CreateAccessToken(user).Data;
            return result;

        }
        
        public async Task<ResultContainer<UserLoginResponseDto>> Login(UserLoginRequestDto data)
        {
            var result = new ResultContainer<UserLoginResponseDto>();
            
            var user = _repository.GetOne<UserModel>(u => u.Email == data.Email);
            if (user == null)
            {
                result.ErrorType = ErrorType.NotFound;
                return result;
            }

            var isEqualPasswords = _passwordHasher.PasswordMatches(data.Password, user.Password);
            if (!isEqualPasswords)
            {
                result.ErrorType = ErrorType.BadRequest;
                return result;
            }

            result = _mapper.Map<ResultContainer<UserLoginResponseDto>>(user);
            result.Data.AccessToken = CreateAccessToken(user).Data;
            return result;
        }

        private ResultContainer<AccessToken> CreateAccessToken(UserModel data)
        {
            var result = _mapper.Map<ResultContainer<AccessToken>>(_tokenService.CreateAccessToken(data));
            return result;
        }
    }
}