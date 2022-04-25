using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;

namespace SushiBarApp.Helpers
{
    public class HttpContextAccessor : IHttpContextAccessor
    {
        private static AsyncLocal<HttpContext> _httpContextCurrent = new AsyncLocal<HttpContext>();
        HttpContext IHttpContextAccessor.HttpContext { get => _httpContextCurrent.Value; set => _httpContextCurrent.Value = value; }
    }
}
