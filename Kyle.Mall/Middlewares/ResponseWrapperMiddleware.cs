﻿using Kyle.Extensions;
using Kyle.Extensions.WebApi.Models;
using Newtonsoft.Json;
using System.Net;

namespace Kyle.Mall.Middlewares
{
    public class ResponseWrapperMiddleware
    {
        private readonly RequestDelegate _next;

        public ResponseWrapperMiddleware(RequestDelegate next)
        {
            _next = next;
        }


        public async Task InvokeAsync(HttpContext context)
        {
            var originBody = context.Response.Body;

            using var memoryStream = new MemoryStream();
            context.Response.Body = memoryStream;

            await _next(context);

            if (context.Response.StatusCode == (int)HttpStatusCode.OK)
            {
                context.Response.Body = originBody;
                memoryStream.Seek(0, SeekOrigin.Begin);
                var readToEnd = new StreamReader(memoryStream).ReadToEnd();
                var objResult = JsonConvert.DeserializeObject(readToEnd);
                var result = new AjaxResponse(context.Response.StatusCode, context.Response.StatusCode.ToString(), objResult);

                await context.Response.WriteAsync(result.ToJsonString());
            }
        }
    }
}
