using System;
using System.Collections.Generic;
using System.Text;

namespace MoodAnalyzer_Main.exception
{
    public class MoodAnalyzerException :Exception

{
        public enum ExceptionType
        {
            NULL_EXCEPTION, EMPTY_EXCEPTION
        }
        public ExceptionType type;
        public MoodAnalyzerException(String message, ExceptionType type) : base(message)
        {
            this.type = type;
        }
    }
}
