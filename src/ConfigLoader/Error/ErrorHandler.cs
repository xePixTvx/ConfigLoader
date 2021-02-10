using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace ConfigLoader.Error
{
    public class ErrorHandler
    {
        public bool PrintToConsole = false;
        public bool LogToFile = false;

        private List<Error> ErrorList;
        private StreamWriter FileWriter;

        internal ErrorHandler(bool printToConsole, bool logToFile)
        {
            PrintToConsole = printToConsole;
            LogToFile = logToFile;
            ErrorList = new List<Error>();
        }

        internal void Add(ErrorTypes ErrorType, string ErrorMSG)
        {
            ErrorList.Add(new Error(ErrorType, ErrorMSG));
        }

        internal void LogErrors()
        {
            string LogDirectory = Path.Combine(Environment.CurrentDirectory, "ConfigLoaderLogs");
            string LogFile = Path.Combine(LogDirectory, "Log.txt");

            if (LogToFile)
            {
                if(!Directory.Exists(LogDirectory))
                {
                    Directory.CreateDirectory(LogDirectory);
                }

                FileWriter = new StreamWriter(LogFile, false);
            }

            List<Error> ErrList = ErrorList.OrderBy(e => e.Type).ToList();

            int ErrorCount_Warning = GetErrorTypeCount(ErrorTypes.Warning);
            int ErrorCount_Fatal = GetErrorTypeCount(ErrorTypes.Fatal);

            printError(" ----- ConfigLoader ----- ", ConsoleColor.Green);
            printError("Warnings: " + ErrorCount_Warning, ConsoleColor.Yellow);
            printError("Fatal Errors: " + ErrorCount_Fatal, ConsoleColor.Red);
            if((ErrorCount_Warning > 0) || (ErrorCount_Fatal > 0))
            {
                printError("", ConsoleColor.White);
            }

            foreach (Error err in ErrList)
            {
                printError(err.Message, ((err.Type == ErrorTypes.Warning) ? ConsoleColor.Yellow : ConsoleColor.Red));
            }

            printError(" ------------------------ ", ConsoleColor.Green);

            if(LogToFile)
            {
                FileWriter.Close();
                FileWriter.Dispose();
            }
        }

        public int GetErrorTypeCount(ErrorTypes Type)
        {
            return GetErrorListByType(Type).Count;
        }

        private List<Error> GetErrorListByType(ErrorTypes Type)
        {
            List<Error> errList = new List<Error>();
            foreach(Error e in ErrorList)
            {
                if(e.Type == Type)
                {
                    errList.Add(e);
                }
            }
            return errList;
        }

        private void printError(string msg, ConsoleColor Color)
        {
            if(PrintToConsole)
            {
                Console.ForegroundColor = Color;
                Console.WriteLine(msg);
                Console.ResetColor();
            }
            if(LogToFile)
            {
                FileWriter.WriteLine(msg);
                FileWriter.Flush();
            }
        }
    }
}
