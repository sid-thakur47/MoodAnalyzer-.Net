using NUnit.Framework;
using MoodAnalyzer_space;

namespace MoodAnalyzer_Test
{
    public class Tests
    {
        [Test]
        public void given_Message_InMethod_ShouldReturnSad(){
            MoodAnalyzer moodAnalyzer = new MoodAnalyzer();
            string mood = moodAnalyzer.analyzeMood("i am in sad mood");
            Assert.AreEqual("sad", mood);  
        }

        [Test]
        public void givenMessage_WhenContainsAnyMood_ShouldReturnHappy(){
            MoodAnalyzer moodAnalyzer = new MoodAnalyzer();
            string mood = moodAnalyzer.analyzeMood("i am in any mood");
            Assert.AreEqual("happy", mood);
        }

        [Test]
        public void given_Message_InConstructor_IamInSadMood_ShouldReturnSad(){
            MoodAnalyzer moodAnalyzer = new MoodAnalyzer("i am in sad mood");
            string mood = moodAnalyzer.analyzeMood();
            Assert.AreEqual("sad", mood);
        }

        [Test]
        public void givenMessage_InConstructor_WhenContainsHappy_ShouldReturnHappy(){
            MoodAnalyzer moodAnalyzer = new MoodAnalyzer("i am in happy mood");
            string mood = moodAnalyzer.analyzeMood();
            Assert.AreEqual("happy", mood);
        }

        [Test]
        public void givenMessage_InConstructor_WhenContainsNull_ShouldReturnHappy()
        {
            MoodAnalyzer moodAnalyzer = new MoodAnalyzer(null);
            string mood = moodAnalyzer.analyzeMood();
            Assert.AreEqual("happy", mood);
        }
    }
}