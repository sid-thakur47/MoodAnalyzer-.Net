using NUnit.Framework;
using MoodAnalyzer_space;
using MoodAnalyzer_Main.exception;
using MoodAnalyzer_Main;
using System;

namespace MoodAnalyzer_Test
{
    public class Tests
    {
        [Test]
        public void given_Message_InMethod_ShouldReturnSad()
        {
            MoodAnalyzer moodAnalyzer = new MoodAnalyzer();
            string mood = moodAnalyzer.analyzeMood("i am in sad mood");
            Assert.AreEqual("sad", mood);
        }

        [Test]
        public void givenMessage_WhenContainsAnyMood_ShouldReturnHappy()
        {
            MoodAnalyzer moodAnalyzer = new MoodAnalyzer();
            string mood = moodAnalyzer.analyzeMood("i am in any mood");
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
        public void givenMoodAnalyserClass_WhenProper_ShouldReturnObject()
        {
            MoodAnalyzer analyzer = new MoodAnalyzer();
            MoodAnalyzer factoryAnalyzer = MoodAnalyzerFactory.CreateMoodAnalyzer("MoodAnalyzer_space.MoodAnalyzer","String");
            Assert.AreEqual(analyzer, factoryAnalyzer);
        }

        [Test]
        public void givenMoodAnalyserClass_WhenImProper_ShouldReturnClassNotFoundException()
        {
            try
            {
                MoodAnalyzerFactory.CreateMoodAnalyzer("MoodAnalyser","String");
            }
            catch (MoodAnalyzerException e)
            {
                Assert.AreEqual(MoodAnalyzerException.ExceptionType.CLASS_NOT_FOUND_EXCEPTION, e.type);

            }
        }

        [Test]
        public void givenMoodAnalyserConstructor_WhenImProper_ShouldReturnMethodNotFoundException()
        {
            try
            {
                MoodAnalyzerFactory.CreateMoodAnalyzer("MoodAnalyzer","Int");
            }
            catch (MoodAnalyzerException e)
            {
                Assert.AreEqual(MoodAnalyzerException.ExceptionType.METHOD_NOT_FOUND_EXCEPTION, e.type);

            }

        }
    }
}