using System;
using System.Collections.Generic;
using ConfigLoader.Lexing;
using ConfigLoader.Parsing;
using ConfigLoader.Dvar;
using ConfigLoader.Error;


/*
 *      LAST WORKED ON:
 *                          Removing dynamic stuff from Dvar class
 */


/*
 *      TODO:
 *              Update Dvar cause dynamic type doesnt work
 *              Config Saving
 */


namespace ConfigLoader
{
    public class ConfigLoader
    {
        private string filePath;
        private DvarHandler Handler;
        private Writing.Writer ConfigWriter;

        public static ErrorHandler Error;


        public ConfigLoader(string _filePath)
        {
            FilePath = _filePath;
            ConfigWriter = new Writing.Writer();
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
                    //Dvar Handler
                    Handler = new DvarHandler(ParsedLines);
                }
            }

            Error.LogErrors();
        }

        public void SaveConfig()
        {
            ConfigWriter.WriteConfig(FilePath, Handler.GetFullDvarListSortedByLinePos());
            Error.LogErrors();
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
