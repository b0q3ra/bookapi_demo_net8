using System.Net;

namespace BooksApi.Middleware {

    public class RequestLogMiddleware {
        // Request delegate
        private RequestDelegate next;

        public RequestLogMiddleware(RequestDelegate next) {
            this.next = next;
        }

        public async Task Invoke(HttpContext httpContext) {
            System.Net.IPAddress ip = httpContext.Connection.RemoteIpAddress;
            Console.WriteLine($"Remote Ip Address: {ip.ToString()}");
            await next(httpContext);
        }

    }
}