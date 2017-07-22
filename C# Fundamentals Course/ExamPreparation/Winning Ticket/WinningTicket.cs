namespace WinningTicket
{
    using System;
    using System.Linq;
    using System.Text;
    using System.Text.RegularExpressions;

    class WinningTicket
    {
        static void Main(string[] args)
        {
            var tickets = Console.ReadLine().Split(new char[] { ',', ' ' }, StringSplitOptions.RemoveEmptyEntries).Select(x => x.Trim());

            var patern = @"(\${6,}|\@{6,}|\#{6,}|\^{6,})";

            var regex = new Regex(patern);

            var result = new StringBuilder();

            foreach (var ticket in tickets)
            {
                if (ticket.Length!=20)
                {
                    result.Append($"invalid ticket{Environment.NewLine}");
                    continue;
                }

                var leftMatch = regex.Match(ticket.Substring(0, 10));
                var rightMatch = regex.Match(ticket.Substring(10));
                var minLen = Math.Min(leftMatch.Length ,rightMatch.Length);

                if (!leftMatch.Success|| !rightMatch.Success)
                {
                    result.Append($"ticket \"{ticket}\" - no match{Environment.NewLine}");
                    continue;
                }

                var leftPart = leftMatch.Value.Substring(0, minLen);
                var rightPart = rightMatch.Value.Substring(0, minLen);

                if (leftPart.Equals(rightPart))
                {
                    if (leftPart.Length == 10)
                    {
                        result.Append($"ticket \"{ ticket}\" - {minLen}{leftPart.Substring(0, 1)} Jackpot!{Environment.NewLine}");
                    }
                    else
                    {
                        result.Append($"ticket \"{ ticket}\" - {minLen}{leftPart.Substring(0, 1)}{Environment.NewLine}");
                    }
                }
                else
                {
                    result.Append($"ticket \"{ ticket}\" - no match{Environment.NewLine}");
                }
            }

            Console.Write(result.ToString());
        }
    }
}
