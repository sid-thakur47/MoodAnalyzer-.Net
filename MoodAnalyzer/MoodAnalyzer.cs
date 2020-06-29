using System;

namespace MoodAnalyzer_space
{
   public class MoodAnalyzer
    {
        private String message;

        public MoodAnalyzer(){
        }

        public MoodAnalyzer(String message){
            this.message = message;
        }

        public string analyzeMood(){
            return analyzeMood(message);
        }

        public String analyzeMood(string message){
            try
            {
                if (message.Contains("sad")){
                    return "sad";
                }
                else {
                    return "happy";
                }
            }
            catch (NullReferenceException e){
                return "happy";
            }

        }
    }
}