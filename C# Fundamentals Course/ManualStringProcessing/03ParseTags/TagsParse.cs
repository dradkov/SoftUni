namespace ParseTags
{
    using System;

    public class TagsParse
    {
        static void Main()
        {
            var textInput = Console.ReadLine();

            var openTag = "<upcase>";
            var closeTag = "</upcase>";


            var startIndex = textInput.IndexOf(openTag);


            while (startIndex != -1)
            {
                var endIndex = textInput.IndexOf(closeTag);
                if (endIndex == -1)
                {
                    break;
                }

                var toBeReplaced =
                    textInput.Substring(startIndex, endIndex + closeTag.Length - startIndex);

                var replaced = toBeReplaced.Replace(openTag, string.Empty).Replace(closeTag, string.Empty).ToUpper();

                textInput = textInput.Replace(toBeReplaced, replaced);

                startIndex = textInput.IndexOf(openTag);
            }

            Console.WriteLine(textInput);
        }
    }
}
