//-----------------------------------------------------------------------
// <copyright file="MoodAnalyzerException.cs" company="BridgeLabz">
// Copyright (c) 2020 All Rights Reserved
// </copyright>
//-----------------------------------------------------------------------
namespace MoodAnalyzerExceptions
{
    using System;

    /// <summary>
    /// /To Throws Custom MoodAnalyzer Exception
    /// </summary>
    public class MoodAnalyzerException : Exception
    {
        /// <summary>
        /// Exception type
        /// </summary>
        public ExceptionType ExceptionTypes;

        /// <summary>
        /// Initializes a new instance of the <see cref="MoodAnalyzerException"/> class
        /// </summary>
        /// <param name="message"> Exception message </param>
        /// <param name="type"> type of exception</param>
        public MoodAnalyzerException(string message, ExceptionType type) 
        : base(message)
        {
            this.ExceptionTypes = type;
        }

        /// <summary>
        ///  Types of exception
        /// </summary>
        public enum ExceptionType
        {
            /// <summary>
            /// For null reference exception
            /// </summary>
            NULL,

            /// <summary>
            /// For null Empty field exception
            /// </summary>
            EMPTY,

            /// <summary>
            /// For null class not found exception
            /// </summary>
            CLASS_NOT_FOUND,

            /// <summary>
            /// For method not found exception
            /// </summary>
            METHOD_NOT_FOUND,

            /// <summary>
            /// For field not found exception
            /// </summary>
            FIELD_NOT_FOUND
        }
    }
}
