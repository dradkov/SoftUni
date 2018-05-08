namespace SocialNetwork.Data.Atributes
{
    using System;
    using System.ComponentModel.DataAnnotations;
    using System.Text.RegularExpressions;

    [Obsolete]
    public class TagAttribute : ValidationAttribute
    {
        public override bool IsValid(object value)
        {
            string pattern = @"^#([a-zA-Z0-9]{1,19})$";

            string input = value.ToString();

            Regex rgx = new Regex(pattern);

            if (rgx.IsMatch(input))
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
