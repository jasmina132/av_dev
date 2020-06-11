using AvDennison.API.Domain;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace AvDennison.API.Contract.Responses
{
    public class GetNumberByDayResponse
    {
      
        public string Day { get; set; }

        public int TotalNumber { get; set; }

        public string Date { get; set; }

       
    }
}
