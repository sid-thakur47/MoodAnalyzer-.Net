using System;

namespace MoodAnalyzerExceptions
{
    /// <summary>
    /// /To Throws Custom MoodAnalyzer Exception
    /// </summary>
    public class MoodAnalyzerException : Exception
{
        public ExceptionType ExceptionTypes;

        //// Initlialization
        public MoodAnalyzerException(string message, ExceptionType type) 
        : base(message)
        {
            this.ExceptionTypes = type;
        }

        ////Types of exception
        public enum ExceptionType
        {
            NULL, EMPTY,
            CLASS_NOT_FOUND,
            METHOD_NOT_FOUND
        }
    }
}
