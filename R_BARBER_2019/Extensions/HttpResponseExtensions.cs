﻿using Microsoft.AspNetCore.Http;

namespace R_BARBER_2019.Extensions
{
    public static class HttpResponseExtensions
    {
        public static void AddApplicationError(this HttpResponse response, string message)
        {
            response.Headers.Add("Application-Error", message);
            // CORS
            response.Headers.Add("access-control-expose-headers", "Application-Error");
        }
    }
}
