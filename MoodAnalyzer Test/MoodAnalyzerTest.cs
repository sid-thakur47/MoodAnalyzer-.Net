using NUnit.Framework;
using MoodAnalyzers;
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
            string mood = moodAnalyzer.AnalyzeMood();
            Assert.AreEqual("sad", mood);
        }

        [Test]
        public void givenMessage_InConstructor_WhenContainsHappy_ShouldReturnHappy()
        {
            MoodAnalyzer moodAnalyzer = new MoodAnalyzer("i am in happy mood");
            string mood = moodAnalyzer.AnalyzeMood();
            Assert.AreEqual("happy", mood);
        }

        [Test]
        public void GivenMessageInConstructor_WhenNull_ShouldThowMoodAnalysisException()
        {
            try
            {
                MoodAnalyzer moodAnalyzer = new MoodAnalyzer(null);
                string mood = moodAnalyzer.AnalyzeMood();
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
                string mood = moodAnalyzer.AnalyzeMood();
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
                ConstructorInfo constInfo = moodAnalyserFactory.GetConstructor(1);
                object createdObject = moodAnalyserFactory.CreateObjectUsingClass("wrong", constInfo, 1);
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
                MoodAnalyzerFactory<MoodAnalyzer> moodAnalyserFactory = new MoodAnalyzerFactory<MoodAnalyzer>();
                ConstructorInfo constInfo = null;
                object createdObject = moodAnalyserFactory.CreateObjectUsingClass("MoodAnalyzer", constInfo, 1);
            }
            catch (MoodAnalyzerException e)
            {
                Assert.AreEqual("Method not found", e.Message);
            }
        }

        [Test]
        public void GivenMoodAnalyser_WhenProper_ShouldReturnObject()
        {
            MoodAnalyzer expected = new MoodAnalyzer("I am in happy mood");
            MoodAnalyzerFactory<MoodAnalyzer> moodAnalyserFactory = new MoodAnalyzerFactory<MoodAnalyzer>();
            ConstructorInfo constructor = moodAnalyserFactory.GetConstructor(1);
            object createdObject = moodAnalyserFactory.CreateObjectUsingParameterizedConstructor("MoodAnalyzer", constructor, "I am in happy mood");
            Assert.AreEqual(expected, createdObject);
        }

        [Test]
        public void GivenClass_WhenImproper_ShouldThrowException()
        {
            try
            {
                MoodAnalyzer expected = new MoodAnalyzer("I am in happy mood");
                MoodAnalyzerFactory<MoodAnalyzer> moodAnalyserFactory = new MoodAnalyzerFactory<MoodAnalyzer>();
                ConstructorInfo constructor = moodAnalyserFactory.GetConstructor(1);
                object createdObject = moodAnalyserFactory.CreateObjectUsingParameterizedConstructor("Mood", constructor, "I am in happy mood");
            }
            catch (MoodAnalyzerException e)
            {
                Assert.AreEqual("Class not found", e.Message);
            }
        }

        [Test]
        public void GivenConstructor_WhenImproper_ShouldThrowException()
        {
            try
            {
                MoodAnalyzer expected = new MoodAnalyzer("I am in happy mood");
                MoodAnalyzerFactory<MoodAnalyzer> moodAnalyserFactory = new MoodAnalyzerFactory<MoodAnalyzer>();
                ConstructorInfo constructor = moodAnalyserFactory.GetConstructor(0);
                object createdObject = moodAnalyserFactory.CreateObjectUsingParameterizedConstructor("MoodAnalyzer", constructor, "I am in happy mood");
                Assert.AreEqual(expected, createdObject);
            }
            catch (MoodAnalyzerException e)
            {
                Assert.AreEqual("Method not found", e.Message);
            }
        }
    }
}