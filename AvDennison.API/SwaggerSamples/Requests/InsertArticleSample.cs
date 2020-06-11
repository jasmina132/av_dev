using AvDennison.API.Contract.Requests;
using Swashbuckle.AspNetCore.Filters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AvDennison.API.SwaggerSamples.Requests
{
    public class InsertArticleSample : IExamplesProvider<ArticleInsertRequest>
    {
        public ArticleInsertRequest GetExamples()
        {
            return new ArticleInsertRequest
            {
                ArticleNumber = "article123",
                SalesPrice = 100
            };
        }

    }
}
