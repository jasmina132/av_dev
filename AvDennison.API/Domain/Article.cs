using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace AvDennison.API.Domain
{
    public class Article
    {
        [Key]
        public int ArticleId { get; set; }

        public string ArticleNumber { get; set; }
        public decimal SalesPrice { get; set; }

        public ICollection<SaleItem> SaleItems { get; set; }

    }
}
