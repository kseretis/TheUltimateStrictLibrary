namespace TheUltimateStrictLibrary.Exceptions;

public class InvalidDataTypeException : Exception
{
    public InvalidDataTypeException() { }
    
    public InvalidDataTypeException(string? message) : base(message) { }
    
    public InvalidDataTypeException(string? message, Exception inner) : base(message, inner) { }

    /// <summary>
    /// Concat the message with the object and the class name. 
    /// eg -> "Value 'obj' of type 'clas', message" 
    /// </summary>
    /// <param name="obj">The value</param>
    /// <param name="clas">The class type</param>
    /// <param name="message">The message</param>
    public InvalidDataTypeException(object? obj, object? clas, string? message) : base($"Value '{obj!}' of type '{clas!}', {message}") { }
}
