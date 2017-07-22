namespace LettersChangeNumbers
{
    using System;

    public class ChangeNumbersLetters
    {
        static void Main(string[] args)
        {


            var words = Console.ReadLine().Split(new[] { ' ', '\t', '\n', '\r' }, StringSplitOptions.RemoveEmptyEntries); ;




            for (int i = 0; i < words.Length; i++)
            {
                var firstLetter = words[i].Substring(0, 1);
                var middDigit = int.Parse(words[i].Substring(1, words[i].Length - 2));
                var lastLetter = words[i].Substring(words[i].Length - 1);

                var alphaBetFirstUpper = GetUpperFirstAlphaBet(firstLetter);
                var alphabetfirstlower = Getlowerfirstalphabet(firstLetter);

                var alphaBetSecondUpper = GetUpperSecondAlphaBet(lastLetter);
                var alphaBetSecondLower = GetLowerSecondAlphaBet(lastLetter);


            }

        }

        private static int GetLowerSecondAlphaBet(string lastLetter)
        {
            var result = 0;

            switch (lastLetter)
            {
                case "a": result = 1; break;
                case "b": result = 2; break;
                case "c": result = 3; break;
                case "d": result = 4; break;
                case "e": result = 5; break;
                case "f": result = 6; break;
                case "g": result = 7; break;
                case "h": result = 8; break;
                case "i": result = 9; break;
                case "j": result = 10; break;
                case "k": result = 11; break;
                case "l": result = 12; break;
                case "m": result = 13; break;
                case "n": result = 14; break;
                case "o": result = 15; break;
                case "p": result = 16; break;
                case "q": result = 17; break;
                case "r": result = 18; break;
                case "s": result = 19; break;
                case "t": result = 20; break;
                case "u": result = 21; break;
                case "v": result = 22; break;
                case "w": result = 23; break;
                case "x": result = 24; break;
                case "y": result = 25; break;
                case "z": result = 26; break;

                default:
                    break;
            }
            return result;
        }

        private static int GetUpperSecondAlphaBet(string lastLetter)
        {
            var result = 0;

            switch (lastLetter)
            {
                case "A": result = 1; break;
                case "B": result = 2; break;
                case "C": result = 3; break;
                case "D": result = 4; break;
                case "E": result = 5; break;
                case "F": result = 6; break;
                case "G": result = 7; break;
                case "H": result = 8; break;
                case "I": result = 9; break;
                case "J": result = 10; break;
                case "K": result = 11; break;
                case "L": result = 12; break;
                case "M": result = 13; break;
                case "N": result = 14; break;
                case "O": result = 15; break;
                case "P": result = 16; break;
                case "Q": result = 17; break;
                case "R": result = 18; break;
                case "S": result = 19; break;
                case "T": result = 20; break;
                case "U": result = 21; break;
                case "V": result = 22; break;
                case "W": result = 23; break;
                case "X": result = 24; break;
                case "Y": result = 25; break;
                case "Z": result = 26; break;

                default:
                    break;
            }
            return result;
        }

        private static int Getlowerfirstalphabet(string firstLetter)
        {
            var result = 0;

            switch (firstLetter)
            {
                case "a": result = 1; break;
                case "b": result = 2; break;
                case "c": result = 3; break;
                case "d": result = 4; break;
                case "e": result = 5; break;
                case "f": result = 6; break;
                case "g": result = 7; break;
                case "h": result = 8; break;
                case "i": result = 9; break;
                case "j": result = 10; break;
                case "k": result = 11; break;
                case "l": result = 12; break;
                case "m": result = 13; break;
                case "n": result = 14; break;
                case "o": result = 15; break;
                case "p": result = 16; break;
                case "q": result = 17; break;
                case "r": result = 18; break;
                case "s": result = 19; break;
                case "t": result = 20; break;
                case "u": result = 21; break;
                case "v": result = 22; break;
                case "w": result = 23; break;
                case "x": result = 24; break;
                case "y": result = 25; break;
                case "z": result = 26; break;

                default:
                    break;
            }
            return result;
        }

        private static int GetUpperFirstAlphaBet(string firstLetter)
        {
            var result = 0;

            switch (firstLetter)
            {
                case "A":result = 1;break;
                case "B":result = 2;break;
                case "C":result = 3;break;
                case "D":result = 4;break;
                case "E":result = 5;break;
                case "F":result = 6;break;
                case "G":result = 7;break;
                case "H":result = 8;break;
                case "I":result = 9;break;
                case "J":result = 10;break;
                case "K":result = 11;break;
                case "L":result = 12;break;
                case "M":result = 13;break;
                case "N":result = 14;break;
                case "O":result = 15;break;
                case "P":result = 16;break;
                case "Q":result = 17;break;
                case "R":result = 18;break;
                case "S":result = 19;break;
                case "T":result = 20;break;
                case "U":result = 21;break;
                case "V":result = 22;break;
                case "W":result = 23;break;
                case "X":result = 24;break;
                case "Y":result = 25;break;
                case "Z":result = 26;break;

                default:
                    break;
            }
            return result;
        }
    }
}
