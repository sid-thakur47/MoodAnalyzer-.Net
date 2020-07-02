using System.Reflection;
using MoodAnalyzerExceptions;
using MoodAnalyzers;
using NUnit.Framework;
using MoodAnalyzer_Main;
using System.Reflection.Metadata;

namespace MoodAnalyzerTest
{
    public class Tests 
       
    {
        private static string HAPPY = "happy";
        private static string SAD = "sad";
        MoodAnalyzer moodAnalyzer = new MoodAnalyzer();
        MoodAnalyzer sadAnalyzer = new MoodAnalyzer("i am in sad mood");
        MoodAnalyzer happyAnalyzer = new MoodAnalyzer("i am in happy mood");
        MoodAnalyzerFactory<MoodAnalyzer> moodAnalyserFactory = new MoodAnalyzerFactory<MoodAnalyzer>();

        ////UC1-TC-1
        [Test]
        public void Given_Message_InMethod_ShouldReturnSad()
        {
            string mood = moodAnalyzer.AnalyzeMood("i am in sad mood");
            Assert.AreEqual("sad", mood);
        }

        ////UC1-TC-2
        [Test]
        public void GivenMessage_WhenContainsAnyMood_ShouldReturnHappy()
        {
            string mood = moodAnalyzer.AnalyzeMood("i am in any mood");
            Assert.AreEqual(HAPPY, mood);
        }

        ////UC1-TC-1.1
        [Test]
        public void Given_Message_InConstructor_IamInSadMood_ShouldReturnSad()
        {
            string mood = sadAnalyzer.AnalyzeMood();
            Assert.AreEqual(SAD, mood);
        }
        ////UC1-TC-1.2
        [Test]
        public void Given_Message_InConstructor_WhenContainsHappy_ShouldReturnHappy()
        {
            string mood = happyAnalyzer.AnalyzeMood();
            Assert.AreEqual(HAPPY, mood);
        }

       ////UC2-TC-1
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
                Assert.AreEqual(MoodAnalyzerException.ExceptionType.NULL, e.ExceptionTypes);
            }
        }

        [Test]
        public void Given_MessageInConstructor_WhenEmpty_ShouldThowMoodAnalysisException()
        {
            try
            {
                MoodAnalyzer moodAnalyzer = new MoodAnalyzer(string.Empty);
                string mood = moodAnalyzer.AnalyzeMood();
            }
            catch (MoodAnalyzerException e)
            {
                Assert.AreEqual(MoodAnalyzerException.ExceptionType.EMPTY, e.ExceptionTypes);
            }
        }

        [Test]
        public void Given_ClassName_WhenImproper_ShouldthrowException()
        {
            try
            {
                ConstructorInfo constInfo = moodAnalyserFactory.GetConstructor(1);
                object createdObject = moodAnalyserFactory.CreateObjectUsingClass("wrong", constInfo, 1);
            }
            catch (MoodAnalyzerException e)
            {
                Assert.AreEqual(MoodAnalyzerException.ExceptionType.CLASS_NOT_FOUND, e.ExceptionTypes);
            }
        }

        [Test]
        public void Given_Constructor_WhenImproper_ShouldthrowException()
        {
            try
            {
                ConstructorInfo constInfo = null;
                object createdObject = moodAnalyserFactory.CreateObjectUsingClass("MoodAnalyzer", constInfo, 1);
            }
            catch (MoodAnalyzerException e)
            {
                Assert.AreEqual(MoodAnalyzerException.ExceptionType.METHOD_NOT_FOUND, e.ExceptionTypes);
            }
        }

        [Test]
        public void Given_MoodAnalyser_WhenProper_ShouldReturnObject()
        {
            ConstructorInfo constructor = moodAnalyserFactory.GetConstructor(1);
            object createdObject = moodAnalyserFactory.CreateObjectUsingParameterizedConstructor("MoodAnalyzer", constructor, "i am in happy mood");
            Assert.AreEqual(happyAnalyzer, createdObject);
        }

        [Test]
        public void Given_Class_WhenImproper_ShouldThrowException()
        {
            try
            {
                ConstructorInfo constructor = moodAnalyserFactory.GetConstructor(1);
                object createdObject = moodAnalyserFactory.CreateObjectUsingParameterizedConstructor("Mood", constructor, "i am in happy mood");
            }
            catch (MoodAnalyzerException e)
            {
                Assert.AreEqual(MoodAnalyzerException.ExceptionType.CLASS_NOT_FOUND, e.ExceptionTypes);
            }
        }

        [Test]
        public void Given_Constructor_WhenImproper_ShouldThrowException()
        {
            try
            {
                ConstructorInfo constructor = moodAnalyserFactory.GetConstructor(0);
                object createdObject = moodAnalyserFactory.CreateObjectUsingParameterizedConstructor("MoodAnalyzer", constructor, "i am in happy mood");
                Assert.AreEqual(happyAnalyzer, createdObject);
            }
            catch (MoodAnalyzerException e)
            {
                Assert.AreEqual(MoodAnalyzerException.ExceptionType.METHOD_NOT_FOUND, e.ExceptionTypes);
            }
        }

        [Test]
        public void GivenHappyMessageInReflection_WhenProper_Should_ReturnHappy()
        {
            string actual = moodAnalyserFactory.InvokeMoodAnalyser("AnalyzeMood", "im in happy mood");
            Assert.AreEqual(HAPPY, actual);
        }

        [Test]
        public void GivenHappyMessageInReflection_WhenImProper_MethodName_Should_ReturnException()
        {
            try
            {
                string actual = moodAnalyserFactory.InvokeMoodAnalyser("wrongMethod", "im in happy mood");
            }
            catch (MoodAnalyzerException e)
            {
                Assert.AreEqual(MoodAnalyzerException.ExceptionType.METHOD_NOT_FOUND, e.ExceptionTypes);
            }
        }
    }
}
