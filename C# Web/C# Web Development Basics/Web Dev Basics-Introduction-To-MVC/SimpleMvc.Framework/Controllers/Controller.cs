namespace SimpleMvc.Framework.Controllers
{
    using System.Runtime.CompilerServices;
    using Contracts;
    using Contracts.Generic;
    using Helpers;
    using ViewEngine;
    using ViewEngine.Generic;

    public abstract class Controller
    {
        protected IActionResult View([CallerMemberName] string caller = "")
        {
            string controllerName = ControllerHelpers.GetControllerName(this);

            string viewFullQualifieldName = ControllerHelpers.GetViewFullQualifiedName(controllerName, caller);

            return new ActionResult(viewFullQualifieldName);


        }
        protected IActionResult View(string controller, string action)
        {
            string viewFullQualifieldName = ControllerHelpers.GetViewFullQualifiedName(controller, action);

            return new ActionResult(viewFullQualifieldName);
        }


        protected IActionResult<TModel> View<TModel>(TModel model, [CallerMemberName]string caller = "")
        {
            string controllerName = ControllerHelpers.GetControllerName(this);

            string viewFullQualifieldName = ControllerHelpers.GetViewFullQualifiedName(controllerName, caller);

            return new ActionResult<TModel>(viewFullQualifieldName, model);
        }

        protected IActionResult<TModel> View<TModel>(TModel model, string controller, string action)
        {
            string viewFullQualifieldName = ControllerHelpers.GetViewFullQualifiedName(controller, action);

            return new ActionResult<TModel>(viewFullQualifieldName, model);
        }
    }
}
