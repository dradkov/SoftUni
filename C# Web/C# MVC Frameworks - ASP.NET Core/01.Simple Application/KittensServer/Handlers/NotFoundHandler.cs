namespace KittensServer.Handlers
{
    using Infrastructure;
    using Microsoft.AspNetCore.Http;

    public class NotFoundHandler
    {
        public static RequestDelegate RequestHandler
            => async (context) =>
            {
                context.Response.StatusCode = HttpStatusCode.NotFound;
                await context.Response.WriteAsync("404 Page was not found :(");
            };
    }
}
