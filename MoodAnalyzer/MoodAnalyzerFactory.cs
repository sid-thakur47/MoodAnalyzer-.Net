using MoodAnalyzer_Main.exception;
using MoodAnalyzer_space;
using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;

namespace MoodAnalyzer_Main
{
    public class MoodAnalyzerFactory
    {
        /*  public static MoodAnalyzer CreateMoodAnalyzer()
          {
              Type type = typeof(MoodAnalyzer);
              ConstructorInfo[] constructorInfo = type.GetConstructors();
              object myObj = Activator.CreateInstance(type);
              return (MoodAnalyzer)myObj;
          }

  */
        //To create Object of MoodAnalyzer default constructor
        public static MoodAnalyzer CreateMoodAnalyzer(String className,String constParameter)

        {
            Type type = Type.GetType(className);
            if (className.Equals("MoodAnalyzer_space.MoodAnalyzer"))
            {
                object myObj = Activator.CreateInstance(type);
                ConstructorInfo constructorInfo = type.GetConstructor(new Type[] { typeof(string) });
                return (MoodAnalyzer)myObj;
            }
            else if (constParameter != "String")
                throw new MoodAnalyzerException("Method not found", MoodAnalyzerException.ExceptionType.METHOD_NOT_FOUND_EXCEPTION);
            else
                throw new MoodAnalyzerException("Class not found", MoodAnalyzerException.ExceptionType.CLASS_NOT_FOUND_EXCEPTION);
        }
         
    }
}