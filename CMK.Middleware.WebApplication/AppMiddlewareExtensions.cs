using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CMK.Middleware.WebApplication
{
    public static class AppMiddlewareExtensions
    {
        public static void UseExtensions(this IApplicationBuilder app)
        {
            app.Use(async (context, next) => {
                Console.WriteLine("Before first middleware request");
                await context.Response.WriteAsync("<html><body>Enter First middleware<br />");
                await next();
                await context.Response.WriteAsync("Return from First middleware<br />");
                Console.WriteLine("After first middleware request");
            });

            app.UseWhen(c => c.Request.Query.ContainsKey("role"), a => {
                a.Use(async (context, next) => {
                    await context.Response.WriteAsync($"Enter {context.Request.Query["role"]}<br />");
                    await next();
                    await context.Response.WriteAsync($"Return {context.Request.Query["role"]}<br />");
                });
            });

            app.Map("/map", a => {
                a.Map("/branch", x => {
                    x.Run(async context => {
                        await context.Response.WriteAsync("Entered child map.<br />");
                    });
                });
                a.Run(async context => {
                    await context.Response.WriteAsync("Entered map.<br />");
                });
            });

            app.MapWhen(c => c.Request.Query.ContainsKey("count"), a => {
                a.Run(async (context) => {
                    await context.Response.WriteAsync($"Entered map when with count {context.Request.Query["count"]} . <br />");
                });
            });

            app.Run(async context => {
                Console.WriteLine("Before terminal middleware request");
                await context.Response.WriteAsync("Terminal middleware<br /></body></html>");
                Console.WriteLine("After terminal middleware request");
            });

        }
    }
}
