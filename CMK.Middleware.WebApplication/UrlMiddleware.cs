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

        public Task Invoke(HttpContext context)
        {
            if (context.Request.Path == "/")
                context.Request.Path = "/api/values";

            return _next(context);
        }
    }
}
