using System;

namespace MyFunctionApp;

public class WelcomeMessage : IEquatable<WelcomeMessage>
{
    public string Message { get; set; }

    public bool Equals(WelcomeMessage other)
    {
        if (ReferenceEquals(null, other)) return false;
        if (ReferenceEquals(this, other)) return true;
        return Message == other.Message;
    }

    public override bool Equals(object obj)
    {
        if (ReferenceEquals(null, obj)) return false;
        if (ReferenceEquals(this, obj)) return true;
        if (obj.GetType() != this.GetType()) return false;
        return Equals((WelcomeMessage)obj);
    }

    public override int GetHashCode()
    {
        return (Message != null ? Message.GetHashCode() : 0);
    }
}