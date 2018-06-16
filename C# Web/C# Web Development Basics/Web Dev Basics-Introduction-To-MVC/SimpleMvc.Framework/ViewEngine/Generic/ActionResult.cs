namespace SimpleMvc.Framework.ViewEngine.Generic
{
    using System;
    using Contracts.Generic;

    public class ActionResult<TModel> : IActionResult<TModel>
    {

        public ActionResult(string viewFullQualifiedName, TModel model)
        {
            this.Action = (IRenderable<TModel>)Activator.CreateInstance(Type.GetType(viewFullQualifiedName));

            this.Action.Model = model;
        }

        public string Invoke() => this.Action.Render();

        public IRenderable<TModel> Action { get; set; }
    }
}
