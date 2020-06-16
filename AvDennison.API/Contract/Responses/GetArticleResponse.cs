using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AvDennison.API.Contract.Responses
{
    public class GetArticleResponse
    {
        public int ArticleId { get; set; }

        public string ArticleNumber { get; set; }
        public decimal SalesPrice { get; set; }
    }
}
