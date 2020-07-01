using NUnit.Framework;
using MoodAnalyzer_space;
using MoodAnalyzer_Main.exception;
using MoodAnalyzer_Main;
using System;
using System.Reflection;

namespace MoodAnalyzer_Test
{
    public class Tests
    {
        [Test]
        public void given_Message_InMethod_ShouldReturnSad()
        {
            MoodAnalyzer moodAnalyzer = new MoodAnalyzer();
            string mood = moodAnalyzer.AnalyzeMood("i am in sad mood");
            Assert.AreEqual("sad", mood);
        }

        [Test]
        public void givenMessage_WhenContainsAnyMood_ShouldReturnHappy()
        {
            MoodAnalyzer moodAnalyzer = new MoodAnalyzer();
            string mood = moodAnalyzer.AnalyzeMood("i am in any mood");
            Assert.AreEqual("happy", mood);
        }

        [Test]
        public void given_Message_InConstructor_IamInSadMood_ShouldReturnSad()
        {
            MoodAnalyzer moodAnalyzer = new MoodAnalyzer("i am in sad mood");
            string mood = moodAnalyzer.analyzeMood();
            Assert.AreEqual("sad", mood);
        }

        [Test]
        public void givenMessage_InConstructor_WhenContainsHappy_ShouldReturnHappy()
        {
            MoodAnalyzer moodAnalyzer = new MoodAnalyzer("i am in happy mood");
            string mood = moodAnalyzer.analyzeMood();
            Assert.AreEqual("happy", mood);
        }

        [Test]
        public void GivenMessageInConstructor_WhenNull_ShouldThowMoodAnalysisException()
        {
            try
            {
                MoodAnalyzer moodAnalyzer = new MoodAnalyzer(null);
                string mood = moodAnalyzer.analyzeMood();
            }
            catch (MoodAnalyzerException e)
            {
                Assert.AreEqual(MoodAnalyzerException.ExceptionType.NULL_EXCEPTION, e.type);
            }
        }

        [Test]
        public void givenMessageInConstructor_WhenEmpty_ShouldThowMoodAnalysisException()
        {
            try
            {
                MoodAnalyzer moodAnalyzer = new MoodAnalyzer("");
                string mood = moodAnalyzer.analyzeMood();
            }
            catch (MoodAnalyzerException e)
            {
                Assert.AreEqual(MoodAnalyzerException.ExceptionType.EMPTY_EXCEPTION, e.type);
            }
        }

        [Test]
        public void GivenClassName_WhenImproper_ShouldthrowException()
        {
            try
            {
                MoodAnalyzerFactory<MoodAnalyzer> moodAnalyserFactory = new MoodAnalyzerFactory<MoodAnalyzer>();
                ConstructorInfo constInfo = moodAnalyserFactory.GetConstructor();
                object createdObject = moodAnalyserFactory.CreateObjectUsingClass("wrong",constInfo);
            }
            catch (MoodAnalyzerException e)
            {
                Assert.AreEqual("Class not found", e.Message);
            }
        }

    
        [Test]
        public void GivenConstructor_WhenImproper_ShouldthrowException()
        {
            try
            {
                MoodAnalyzerFactory <MoodAnalyzer>moodAnalyserFactory = new MoodAnalyzerFactory<MoodAnalyzer>();
                ConstructorInfo constInfo = null;
                object createdObject = moodAnalyserFactory.CreateObjectUsingClass("MoodAnalyzer",constInfo);
            }
            catch (MoodAnalyzerException e)
            {
                Assert.AreEqual("Method not found", e.Message);
            }
        }
    }
}