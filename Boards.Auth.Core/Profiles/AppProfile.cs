using AutoMapper;
using Boards.Auth.Common.Result;
using Boards.Auth.Core.Dto.Authenticate;
using Boards.Auth.Core.Dto.User;
using Boards.Auth.Core.Token;
using Boards.Auth.Database.Models.User;

namespace Boards.Auth.Core.Profiles
{
    public class AppProfile : Profile
    {
        public AppProfile()
        {
            CreateMap<UserModel, UserRegisterResponseDto>();    
            CreateMap<UserModel, UserLoginResponseDto>();
            
            CreateMap<UserRegisterRequestDto, UserModel>();  
            
            CreateMap<UserLoginResponseDto, ResultContainer<UserLoginResponseDto>>()
                .ForMember(x => x.Data, opt =>
                    opt.MapFrom(u => u));
            
            CreateMap<UserModelDto, ResultContainer<UserModelDto>>()
                .ForMember(x => x.Data, opt =>
                    opt.MapFrom(u => u));
            
            CreateMap<UserModel, ResultContainer<UserRegisterResponseDto>>()
                .ForMember(x => x.Data, opt =>
                    opt.MapFrom(u => u));
            CreateMap<UserModel, ResultContainer<UserLoginResponseDto>>()
                .ForMember(x => x.Data, opt =>
                    opt.MapFrom(u => u));

            CreateMap<AccessToken, ResultContainer<AccessToken>>()
                .ForMember(x => x.Data, opt =>
                    opt.MapFrom(u => u));
            
            CreateMap<UserRegisterResponseDto, ResultContainer<UserRegisterResponseDto>>()
                .ForMember(x => x.Data, opt =>
                    opt.MapFrom(u => u));
        }
    }
}