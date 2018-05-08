namespace SocialNetwork.Data.Models.TagValidation
{
    using System.Linq;
    using System.Text.RegularExpressions;

    public static class TagValidator
    {
        public static bool ValidateTag(string tag)
        {
            string pattern = @"^#([a-zA-Z0-9]{1,19})$";

            Regex rgx = new Regex(pattern);

            if (rgx.IsMatch(tag))
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
