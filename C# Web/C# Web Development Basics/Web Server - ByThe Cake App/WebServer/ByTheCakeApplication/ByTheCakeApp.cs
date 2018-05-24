namespace WebServer.ByTheCakeApplication
{
    using Server.Contracts;
    using Server.Routing.Contracts;
    using Controllers;

    public class ByTheCakeApp : IApplication
    {
        public void Configure(IAppRouteConfig appRouteConfig)
        {
            appRouteConfig.Get(
                "/",
                req => new HomeController().Index());
            appRouteConfig.Get(
                "/about",
                req => new HomeController().About());

            appRouteConfig
                .Get("/add", req => new CakesController().Add());

            appRouteConfig
                .Post("/add",
                    req => new CakesController().Add(
                        req.FormData["name"], req.FormData["price"]));

            appRouteConfig
                .Get("/search",
                    req => new CakesController().Search(req.UrlParameters));

            appRouteConfig
                .Get("/calculator",
                    req => new CalculatrorController().Calculate());

            appRouteConfig
                .Post("/calculator",
                    req => new CalculatrorController().Calculate(
                        req.FormData["firstnumber"], req.FormData["secondnumber"], req.FormData["operand"]));

            appRouteConfig
                .Get("/login", req => new AccountController().Login());

            appRouteConfig
                .Post("/login", req => new AccountController().Login(
                    req.FormData["username"], req.FormData["password"]));

            appRouteConfig
                .Get("/loginemail", req => new AccountController().AdminLogin());

            appRouteConfig
                .Post("/loginemail", req => new AccountController().AdminLogin(
                    req.FormData["username"], req.FormData["password"]));

            appRouteConfig
                .Get("/sendemail", req => new AccountController().SendEmail());

            appRouteConfig
                .Post("/sendemail", req => new AccountController().SendEmail(
                    req.FormData["recepient"], req.FormData["subject"], req.FormData["message"]));
        }
    }
}
