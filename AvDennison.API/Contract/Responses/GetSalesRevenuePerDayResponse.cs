using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace AvDennison.API.Contract.Requests
{
 
    public class GetSalesRevenuePerDayResponse
    {

        public decimal TotalRevenue { get; set; }

        public string Date { get; set; }
    }
}
