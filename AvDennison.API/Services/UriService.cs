using AvDennison.API.Contract.V1;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AvDennison.API.Services
{
    public class UriService: IUriService
    {
        private readonly string _baseUri;

        public UriService(string baseUri)
        {
            _baseUri = baseUri;
        }

        public Uri GetPostUri(string articleId)
        {
            return new Uri(_baseUri + ApiRoutes.Articles.Get.Replace("{articleId}", articleId));
        }

    }
}
