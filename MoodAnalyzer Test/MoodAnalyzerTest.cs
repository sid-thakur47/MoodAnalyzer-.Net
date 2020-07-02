//-----------------------------------------------------------------------
// <copyright file="MoodAnalyzerTest.cs" company="BridgeLabz">
// Copyright (c) 2012 All Rights Reserved
// </copyright>
//-----------------------------------------------------------------------
using System.Reflection;
using MoodAnalyzer_Main;
using MoodAnalyzerExceptions;
using MoodAnalyzers;
using NUnit.Framework;

namespace MoodAnalyzerTest
{
    /// <summary>
    /// Test for Mood Analyzer
    /// </summary>
    public class Tests   
    {   
        /// <summary>
        /// Constant for happy mood
        /// </summary>
        private const string HAPPY = "happy";

        /// <summary>
        /// Constant for sad mood
        /// </summary>
        private const string SAD = "sad";

        /// <summary>
        /// Mood Analyzer Object with default constructor
        /// </summary>
        private MoodAnalyzer moodAnalyzer = new MoodAnalyzer();

        /// <summary>
        /// Mood Analyzer Object for sad mood
        /// </summary>
        private MoodAnalyzer sadAnalyzer = new MoodAnalyzer("i am in sad mood");

        /// <summary>
        /// Mood Analyzer Object for happy mood
        /// </summary>
        private MoodAnalyzer happyAnalyzer = new MoodAnalyzer("i am in happy mood");

        /// <summary>
        /// Factory object 
        /// </summary>
        private MoodAnalyzerFactory<MoodAnalyzer> moodAnalyserFactory = new MoodAnalyzerFactory<MoodAnalyzer>();

        /// <summary>
        /// Test Case 1.1 : Given i'm in sad mood should return sad
        /// </summary>
      
        [Test]
        public void Given_Message_InMethod_ShouldReturnSad()
        {
            string mood = moodAnalyzer.AnalyzeMood("i am in sad mood");
            Assert.AreEqual("sad", mood);
        }

        /// <summary>
        /// Test Case 1.2: Given i'm in Happy mood should return happy
        /// </summary>
        [Test]
        public void GivenMessage_WhenContainsAnyMood_ShouldReturnHappy()
        {
            string mood = moodAnalyzer.AnalyzeMood("i am in any mood");
            Assert.AreEqual(HAPPY, mood);
        }

        /// <summary>
        /// Test Case  Repeat 1.1: Given Sad message in constructor should return sad
        /// </summary>
        [Test]
        public void Given_Message_InConstructor_IamInSadMood_ShouldReturnSad()
        {
            string mood = sadAnalyzer.AnalyzeMood();
            Assert.AreEqual(SAD, mood);
        }

        /// <summary>
        /// Test Case  Repeat 1.2: Given Happy message in constructor should return happy
        /// </summary>
        [Test]
        public void Given_Message_InConstructor_WhenContainsHappy_ShouldReturnHappy()
        {
            string mood = happyAnalyzer.AnalyzeMood();
            Assert.AreEqual(HAPPY, mood);
        }

        /// <summary>
        /// Test Case  Repeat 2.1: Given null message should throw exception
        /// </summary>
        [Test]
        public void Given_MessageInConstructor_WhenNull_ShouldThowMoodAnalysisException()
        {
            try
            {
                MoodAnalyzer moodAnalyzer = new MoodAnalyzer(null);
                string mood = moodAnalyzer.AnalyzeMood();
                Assert.AreEqual(HAPPY, mood);
            }
            catch (MoodAnalyzerException e)
            {
                Assert.AreEqual(MoodAnalyzerException.ExceptionType.NULL, e.ExceptionTypes);
            }
        }

        /// <summary>
        /// Test Case 3.2:Empty mood should throw exception
        /// </summary>
        [Test]
        public void Given_MessageInConstructor_WhenEmpty_ShouldThowMoodAnalysisException()
        {
            try
            {
                MoodAnalyzer moodAnalyzer = new MoodAnalyzer(string.Empty);
                string mood = moodAnalyzer.AnalyzeMood();
                Assert.AreEqual(HAPPY, mood);
            }
            catch (MoodAnalyzerException e)
            {
                Assert.AreEqual(MoodAnalyzerException.ExceptionType.EMPTY, e.ExceptionTypes);
            }
        }

        /// <summary>
        /// Test Case 4.2:If incorrect class name should throw exception
        /// </summary>
        [Test]
        public void Given_ClassName_WhenImproper_ShouldthrowException()
        {
            try
            {
                ConstructorInfo constInfo = this.moodAnalyserFactory.GetConstructor(1);
                object createdObject = this.moodAnalyserFactory.CreateObject("wrong", constInfo, "happy", 1);
                Assert.AreEqual(happyAnalyzer, createdObject);
            }
            catch (MoodAnalyzerException e)
            {
                Assert.AreEqual(MoodAnalyzerException.ExceptionType.CLASS_NOT_FOUND, e.ExceptionTypes);
            }
        }

        /// <summary>
        /// Test Case 4.3:If incorrect constructor name should throw exception
        /// </summary>
        [Test]
        public void Given_Constructor_WhenImproper_ShouldthrowException()
        {
            try
            {
                ConstructorInfo constInfo = null;
                object createdObject = this.moodAnalyserFactory.CreateObject("MoodAnalyzer", constInfo, "happy", 1);
                Assert.AreEqual(happyAnalyzer, createdObject);
            }
            catch (MoodAnalyzerException e)
            {
                Assert.AreEqual(MoodAnalyzerException.ExceptionType.METHOD_NOT_FOUND, e.ExceptionTypes);
            }
        }

        /// <summary>
        /// Test Case 5.1:If correct class name return object created using reflection
        /// </summary>
        [Test]
        public void Given_MoodAnalyser_WhenProper_ShouldReturnObject()
        {
            ConstructorInfo constructor = this.moodAnalyserFactory.GetConstructor(1);
            object createdObject = this.moodAnalyserFactory.CreateObject("MoodAnalyzer", constructor, "i am in happy mood", 1);
            Assert.AreEqual(happyAnalyzer, createdObject);
        }

        /// <summary>
        /// Test Case 5.2:If incorrect class name then throws exception
        /// </summary>
        [Test]
        public void Given_Class_WhenImproper_ShouldThrowException()
        {
            try
            {
                ConstructorInfo constructor = this.moodAnalyserFactory.GetConstructor(1);
                object createdObject = this.moodAnalyserFactory.CreateObject("Mood", constructor, "i am in happy mood", 1);
                Assert.AreEqual(happyAnalyzer, createdObject);
            }
            catch (MoodAnalyzerException e)
            {
                Assert.AreEqual(MoodAnalyzerException.ExceptionType.CLASS_NOT_FOUND, e.ExceptionTypes);
            }
        }

        /// <summary>
        /// Test Case 5.3:If incorrect constructor then throws exception
        /// </summary>
        [Test]
        public void Given_Constructor_WhenImproper_ShouldThrowException()
        {
            try
            {
                ConstructorInfo constructor = this.moodAnalyserFactory.GetConstructor(0);
                object createdObject = this.moodAnalyserFactory.CreateObject("MoodAnalyzer", constructor, "i am in happy mood", 1);
                Assert.AreEqual(happyAnalyzer, createdObject);
            }
            catch (MoodAnalyzerException e)
            {
                Assert.AreEqual(MoodAnalyzerException.ExceptionType.METHOD_NOT_FOUND, e.ExceptionTypes);
            }
        }

        /// <summary>
        /// Test Case 6.1: Given Happy message should return Happy
        /// </summary>
        [Test]
        public void GivenHappyMessageInReflection_WhenProper_Should_ReturnHappy()
        {
            string actual = this.moodAnalyserFactory.InvokeMoodAnalyser("AnalyzeMood", "im in happy mood");
            Assert.AreEqual(HAPPY, actual);
        }

        /// <summary>
        /// Test Case 6.2:Improper method name should throw exception
        /// </summary>
        [Test]
        public void GivenHappyMessageInReflection_WhenImProper_MethodName_Should_ReturnException()
        {
            try
            {
                string actual = this.moodAnalyserFactory.InvokeMoodAnalyser("wrongMethod", "im in happy mood");
                Assert.AreEqual(HAPPY, actual);
            }
            catch (MoodAnalyzerException e)
            {
                Assert.AreEqual(MoodAnalyzerException.ExceptionType.METHOD_NOT_FOUND, e.ExceptionTypes);
            }
        }
    }
}
