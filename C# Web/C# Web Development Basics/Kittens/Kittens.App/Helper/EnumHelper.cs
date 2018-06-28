using System;
using System.Collections.Generic;
using System.Text;

namespace Kittens.App.Helper
{
    using Kittens.Models.Enums;

    public static class EnumHelper  
    {
        public static string ConvertEnum(BreedType breed)
        {
            switch (breed)
            {
                case BreedType.StreetTranscended: return "Street Transcended";
                case BreedType.AmericanShorthair: return "American Shorthair";
                case BreedType.Munchkin: return "Munchkin";
                case BreedType.Siamese: return "Siamese";
                default: return "Invalid type";
            }
        }
    }
}
