using AutoMapper;
using BookstoreApi.Core.Domain;
using BookstoreApi.Core.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BookstoreApi.App_Start
{
    public class AutoMapperProfile: Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<BookReadDto, Book>();
            CreateMap<Book, BookReadDto>()
                .ForMember(dest => dest.Authors, m => m.MapFrom(source => string.Join(", ", source.Authors.Select(a => a.Name))));
            CreateMap<BookUpdateDto, Book>()
                .ForMember(dest => dest.Id, opt => opt.Ignore())
                .ForAllMembers(opts => opts.Condition((src, dest, srcMember) => !(srcMember.GetType() == typeof(int) && (int)srcMember == 0)));
        }
        public static void Run()
        {
            AutoMapper.Mapper.Initialize(a =>
            {
                a.AddProfile<AutoMapperProfile>();
            });
        }
    }
}