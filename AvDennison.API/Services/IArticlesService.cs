using AvDennison.API.Contract.Requests;
using AvDennison.API.Contract.Responses;
using AvDennison.API.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using static AvDennison.API.Contract.V1.ApiRoutes;

namespace AvDennison.API.Services
{
    public interface IArticlesService
    {
        Task<List<Article>> GetArticlesAsync();
        
        Task<Article> CreateArticleAsync(ArticleInsertRequest request);

        Task<Article> GetArticleByIdAsync(Guid articleId);
    }
}
