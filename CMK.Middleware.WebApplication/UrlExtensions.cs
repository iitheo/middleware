using Microsoft.AspNetCore.Builder;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CMK.Middleware.WebApplication
{
    public static class UrlExtensions
    {
        public static IApplicationBuilder UseUrlMiddleware(this IApplicationBuilder builder)
        {
            return builder.UseMiddleware<UrlMiddleware>();
        }
    }
}
