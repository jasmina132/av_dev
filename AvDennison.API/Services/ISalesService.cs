using AvDennison.API.Contract.Requests;
using AvDennison.API.Contract.Responses;
using AvDennison.API.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AvDennison.API.Services
{
    public interface ISalesService
    {
        Task<List<Sale>> GetSalesAsync();
        List<GetNumberByDayResponse> GetSalesByDate(GetSalesPerDayRequest request);
        List<GetSalesRevenuePerDayResponse> GetRevenuePerDay(GetSalesPerDayRequest request);
        List<GetRevenueByArticleResponse> GetRevenueByArticle();

        //  Task<bool> CreateSaleAsync(Sale sale);
    }
}
