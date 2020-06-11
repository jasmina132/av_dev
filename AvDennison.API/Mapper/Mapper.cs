using AvDennison.API.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;

using AvDennison.API.Contract.Requests;
using AvDennison.API.Contract.V1;
using AvDennison.API.Contract.Responses;

namespace AvDennison.API.Mapper
{
    public class Mapper:Profile
    {
        public Mapper()
        {
            
            CreateMap<Article, ArticleInsertRequest>().ReverseMap();
            CreateMap<Article, ArticleInsertResponse>().ReverseMap();
            CreateMap<Article, GetArticleResponse>().ReverseMap();


        }
    }
}
