﻿using AutoMapper;
using Domain.Dtos.User;
using Domain.Entities;

namespace CrossCutting.Mappings
{
    public class EntityToDtoProfile : Profile
    {
        public EntityToDtoProfile()
        {
            CreateMap<UserDto, UserEntity>().ReverseMap();
            CreateMap<UserDtoResult, UserEntity>().ReverseMap();
        }
    }
}
