﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using AvDennison.API.Contract.Requests;
using AvDennison.API.Contract.Responses;
using AvDennison.API.Contract.V1;
using AvDennison.API.Domain;
using AvDennison.API.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AvDennison.API.Controllers
{
    
    public class ArticlesController : ControllerBase
    {
        private readonly IArticlesService _articlesService;
        private readonly IUriService _uriService;
        private readonly IMapper _mapper;
        public ArticlesController(IArticlesService articlesService, IUriService uriService, IMapper mapper)
        {
            _articlesService = articlesService;
            _uriService = uriService;
            _mapper = mapper;
        }

        /// <summary>
        /// Returns every article in databse
        /// </summary>
        /// 
        /// <response code="200">Returns every article in database</response>
        
        [HttpGet(ApiRoutes.Articles.GetAll)]
        public async Task<IActionResult> Get() { 


            var articles = await _articlesService.GetArticlesAsync();
            if (articles == null)
                return NotFound();



            return Ok(_mapper.Map<List<GetArticleResponse>>(articles));

        }

        /// <summary>
        /// Returns article based on Id
        /// </summary>
        /// 
        /// <response code="200">Returns article with specified Id</response>
        /// <response code="404">Unable to find article with specified Id</response>
        /// /// <param name="articleId"></param>
        [HttpGet(ApiRoutes.Articles.Get)]
        public async Task<IActionResult> Get([FromRoute]int articleId)
        {
            var article = await _articlesService.GetArticleByIdAsync(articleId);

            if (article == null)
                return NotFound();
            return Ok(_mapper.Map<GetArticleResponse>(article));
        }


        /// <summary>
        /// Inserts new article in the database
        /// </summary>
        /// 
        /// <response code="201">Inserts article in the database</response>
        /// <response code="400">Unable to insert due to validation errors</response>
        /// <param name="request"></param>
        /// <returns></returns>
        [HttpPost(ApiRoutes.Articles.Insert)]
        public async Task<IActionResult> Insert([FromBody]ArticleInsertRequest request)
        {
         

           var response =  await _articlesService.CreateArticleAsync(request);
            if(response == null)
            {
                return BadRequest(new ErrorResponse(new ErrorModel { Message = "Unable to create article" }));
            }
           

            var locationUri = _uriService.GetPostUri(response.ArticleId.ToString());
            return Created(locationUri,(_mapper.Map<ArticleInsertResponse>(response)));
        }
    }
}