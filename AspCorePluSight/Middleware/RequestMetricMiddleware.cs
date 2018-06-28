using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace AspCorePluSight.Middleware
{
    public class RequestMetricMiddleware
    {
        private readonly ILogger _logger;
        private readonly RequestDelegate _next;

        public RequestMetricMiddleware(RequestDelegate next, ILogger<RequestDelegate> logger)
        {
            _logger = logger;
            _next = next;
        }

        public async Task Invoke(HttpContext context)
        {

            DateTime startedAt = DateTime.Now;

            await _next.Invoke(context);

            DateTime finishedAt = DateTime.Now;
            _logger.LogInformation(string.Format("---------- Started at : {0}, Finished at : {1}, Elapsed ms : {2}------------", startedAt, finishedAt, (finishedAt - startedAt).TotalMilliseconds));

        }


    }
}
