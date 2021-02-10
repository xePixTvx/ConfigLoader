using System;
using System.Collections.Generic;
using ConfigLoader.Lexing;
using ConfigLoader.Parsing;
using ConfigLoader.Dvar;
using ConfigLoader.Error;


/*
 *      LAST WORKED ON:
 */


/*
 *      TODO:
 *              Config Saving
 */


namespace ConfigLoader
{
    public class ConfigLoader
    {
        private string filePath;
        private DvarHandler Handler;

        public static ErrorHandler Error;


        public ConfigLoader(string _filePath)
        {
            FilePath = _filePath;
        }


        public string FilePath
        {
            get { return filePath; }
            private set { filePath = value; }
        }




        public void LoadConfig()
        {
            Error = new ErrorHandler(true, true);

            List<ContextLine> LexedLines;
            List<Dvar.Dvar> ParsedLines;

            //Lex
            Lexer lex = new Lexer();
            LexedLines = lex.LexConfigFile(FilePath);
            if(Error.GetErrorTypeCount(ErrorTypes.Fatal) < 1)
            {
                //Parse
                Parser pars = new Parser();
                ParsedLines = pars.ParseContext(LexedLines);

                if(Error.GetErrorTypeCount(ErrorTypes.Fatal) < 1)
                {
                    Console.WriteLine("Parsed: " + ParsedLines.Count + " Lines");

                    //Dvar Handler
                    Handler = new DvarHandler(ParsedLines);
                }
            }

            Error.LogErrors();
        }

        public void SaveConfig()
        {
            Console.WriteLine("Save");
        }


        /*
        public void SetDvar()
        {
        }

        public void GetDvar()
        {
        }
        */
    }
}
