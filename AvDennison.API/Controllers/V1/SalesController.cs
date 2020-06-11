using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using AvDennison.API.Contract.Requests;
using AvDennison.API.Contract.V1;
using AvDennison.API.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AvDennison.API.Controllers
{
    
    public class SalesController : ControllerBase
    {
        private readonly ISalesService _salesService;
      
        public SalesController(ISalesService salesService)
        {
            _salesService = salesService;
        }

        /// <summary>
        /// Returns number of sold articles per day
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        /// <response code = "200">Returns number of sold articles per day</response>
        [HttpGet(ApiRoutes.Sales.GetNumberOfSoldByDay)]
        public IActionResult GetTotalNumber([FromQuery]GetSalesPerDayRequest request)
        {
            return Ok( _salesService.GetSalesByDate(request));
        }

        /// <summary>
        /// Returns total revenue per day
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        /// <response code = "200">Returns total revenue per day</response>
        [HttpGet(ApiRoutes.Sales.GetRevenueByDay)]
        public IActionResult GetRevenue([FromQuery]GetSalesPerDayRequest request)
        {
            return Ok (_salesService.GetRevenuePerDay(request));
        }

        /// <summary>
        /// Returns revenue grouped by articles
        /// </summary>
       
        /// <returns></returns>
        /// <response code = "200">Returns revenue grouped by articles</response>
        [HttpGet(ApiRoutes.Sales.GetRevenueByArticle)]
        public IActionResult GetRevenueByArticle()
        {
            return Ok(_salesService.GetRevenueByArticle());
        }

    }
}