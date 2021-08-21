using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CMK.Middleware.WebApplication
{
    public class UrlMiddleware
    {
        private readonly RequestDelegate _next;

        public UrlMiddleware(RequestDelegate next)
        {
            _next = next;
        }
    }
}
