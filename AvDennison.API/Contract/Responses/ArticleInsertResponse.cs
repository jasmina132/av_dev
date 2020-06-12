using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AvDennison.API.Contract.V1
{
    public class ArticleInsertResponse
    {
        public int ArticleId { get; set; }
        public string ArticleNumber { get; set; }
        public string SalesPrice { get; set; }
    }
}
