namespace BookShop.Api.Models.Book
{
    public class BookWithCategoriesRequestModel : BookRequestModel
    {
        public string Categories { get; set; }
    }
}
