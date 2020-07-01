using MoodAnalyzer_Main.exception;
using System;

namespace MoodAnalyzers
{
#pragma warning disable CS0659 // Type overrides Object.Equals(object o) but does not override Object.GetHashCode()
    public class MoodAnalyzer

    {
        private  String message;

        public MoodAnalyzer()
        {
            message = "";
        }

        //parameterized constructor
        public MoodAnalyzer(String message)
        {
            this.message = message;
        }

        //To return the mood of the message
        public string AnalyzeMood()
        {
            return AnalyzeMood(message);
        }

        //To return the mood of the message
        public String AnalyzeMood(string message)
        {
            try
            { 
                if (message.Equals(""))
            {
                throw new MoodAnalyzerException("Message Cannot ne Empty", MoodAnalyzerException.ExceptionType.EMPTY_EXCEPTION);
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
            catch (NullReferenceException ){
                throw new MoodAnalyzerException("Message Cannot be Null", MoodAnalyzerException.ExceptionType.NULL_EXCEPTION);
            }

        }

        //To check if two objects are equal
        override
      public bool Equals(Object that)
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