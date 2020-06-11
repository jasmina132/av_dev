using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace AvDennison.API.Contract.Requests
{
 
    public class GetSalesPerDayRequest
    {
        public DateTime dateFrom { get; set; }
    
        public DateTime dateTo { get; set; }
    }
}
