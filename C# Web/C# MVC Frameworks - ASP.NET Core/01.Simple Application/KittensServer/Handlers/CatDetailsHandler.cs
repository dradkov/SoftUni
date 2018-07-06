namespace KittensServer.Handlers
{
    using System;
    using System.Linq;
    using Contracts;
    using Infrastructure;
    using Kittens.Data;
    using Microsoft.AspNetCore.Http;
    using Microsoft.Extensions.DependencyInjection;

    public class CatDetailsHandler : IHandler
    {
        public int Order => 3;

        public Func<HttpContext, bool> Condition
            => ctx => ctx.Request.Path.Value.StartsWith("/cat/") &&
                      ctx.Request.Method == HttpMethod.Get;

        public RequestDelegate RequestHandler
            => async context =>
            {
                var urlTokens = context.Request.Path.Value
                    .Split("/", StringSplitOptions.RemoveEmptyEntries);

                if (urlTokens.Length < 2)
                {
                    context.Response.Redirect("/");
                    return;
                }

                int.TryParse(urlTokens[1], out int catId);
                if (catId <= 0)
                {
                    context.Response.Redirect("/");
                    return;
                }

                using (var db = context.RequestServices.GetRequiredService<CatsDbContext>())
                {
                    var cat = db.Cats.FirstOrDefault(c => c.Id == catId);
                    if (cat == null)
                    {
                        context.Response.Redirect("/");
                        return;
                    }

                    await context.Response.WriteAsync($"<h1>{cat.Name}</h1>");
                    await context.Response.WriteAsync(
                        $@"<img src=""{cat.ImageUrl}"" alt=""{cat.Name}"" width=""400""/>");
                    await context.Response.WriteAsync($"<h3>Age: {cat.Age}</h3>");
                    await context.Response.WriteAsync($"<h3>Breed: {cat.Breed}</h3>");
                }
            };
    }
}
