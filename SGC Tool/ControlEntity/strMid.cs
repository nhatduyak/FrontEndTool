using System;
using System.Runtime.InteropServices;
using System.ComponentModel;
using System.Globalization;
using Microsoft.VisualBasic;
//using Microsoft.VisualBasic.CompilerServices;

namespace TOOLChuyenDuLieu.ControlEntity
{    
    public static class strMid
    {
        public static string Mid(string s, int a, int b)
        {
            string temp = s.Substring(a - 1, b);
            return temp;
        }

        public static string Left(string param, int length)
        {
            //we start at 0 since we want to get the characters starting from the
            //left and with the specified lenght and assign it to a variable
            string result = param.Substring(0, length);
            //return the result of the operation
            return result;
        }

        public static string Right(string param, int length)
        {
            //start at the index based on the lenght of the sting minus
            //the specified lenght and assign it a variable
            string result = param.Substring(param.Length - length,length);
            //return the result of the operation
            return result;
        }

        public static int InStr (String String1, String String2, [Optional][DefaultValue (CompareMethod.Binary)]CompareMethod Compare)
        {
            return InStr(1, String1, String2, Compare);
        }

        public static int InStr(String String1, String String2)
        {

            return InStr(1, String1, String2, CompareMethod.Binary);
        }


        public static int InStr(int Start, String String1, String String2,[Optional][DefaultValue(CompareMethod.Binary)]CompareMethod Compare)
        {
            if(String1 == null || String1.Length == 0)
            {
                return 0;
            }
            if(String2 == null || String2.Length == 0)
            {
                return Start;
            }
            if(Start >= String1.Length)
            {
                return 0;
            }
            if(Compare == CompareMethod.Binary)
            {
                return (CultureInfo.CurrentCulture.CompareInfo.IndexOf(String1, String2, Start - 1,CompareOptions.Ordinal) + 1);
            }
            else
            {
                return (CultureInfo.CurrentCulture.CompareInfo.IndexOf(String1, String2, Start - 1,CompareOptions.IgnoreWidth |CompareOptions.IgnoreKanaType | CompareOptions.IgnoreCase) + 1);
            }
        }
    }
}
