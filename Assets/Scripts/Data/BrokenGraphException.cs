using System;
using System.Runtime.Serialization;

[Serializable]
internal class BrokenGraphException : Exception
{
    public BrokenGraphException()
    {
    }

    public BrokenGraphException(string message) : base(message)
    {
    }

    public BrokenGraphException(string message, Exception innerException) : base(message, innerException)
    {
    }

    protected BrokenGraphException(SerializationInfo info, StreamingContext context) : base(info, context)
    {
    }
}