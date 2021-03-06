﻿using AutoMapper;
using AvDennison.API.Contract.Requests;
using AvDennison.API.Contract.Responses;
using AvDennison.API.Contract.V1;
using AvDennison.API.Data;
using AvDennison.API.Domain;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AvDennison.API.Services
{
    public class SalesService : ISalesService
    {
        private readonly DataContext _context;
        private readonly IMapper _mapper;
        public SalesService(DataContext context, IMapper mapper) 
        {
            _context = context;
            _mapper = mapper;
        }



        public async Task<List<Sale>> GetSalesAsync()
        {
            return await _context.Sales.ToListAsync();
        }

        public async Task<Sale> GetSalesAsync(int saleId)
        {
            return await _context.Sales.SingleOrDefaultAsync(x => x.SaleId == saleId);

        }

        public List<GetNumberByDayResponse> GetSalesByDate(GetSalesPerDayRequest request)
        {


            List<GetNumberByDayResponse> response = _context.SaleItems.Include(y => y.Sale)
                .Where(x => x.Sale.Date >= request.dateFrom && x.Sale.Date <= request.dateTo)
                .GroupBy(x => x.Sale.Date)
                .Select(t => new GetNumberByDayResponse
                {
                    Date = t.Key.ToShortDateString(),
                    TotalNumber = t.Sum(x => x.Quantity)
                }).ToList();



            return response;
        }

        public List<GetRevenueByArticleResponse> GetRevenueByArticle()
        {

            List<GetRevenueByArticleResponse> responses = _context.Articles
                .Select(t => new GetRevenueByArticleResponse
                {
                    ArticleId = t.ArticleId,
                    ArticleNumber = t.ArticleNumber,
                    TotalRevenue = t.SalesPrice * t.SaleItems.Sum(x => x.Quantity)
                }).ToList();

            //OK
            return responses;
        }
        public List<GetSalesRevenuePerDayResponse> GetRevenuePerDay(GetSalesPerDayRequest request)
        {


            List<GetSalesRevenuePerDayResponse> response = _context.SaleItems
                .Include(y => y.Sale)
                .Include(x => x.Article)
                .Where(x => x.Sale.Date >= request.dateFrom && x.Sale.Date <= request.dateTo)
                .Select(t => new GetSalesRevenuePerDayResponse
                {
                    Date = t.Sale.Date.ToShortDateString(),
                    TotalRevenue = (t.Quantity * t.Article.SalesPrice)
                }).ToList().GroupBy(x => x.Date).Select(a => new GetSalesRevenuePerDayResponse
                {
                    Date = a.Key,
                    TotalRevenue = a.Sum(x => x.TotalRevenue)
                }).ToList();



            // com
            return response;

        }


    }
}
