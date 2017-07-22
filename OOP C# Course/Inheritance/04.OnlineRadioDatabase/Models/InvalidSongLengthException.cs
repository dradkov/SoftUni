namespace OnlineRadioDatabase.Models
{
    public class InvalidSongLengthException : InvalidSongNameException
    {
        public override string Message => "Invalid song length.";
    }
}


