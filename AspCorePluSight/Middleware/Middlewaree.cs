using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AspCorePluSight.Middleware
{
    public class Middlewaree
    {
        private RequestDelegate _requestDelagate;

        public Middlewaree(RequestDelegate requestDelagate)
        {
            _requestDelagate = requestDelagate;

        }

        public async Task Invoke(HttpContext httpContext)
        {
            await _requestDelagate.Invoke(httpContext);

        }

    }
}
