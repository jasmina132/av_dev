using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AvDennison.API.Services
{
    public interface IUriService
    {
       
            Uri GetPostUri(string articleId);
        
    }
}
