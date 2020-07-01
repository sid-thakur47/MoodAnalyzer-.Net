using NUnit.Framework;
using MoodAnalyzers;
using MoodAnalyzer_Main.exception;
using MoodAnalyzer_Main;
using System.Reflection;

namespace MoodAnalyzer_Test
{
    public class Tests
    {
        
        [Test]
        public void Given_Message_InMethod_ShouldReturnSad()
        {
            MoodAnalyzer moodAnalyzer = new MoodAnalyzer();
            string mood = moodAnalyzer.AnalyzeMood("i am in sad mood");
            Assert.AreEqual("sad", mood);
        }

        [Test]
        public void GivenMessage_WhenContainsAnyMood_ShouldReturnHappy()
        {
            MoodAnalyzer moodAnalyzer = new MoodAnalyzer();
            string mood = moodAnalyzer.AnalyzeMood("i am in any mood");
            Assert.AreEqual("happy", mood);
        }

        [Test]
        public void Given_Message_InConstructor_IamInSadMood_ShouldReturnSad()
        {
            MoodAnalyzer moodAnalyzer = new MoodAnalyzer("i am in sad mood");
            string mood = moodAnalyzer.AnalyzeMood();
            Assert.AreEqual("sad", mood);
        }

        [Test]
        public void Given_Message_InConstructor_WhenContainsHappy_ShouldReturnHappy()
        {
            MoodAnalyzer moodAnalyzer = new MoodAnalyzer("i am in happy mood");
            string mood = moodAnalyzer.AnalyzeMood();
            Assert.AreEqual("happy", mood);
        }

        [Test]
        public void Given_MessageInConstructor_WhenNull_ShouldThowMoodAnalysisException()
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
        public void Given_MessageInConstructor_WhenEmpty_ShouldThowMoodAnalysisException()
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
        public void Given_ClassName_WhenImproper_ShouldthrowException()
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
        public void Given_Constructor_WhenImproper_ShouldthrowException()
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
        public void Given_MoodAnalyser_WhenProper_ShouldReturnObject()
        {
            MoodAnalyzer moodAnalyzerObject = new MoodAnalyzer("I am in happy mood");
            MoodAnalyzerFactory<MoodAnalyzer> moodAnalyserFactory = new MoodAnalyzerFactory<MoodAnalyzer>();
            ConstructorInfo constructor = moodAnalyserFactory.GetConstructor(1);
            object createdObject = moodAnalyserFactory.CreateObjectUsingParameterizedConstructor("MoodAnalyzer", constructor, "I am in happy mood");
            Assert.AreEqual(moodAnalyzerObject, createdObject);
        }

        [Test]
        public void Given_Class_WhenImproper_ShouldThrowException()
        {
            try
            {
                MoodAnalyzer moodAnalyzerObject = new MoodAnalyzer("I am in happy mood");
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
        public void Given_Constructor_WhenImproper_ShouldThrowException()
        {
            try
            {
                MoodAnalyzer moodAnalyzerObject = new MoodAnalyzer("I am in happy mood");
                MoodAnalyzerFactory<MoodAnalyzer> moodAnalyserFactory = new MoodAnalyzerFactory<MoodAnalyzer>();
                ConstructorInfo constructor = moodAnalyserFactory.GetConstructor(0);
                object createdObject = moodAnalyserFactory.CreateObjectUsingParameterizedConstructor("MoodAnalyzer", constructor, "I am in happy mood");
                Assert.AreEqual(moodAnalyzerObject, createdObject);
            }
            catch (MoodAnalyzerException e)
            {
                Assert.AreEqual("Method not found", e.Message);
        
            }
        }
    }
}