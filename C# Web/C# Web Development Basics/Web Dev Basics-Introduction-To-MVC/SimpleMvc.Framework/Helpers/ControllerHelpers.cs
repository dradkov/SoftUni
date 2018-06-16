namespace SimpleMvc.Framework.Helpers
{
    public static class ControllerHelpers
    {
        public static string GetControllerName(object obj)=> obj.GetType().Name.Replace(MvcContext.Get.ControllersSuffix, string.Empty);

        public static string GetViewFullQualifiedName(string controler,string action)=> string.Format("{0}.{1}.{2}.{3},{0}", MvcContext.Get.AssemblyName, MvcContext.Get.ViewsFolder, controler, action);
    }
}
