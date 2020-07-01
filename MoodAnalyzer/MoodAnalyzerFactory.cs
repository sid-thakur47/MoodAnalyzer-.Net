using MoodAnalyzer_Main.exception;
using MoodAnalyzer_space;
using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;

namespace MoodAnalyzer_Main
{

    public class MoodAnalyzerFactory<E>
    {
        private Type type = typeof(E);
        public ConstructorInfo GetConstructor()
        {
            try
            {
                ConstructorInfo[] constructors = type.GetConstructors();
  
                return constructors[0];
            }
            catch (Exception)
            {

                throw new MoodAnalyzerException("Method not found", MoodAnalyzerException.ExceptionType.METHOD_NOT_FOUND_EXCEPTION);
            }
        }

        public object CreateObjectUsingClass(string className, ConstructorInfo constructor)
        {
                if (className != type.Name)
                    throw new MoodAnalyzerException("Class not found", MoodAnalyzerException.ExceptionType.CLASS_NOT_FOUND_EXCEPTION);
                if (constructor != GetConstructor())
                    throw new MoodAnalyzerException("Method not found", MoodAnalyzerException.ExceptionType.METHOD_NOT_FOUND_EXCEPTION);
                object createdObject = Activator.CreateInstance(className, type.FullName);
                return createdObject; 
        }
    }

}


