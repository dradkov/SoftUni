namespace OnlineRadioDatabase.Models
{
    public class InvalidSongNameException : InvalidArtistNameException
    {
        public override string Message => "Song name should be between 3 and 30 symbols.";
    }
}
