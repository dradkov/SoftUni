namespace Phone
{
    using System.Collections.Generic;

    public interface ICallable
    {
        void Calling(IEnumerable<string> phoneNumber);
    }
}

