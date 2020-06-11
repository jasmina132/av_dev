using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AvDennison.API.Contract.Responses
{
    public class GetRevenueByArticleResponse
    {
        public string ArticleNumber { get; set; }
        public decimal TotalRevenue { get; set; }
    }
}
