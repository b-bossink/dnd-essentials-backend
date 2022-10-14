﻿using System;
using System.Data.Entity;
using System.Linq;
using AutoMapper;
using Models;
using Models.ViewModel;
using Repository.Connection;

namespace Service.Mapper
{
	public static class ViewModelMapper
	{
        private static AutoMapper.Mapper _mapper;

        public static void Initialize()
        {
            var config = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<Character, CharacterViewModel>()
                .ForMember(dest => dest.CampaignIDs, act => act.MapFrom(src => src.Campaigns.Select(c => c.ID).ToList()))
                .ReverseMap()
                .ForMember(dest => dest.Campaigns, act => act.MapFrom(src => src.CampaignIDs.Select(id => new Campaign { ID = id }).ToList()));

                cfg.CreateMap<Campaign, CampaignViewModel>()
                .ForMember(dest => dest.CharacterIDs, act => act.MapFrom(src => src.Characters.Select(c => c.ID).ToList()))
                .ReverseMap()
                .ForMember(dest => dest.Characters, act => act.MapFrom(src => src.CharacterIDs.Select(id => new Character { ID = id }).ToList()));

                cfg.CreateMap<Character, GETCharacterViewModel>()
                .IncludeBase<Character, CharacterViewModel>();

                cfg.CreateMap<Campaign, GETCampaignViewModel>()
                .IncludeBase<Campaign, CampaignViewModel>();
            });

            _mapper = new AutoMapper.Mapper(config);
        }

        public static T Map<T>(object source)
        {
            if (_mapper != null)
            {
                return _mapper.Map<T>(source);
            }
            throw new InvalidOperationException("Mapper has not been initialized");
        }
    }
}

