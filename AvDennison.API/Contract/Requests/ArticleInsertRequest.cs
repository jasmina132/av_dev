using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace AvDennison.API.Contract.Requests
{
    public class ArticleInsertRequest
    {
      
        public string ArticleNumber { get; set; }
    
        public int SalesPrice { get; set; }
    }
}
