using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AvDennison.API.Contract.V1
{
    public class ApiRoutes
    {
        public const string Root = "api";

        public const string Version = "v1";

        public const string Base = Root + "/" + Version;
        public static class Sales
        {
            public const string GetAll = Base + "/sales";

            public const string Insert = Base + "/sales";

            public const string GetNumberOfSoldByDay = Base + "/sales/sales-number-by-day";
            public const string GetRevenueByDay = Base + "/sales/sales-revenue-by-day";
            public const string GetRevenueByArticle = Base + "/sales/sales-revenue-by-article";


        }

        public static class Articles
        {
            public const string GetAll = Base + "/articles";

            public const string Insert = Base + "/articles";

            public const string Get = Base + "/articles/{articleId}";

        }

    }
}
