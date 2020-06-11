using AutoMapper;
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
        public SalesService(DataContext context, IMapper mapper) // konstruktor gdje kazemo da podatke dobavljamo preko contexta
        {
            _context = context;
            _mapper = mapper;
        }



        public async Task<List<Sale>> GetSalesAsync()
        {
            return await _context.Sales.ToListAsync();
        }

        public async Task<Sale> GetSalesAsync(Guid saleId)
        {
            return await _context.Sales.SingleOrDefaultAsync(x => x.SaleId == saleId);

        }

        public List<GetNumberByDayResponse> GetSalesByDate(GetSalesPerDayRequest request)
        {

            List<GetNumberByDayResponse> responses = new List<GetNumberByDayResponse>();



            //var queryRes = (from s in _context.Sales
            //                from si in _context.SaleItems.Where(si => si.SaleId == s.SaleId).DefaultIfEmpty()
            //                where s.Date >= request.dateFrom && s.Date <= request.dateTo
            //                select new
            //                {
            //                    s.Date,
            //                    s.SaleItems
            //                }).ToList();

            var queryRes = (
                    from s in _context.Sales
                    from si in _context.SaleItems.Where(si => si.SaleId == s.SaleId).DefaultIfEmpty()
                    group si by new { s.Date, s.SaleId } into g
                    select new
                    {
                        date = g.Key.Date,
                        sum = g.Sum(t => t.Quantity),
                        saleid = g.Key.SaleId
                    }).ToList();


            foreach (var item in queryRes)
            {
                responses.Add(new GetNumberByDayResponse
                {
                    Day = item.date.DayOfWeek.ToString(),
                    Date = item.date.ToShortDateString(),
                    TotalNumber = item.sum
                });
            }

            return responses;
        }

        public List<GetRevenueByArticleResponse> GetRevenueByArticle()
        {



            List<GetRevenueByArticleResponse> responses = new List<GetRevenueByArticleResponse>();

            var queryRes = (from s in _context.Articles
                            from si in _context.SaleItems.Where(st => st.ArticleId == s.ArticleId).DefaultIfEmpty()
                            select new
                            {
                                si.Quantity,
                                s.ArticleNumber,
                                s.SalesPrice
                            }).ToList();

            foreach (var item in queryRes)
            {
                responses.Add(new GetRevenueByArticleResponse
                {
                    ArticleNumber = item.ArticleNumber,
                    TotalRevenue = item.SalesPrice * item.Quantity
                });
            }

            return responses;
        }
        public List<GetSalesRevenuePerDayResponse> GetRevenuePerDay(GetSalesPerDayRequest request)
        {

            List<GetSalesRevenuePerDayResponse> responses = new List<GetSalesRevenuePerDayResponse>();

            var queryRes = (from s in _context.Sales
                            from si in _context.SaleItems.Where(st => st.SaleId == s.SaleId).DefaultIfEmpty()
                            from a in _context.Articles.Where(ar => ar.ArticleId == si.ArticleId)
                            where s.Date >= request.dateFrom && s.Date <= request.dateTo
                            select new
                            {
                                s.Date,
                                s.SaleItems,
                                a.SalesPrice,
                                si.Quantity
                            }).ToList();




            //var queryRes1 = (
            //                    from si in _context.SaleItems
            //                    join a in _context.Articles on si.ArticleId equals a.ArticleId
            //                    join s in _context.Sales on si.SaleId equals s.SaleId
            //                    into joined
            //                    from merged in joined.DefaultIfEmpty()
            //                    group new { a.SalesPrice, si.Quantity, merged }
            //                     by new
            //                     {
            //                         date = merged.Date,
            //                         saleid = merged.SaleId,
            //                         qu = si.Quantity,
            //                         p = a.SalesPrice
            //                     } into g


            //                    select new
            //                    {
            //                        date = g.Key.date,
            //                        sum = g.Sum(t => t.Quantity * t.SalesPrice),
            //                        saleid = g.Key.saleid
            //                    }).GroupBy(x => x.saleid).ToList();



         



            foreach (var item in queryRes)
            {
                responses.Add(new GetSalesRevenuePerDayResponse
                {
                    Day = item.Date.DayOfWeek.ToString(),
                    Date = item.Date.ToShortDateString(),
                    TotalRevenue = item.SalesPrice * item.Quantity
                });
            }

            var rep = responses.GroupBy(x => x.Date).Select(x =>
                            new GetSalesRevenuePerDayResponse
                            {
                                Day = (Convert.ToDateTime(x.Key)).DayOfWeek.ToString(),
                                TotalRevenue = x.Sum(y => y.TotalRevenue),
                                Date = (Convert.ToDateTime(x.Key)).Date.ToShortDateString()

                            }).ToList();


            return rep;

        }


    }
}
