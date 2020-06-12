using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace AvDennison.API.Domain
{
    public class Sale
    {
        [Key]
        public int SaleId { get; set; }
       

        public DateTime Date { get; set; }

        public ICollection<SaleItem> SaleItems { get; set; }
    }
}
