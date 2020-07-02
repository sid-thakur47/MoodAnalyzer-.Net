//-----------------------------------------------------------------------
// <copyright file="MoodAnalyzerFactory.cs" company="BridgeLabz">
// Copyright (c) 2012 All Rights Reserved
// </copyright>
//-----------------------------------------------------------------------

using System;
using System.Reflection;
using MoodAnalyzerExceptions;

namespace MoodAnalyzer_Main
{
    /// <summary>
    /// Creating Object of specific Type
    /// </summary>
    /// <typeparam name="E">The element type of the class</typeparam>
    public class MoodAnalyzerFactory<E>
    {
        /// <summary>
        /// Type Deceleration
        /// </summary>
        private Type type = typeof(E);

        /// <summary>
        ///  method to get constructor information  required constructor
        /// </summary>
        /// <param name="parameters">constructor parameters</param>
        /// <returns>Constructor info</returns>
        public ConstructorInfo GetConstructor(int parameters)
        {
            try
            {
                ConstructorInfo[] constructors = this.type.GetConstructors();
                foreach (ConstructorInfo constructor in constructors)
                {
                    if (constructor.GetParameters().Length == parameters) 
                    { 
                        return constructor;
                    }
                }

                return constructors[0];
            }
            catch (Exception)
            {
              throw new MoodAnalyzerException("Method not found", MoodAnalyzerException.ExceptionType.METHOD_NOT_FOUND);
            }
        }

        /// <summary>
        /// to create object of  specified class of with default constructor
        /// </summary>
        /// <param name="className">Name of class</param>
        /// <param name="constructor">Constructor information</param>
        /// <param name="mood">Mood to be analyzed</param>
        /// <param name="parameters">parameters of constructor</param>
        /// <returns>Object of class using reflection</returns>
        public object CreateObject(string className, ConstructorInfo constructor, string mood, int parameters)
        {
            if (className != this.type.Name)
            {
                throw new MoodAnalyzerException("Class not found", MoodAnalyzerException.ExceptionType.CLASS_NOT_FOUND);
            }

            if (constructor != this.GetConstructor(parameters))
            {
                throw new MoodAnalyzerException("Method not found", MoodAnalyzerException.ExceptionType.METHOD_NOT_FOUND);
            }

            object returnObject = Activator.CreateInstance(this.type, mood);
            return returnObject;
        }

        /// <summary>
        /// invoke mood analyzer methods
        /// </summary>
        /// <param name="methodName">method to be invoked</param>
        /// <param name="mood">mood to be analyzed</param>
        /// <returns>mood analyzed by invoked method</returns>
        public string InvokeMoodAnalyser(string methodName, string mood)
        {
            try
            {
                MethodInfo info = this.type.GetMethod(methodName, new Type[] { typeof(string) });
                object instance = Activator.CreateInstance(this.type, mood);
                return (string)info.Invoke(instance, new string[] { mood });
            }
            catch (NullReferenceException)
            {
                throw new MoodAnalyzerException("Method not found", MoodAnalyzerException.ExceptionType.METHOD_NOT_FOUND);
            }
        } 
    }
}