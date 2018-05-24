namespace WebServer.ByTheCakeApplication.Controllers
{
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;
    using Infrastructure;
    using Models;
    using Server.Http.Contracts;

    public class CakesController : Controller
    {
        private const string DBFileName = @"ByTheCakeApplication\Data\database.csv";

        private static readonly IList<Cake> cakes = new List<Cake>();


        public IHttpResponse Add()
        {
            Dictionary<string, string> cakeValues = new Dictionary<string, string>
            {
                ["showResult"] = "none"
            };

            return this.FileViewResponse(@"cakes\add", cakeValues);
        }

        public IHttpResponse Add(string name, string price)
        {
            Cake cake = new Cake(name, decimal.Parse(price));

            cakes.Add(cake);

            using (var streamWriter = new StreamWriter(DBFileName, true))
            {
                streamWriter.WriteLine($"{name},{price}");
            }

            Dictionary<string, string> cakeValues = new Dictionary<string, string>
            {
                ["name"] = name,
                ["price"] = price,
                ["display"] = "block"
            };

            return this.FileViewResponse(@"cakes\add", cakeValues);
        }

        public IHttpResponse Search(IDictionary<string, string> urlParameters)
        {
            const string SearchTermKey = "searchTerm";
            const char Delimeter = ',';

            string results = string.Empty;

            if (urlParameters.ContainsKey(SearchTermKey))
            {
                string searchTerm = urlParameters[SearchTermKey];

                var savedCakes = File
                    .ReadAllLines(DBFileName)
                    .Where(line => line.Contains(Delimeter))
                    .Select(line => line.Split(Delimeter))
                    .Select(line => new Cake(line[0], decimal.Parse(line[1])))
                    .Where(c => c.Name.ToLower().Contains(searchTerm.ToLower()))
                    .OrderBy(c => c.Name)
                    .Select(c => $"<div>{c.Name} - ${c.Price:f2}</div>")
                    .ToList();

                results = string.Join(Environment.NewLine, savedCakes);
            }
            Dictionary<string, string> cakeValues = new Dictionary<string, string>
            {
                ["results"] = results
            };
            return this.FileViewResponse(@"cakes\search", cakeValues);
        }

    }
}
