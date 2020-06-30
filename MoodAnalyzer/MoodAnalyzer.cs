using MoodAnalyzer_Main.exception;
using System;

namespace MoodAnalyzer_space
{
   public class MoodAnalyzer
    {
        private String message;

        public MoodAnalyzer()
        {
        }

        public MoodAnalyzer(String message)
        {
            this.message = message;
        }

        public string analyzeMood()
        {
            return analyzeMood(message);
        }

        public String analyzeMood(string message){
            try
            { 
                if (message.Length == 0)
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
            catch (NullReferenceException e){
                throw new MoodAnalyzerException("Message Cannot be Null", MoodAnalyzerException.ExceptionType.NULL_EXCEPTION);
            }

        }
    }
}