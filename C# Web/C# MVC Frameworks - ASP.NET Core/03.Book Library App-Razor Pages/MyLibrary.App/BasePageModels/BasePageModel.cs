using Microsoft.AspNetCore.Mvc.RazorPages;
using MyLibrary.Data;

namespace MyLibrary.App.BasePageModels
{
    public class BasePageModel : PageModel
    {
        public BasePageModel(MyLibraryContext context)
        {
            this.Context = context;
        }

        protected MyLibraryContext Context { get; private set; }
    }
}
