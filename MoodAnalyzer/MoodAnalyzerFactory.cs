using MoodAnalyzerExceptions;
using System;
using System.Reflection;

namespace MoodAnalyzer_Main
{

    public class MoodAnalyzerFactory<E>
    {
        private Type type = typeof(E);

        //// method to get constructor information  required constructor
        public ConstructorInfo GetConstructor(int parameters)
        {
            try
            {
                ConstructorInfo[] constructors = type.GetConstructors();
                foreach (ConstructorInfo constructor in constructors)
                {
                    if (constructor.GetParameters().Length == parameters)
                        return constructor;
                }
                return constructors[0];
            }
            catch (Exception)
            {
                throw new MoodAnalyzerException("Method not found", MoodAnalyzerException.ExceptionType.METHOD_NOT_FOUND);
            }
        }

        ////to create object of  specified class of with default constructor
        public object CreateObjectUsingClass(string className, ConstructorInfo constructor, int parameters)
        {
            if (className != type.Name)
            {
                throw new MoodAnalyzerException("Class not found", MoodAnalyzerException.ExceptionType.CLASS_NOT_FOUND);
            }
            if (constructor != this.GetConstructor(parameters))
            {
                throw new MoodAnalyzerException("Method not found", MoodAnalyzerException.ExceptionType.METHOD_NOT_FOUND);
            }
            object returnObject = Activator.CreateInstance(Type.GetType("className"));
            return returnObject;
        }

        ////create object of specified class with parameterized constructor
        public object CreateObjectUsingParameterizedConstructor(string className, ConstructorInfo constructor, string mood)
        {
            if (className != type.Name)
            {
                throw new MoodAnalyzerException("Class not found", MoodAnalyzerException.ExceptionType.CLASS_NOT_FOUND);
            }
            if (constructor != type.GetConstructors()[1])
            {
                throw new MoodAnalyzerException("Method not found", MoodAnalyzerException.ExceptionType.METHOD_NOT_FOUND);
            }
            object returnObject = Activator.CreateInstance(type, mood);
            return returnObject;
        }
    }
}

    



