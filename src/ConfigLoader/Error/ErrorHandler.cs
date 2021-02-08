using System;
using System.Collections.Generic;
using System.Text;

namespace ConfigLoader.Error
{
    public class ErrorHandler
    {
        public bool PrintToConsole = false;

        private List<Error> ErrorList;

        internal ErrorHandler(bool printToConsole)//bool logToFile
        {
            PrintToConsole = printToConsole;
            ErrorList = new List<Error>();
        }

        internal void Add(ErrorTypes ErrorType, string ErrorMSG)
        {
            ErrorList.Add(new Error(ErrorType, ErrorMSG));
            if(PrintToConsole && (ErrorType == ErrorTypes.Fatal))
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine(ErrorMSG);
                Console.ResetColor();
            }
        }

        internal int GetErrorTypeCount(ErrorTypes Type)
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
    }
}
