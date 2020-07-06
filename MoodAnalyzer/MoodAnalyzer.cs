//-----------------------------------------------------------------------
// <copyright file="MoodAnalyzer.cs" company="BridgeLabz">
// Copyright (c) 2020 All Rights Reserved
// </copyright>
//-----------------------------------------------------------------------
namespace MoodAnalyzer.BridgeLabz
{
using System;
#pragma warning disable CS0659 // Type overrides Object.Equals(object o) but does not override Object.GetHashCode()
    /// <summary>
    /// Analyze the mood
    /// </summary>
    public class MoodAnalyzer
    {
        /// <summary>
        /// Mood Message
        /// </summary>
        public string Message;

        /// <summary>
        /// Initializes a new instance of the <see cref="MoodAnalyzer"/> class
        /// </summary>
        public MoodAnalyzer()
        {
            this.Message = string.Empty;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="MoodAnalyzer"/> class
        /// </summary>
        /// <param name="message">Mood of person</param>
        public MoodAnalyzer(string message)
        {
            this.Message = message;
        }

        /// <summary>
        /// analyze the mood of the message
        /// </summary>
        /// <returns> analyzed mood</returns>
        public string AnalyzeMood()
        {
            return this.AnalyzeMood(this.Message);
        }

        /// <summary>
        /// To return the mood of the message
        /// </summary>
        /// <param name="message">Mood of person</param>
        /// <returns>analyzed mood</returns>
        public string AnalyzeMood(string message)
        {
            try
            { 
                if (message.Equals(string.Empty))
            {   
                ////throw exception if message is empty
                throw new MoodAnalyzerException("Message Cannot be Empty", MoodAnalyzerException.ExceptionType.EMPTY);
            }

                ////return message accoring to mood
            if (message.Contains("sad"))
                {
                    return "sad";
                }
                else
                {
                    return "happy";
                }
            }
            catch (NullReferenceException)
            {
                ////throw exception if message is null
                throw new MoodAnalyzerException("Message Cannot be Null", MoodAnalyzerException.ExceptionType.NULL);
            }
        }

        /// <summary>
        /// To check if two objects are equal
        /// </summary>
        /// <param name="that">Object for equality</param>
        /// <returns>true or false</returns>
        override
        public bool Equals(object that)
        {
            MoodAnalyzer moodAnalyser = (MoodAnalyzer)that;
            if (this.Message.Equals(moodAnalyser.Message))
            {
                return true;
            }

            return false;
        }
    }
}