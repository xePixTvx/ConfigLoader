using System;
using System.Collections.Generic;
using ConfigLoader.Lexing;
using ConfigLoader.Parsing;


namespace ConfigLoader
{
    public class ConfigLoader
    {
        private string filePath;


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
            List<ContextLine> LexedLines;

            //Lex
            Lexer lex = new Lexer();
            LexedLines = lex.LexConfigFile(FilePath);
            if(LexedLines == null)
            {
                Console.WriteLine("Lexing Error Fuck!!!");
            }


            //Parse
            Parser pars = new Parser();
            pars.ParseContext(LexedLines);




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
