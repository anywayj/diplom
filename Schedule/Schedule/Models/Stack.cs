using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;

namespace Schedule.Models
{
    public class Stack
    {
        private static String FileName = Directory.GetCurrentDirectory() + "\\App_Data\\Stack.txt";

        public static void AddData(String data)
        {
            /*using (StreamWriter outputFile = new StreamWriter(FileName))
            {
                outputFile.WriteLine(data);
            }*/
        }
    }
}