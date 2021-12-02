using AutoMapper;
using Common.Result;
using Core.Dto.Authenticate;
using Core.Dto.User;
using Core.Token;
using Database.Models.User;

namespace Core.Profiles
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