using NUnit.Framework;
using MoodAnalyzer_space;

namespace MoodAnalyzer_Test
{
    public class Tests
    {
        [Test]
        public void givenMessage_WhenContainsSad_ShouldReturnSad(){
            MoodAnalyzer moodAnalyzer = new MoodAnalyzer();
            string mood = moodAnalyzer.analyzeMood("sad");
            Assert.AreEqual("sad", mood);
        }

        [Test]
        public void givenMessage_WhenContainsAnyMood_ShouldReturnHappy(){
            MoodAnalyzer moodAnalyzer = new MoodAnalyzer();
            string mood = moodAnalyzer.analyzeMood("any");
            Assert.AreEqual("happy", mood);
        }

        [Test]
        public void givenMessageInConstructor_WhenContainsSad_ShouldReturnSad(){
            MoodAnalyzer moodAnalyzer = new MoodAnalyzer("sad");
            string mood = moodAnalyzer.analyzeMood();
            Assert.AreEqual("sad", mood);
        }

        [Test]
        public void givenMessageInConstructor_WhenContainsHappy_ShouldReturnHappy(){
            MoodAnalyzer moodAnalyzer = new MoodAnalyzer("happy");
            string mood = moodAnalyzer.analyzeMood();
            Assert.AreEqual("happy", mood);
        }
    }
}