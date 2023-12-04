using Entities;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Components.RenderTree;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Hosting;
using Service;
using System;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace ex1.middleware
{
    // You may need to install the Microsoft.AspNetCore.Http.Abstractions package into your project
    public class RatingMiddleware
    {
        private readonly RequestDelegate _next;

        public RatingMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task Invoke(HttpContext httpContext, IRatingService ratingService)
        {
            Rating rating = new Rating();
         
            rating.Host = httpContext.Request.Host.ToString();
            rating.Method = httpContext.Request.Method;
            rating.Path = httpContext.Request.Path;
            rating.Referer = httpContext.Request.Headers["Referer"].ToString();
            rating.UserAgent = httpContext.Request.Headers["User-Agent"].ToString();
            rating.RecordDate = DateTime.Now;
            await ratingService.addRating(rating);
            await _next(httpContext);
        }
    }

    // Extension method used to add the middleware to the HTTP request pipeline.
    public static class RatingMiddlewareExtensions
    {
        public static IApplicationBuilder UseRatingMiddleware(this IApplicationBuilder builder)
        {
            return builder.UseMiddleware<RatingMiddleware>();
        }
    }
}
