using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CMK.Middleware.WebApplication
{
    public class CustomMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly IPrinter _printer;

        public CustomMiddleware(RequestDelegate next, IPrinter printer)
        {
            _next = next;
            _printer = printer;
        }

        public async Task Invoke(HttpContext httpContext)
        {
            await httpContext.Response.WriteAsync("<p>Entered custom middleware</p>");
            await _next(httpContext);
            _printer.Print();
        }
    }
}
