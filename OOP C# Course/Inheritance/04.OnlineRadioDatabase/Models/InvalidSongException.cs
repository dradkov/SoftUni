namespace OnlineRadioDatabase.Models
{
    using System;

    public class InvalidSongException : Exception
    {
        private string exception = "Invalid song.";


        protected virtual string ExceptionMessege
        {
            get { return this.exception; }

            set
            {
                this.exception = value;

            }

        }
        public override string Message => ExceptionMessege;
    }
}

