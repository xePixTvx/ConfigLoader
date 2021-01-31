﻿using System;
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
            List<Dvar.Dvar> ParsedLines;

            //Lex
            Lexer lex = new Lexer();
            LexedLines = lex.LexConfigFile(FilePath);
            if(LexedLines == null)
            {
                Console.WriteLine("Lexing Failed!");
            }


            //Parse
            Parser pars = new Parser();
            ParsedLines = pars.ParseContext(LexedLines);
            if(ParsedLines == null)
            {
                Console.WriteLine("Parsing Failed!");
            }
            else
            {
                Console.WriteLine("Parsed: " + ParsedLines.Count + " Lines");
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
