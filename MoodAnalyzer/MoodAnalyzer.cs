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
            if (message.Contains("sad")) {
                return "sad";
            }
            else if (message.Contains("happy")){
                return "happy";
            }
            else{
                return "happy";
            }
        }
    }
}
