﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace AvDennison.API.Domain
{
    public class SaleItem
    {
        [Key]
        public int SaleItemId { get; set; }

        public int Quantity { get; set; }


        public Article Article { get; set; }
        public int ArticleId { get; set; }

        public Sale Sale { get; set; }
        public int SaleId { get; set; }
    }
}
