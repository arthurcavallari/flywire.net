using System;

namespace Flywire_WinForm
{
    [Serializable()]
    public class UnknownAudioFormatException : ApplicationException
    {
        public UnknownAudioFormatException() 
            : base("Unknown Audio Format encountered!") { }
        public UnknownAudioFormatException(string message) 
            : base("Unknown Audio Format encountered: " + message) { }
        public UnknownAudioFormatException(string message, Exception InnerException)
            : base("Unknown Audio Format encountered: " + message, InnerException) { }
        public UnknownAudioFormatException(System.Runtime.Serialization.SerializationInfo info,
        System.Runtime.Serialization.StreamingContext context) { }


    }

    public class InvalidShowNameFoundException : Exception
    {
        public InvalidShowNameFoundException()
            : base("Invalid Show Name encountered!") { }
        public InvalidShowNameFoundException(string message)
            : base("Invalid Show Name encountered: " + message) { }
        public InvalidShowNameFoundException(string message, Exception InnerException)
            : base("Invalid Show Name encountered: " + message, InnerException) { }
        public InvalidShowNameFoundException(System.Runtime.Serialization.SerializationInfo info,
        System.Runtime.Serialization.StreamingContext context) { }
    }

    public class InvalidTrackFoundException : Exception
    {
        public InvalidTrackFoundException()
            : base("Invalid Track encountered!") { }
        public InvalidTrackFoundException(string message)
            : base("Invalid Track encountered: " + message) { }
        public InvalidTrackFoundException(string message, Exception InnerException)
            : base("Invalid Track encountered: " + message, InnerException) { }
        public InvalidTrackFoundException(System.Runtime.Serialization.SerializationInfo info,
        System.Runtime.Serialization.StreamingContext context)  { }
    }

    public class TrackAlreadyExistsException : Exception
    {
        public TrackAlreadyExistsException()
            : base("Track already exists in media list!") { }
        public TrackAlreadyExistsException(string message)
            : base("Track already exists in media list: " + message) { }
        public TrackAlreadyExistsException(string message, Exception InnerException)
            : base("Track already exists in media list: " + message, InnerException) { }
        public TrackAlreadyExistsException(System.Runtime.Serialization.SerializationInfo info,
        System.Runtime.Serialization.StreamingContext context)  { }
    }

    
}
