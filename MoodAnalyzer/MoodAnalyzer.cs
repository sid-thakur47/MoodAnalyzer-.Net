using System;
using MoodAnalyzerExceptions;

namespace MoodAnalyzers
{
#pragma warning disable CS0659 // Type overrides Object.Equals(object o) but does not override Object.GetHashCode()
    public class MoodAnalyzer

    {
        private string message;
        ////Constructor without parameter
      
        public MoodAnalyzer()
        {
            this.message = string.Empty;
        }

        ////parameterized constructor
        public MoodAnalyzer(string message)
        {
            this.message = message;
        }

        ////To return the mood of the message
        public string AnalyzeMood()
        {
            return AnalyzeMood(message);
        }

        ////To return the mood of the message
        public string AnalyzeMood(string message)
        {
            try
            { 
                if (message.Equals(string.Empty))
            {
                throw new MoodAnalyzerException("Message Cannot be Empty", MoodAnalyzerException.ExceptionType.EMPTY);
            }
            if (message.Contains("sad"))
                {
                    return "sad";
                }
                else
                {
                    return "happy";
                }
            }
            catch (NullReferenceException)
            {
                throw new MoodAnalyzerException("Message Cannot be Null", MoodAnalyzerException.ExceptionType.NULL);
            }

        }

        ////To check if two objects are equal
        override
      public bool Equals(object that)
        {
            MoodAnalyzer moodAnalyser = (MoodAnalyzer)that;
            if (this.message.Equals(moodAnalyser.message))
            {
                return true;
            }
            return false;
        }
    }
}