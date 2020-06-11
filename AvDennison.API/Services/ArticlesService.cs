using AutoMapper;
using AvDennison.API.Contract.Requests;
using AvDennison.API.Contract.V1;
using AvDennison.API.Data;
using AvDennison.API.Domain;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AvDennison.API.Services
{
    public class ArticlesService : IArticlesService
    {
        //private readonly DataContext _dataContext;


        private readonly DataContext _context;
        private readonly IMapper _mapper;
        public ArticlesService(DataContext context, IMapper mapper) // konstruktor gdje kazemo da podatke dobavljamo preko contexta
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<Article> CreateArticleAsync(ArticleInsertRequest request)
        {

         
                var entity = _mapper.Map<Article>(request);

                await _context.Articles.AddAsync(entity);
                await _context.SaveChangesAsync();

                return _mapper.Map<Article>(entity);
            
           
        }

        public async Task<List<Article>> GetArticlesAsync()
        {
            return await _context.Articles.ToListAsync();
        }

        public async Task<Article> GetArticleByIdAsync(Guid articleId)
        {
         
            return await _context.Articles.SingleOrDefaultAsync(x => x.ArticleId == articleId);
        }
    }
}
