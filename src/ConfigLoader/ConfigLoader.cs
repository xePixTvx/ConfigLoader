using System;
using System.Collections.Generic;
using ConfigLoader.Lexing;
using ConfigLoader.Parsing;
using ConfigLoader.Dvar;
using ConfigLoader.Error;


/*
 *      LAST WORKED ON:
 *                          ERROR Handling
 */


/*
 *      TODO:
 *              ERROR Handling
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
            Error = new ErrorHandler(true);

            List<ContextLine> LexedLines;
            List<Dvar.Dvar> ParsedLines;

            //Lex
            Lexer lex = new Lexer();
            LexedLines = lex.LexConfigFile(FilePath);
            if(LexedLines != null)
            {
                //Parse
                Parser pars = new Parser();
                ParsedLines = pars.ParseContext(LexedLines);

                if (ParsedLines != null)
                {
                    Console.WriteLine("Parsed: " + ParsedLines.Count + " Lines");

                    //Dvar Handler
                    Handler = new DvarHandler(ParsedLines);
                }
            }


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
