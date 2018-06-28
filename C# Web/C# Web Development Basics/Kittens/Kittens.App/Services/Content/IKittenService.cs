namespace Kittens.App.Services.Content
{
    using System.Collections.Generic;
    using Kittens.App.Models;

    public interface IKittenService
  {
      bool Create(string name, string age, string breed);

      IEnumerable<ShowAllMaci> All();

  }
}
