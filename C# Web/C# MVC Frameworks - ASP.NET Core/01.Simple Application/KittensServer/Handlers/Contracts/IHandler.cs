﻿namespace KittensServer.Handlers.Contracts
{
    using System;
    using Microsoft.AspNetCore.Http;

    public interface IHandler
    {
        int Order { get; }

        Func<HttpContext, bool> Condition { get; }

        RequestDelegate RequestHandler { get; }
    }
}
