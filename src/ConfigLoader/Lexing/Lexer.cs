using System;
using System.IO;
using System.Collections.Generic;

namespace ConfigLoader.Lexing
{
    internal class Lexer
    {
        public Lexer()
        {
            //Add some testing stuff?
        }


        public List<ContextLine> LexConfigFile(string file)
        {
            if(!File.Exists(file))
            {
                Console.WriteLine("ConfigFile Not Found!");
                return null;
            }

            //Context Line List
            List<ContextLine> Lines = new List<ContextLine>();

            //StreamReader
            StreamReader Reader;


            try
            {
                //read file line by line
                using(Reader = new StreamReader(file))
                {
                    int lineCount = 0;
                    ContextTypes CurrentType;
                    string CurrentLine;
                    while((CurrentLine = Reader.ReadLine()) != null)
                    {
                        if((CurrentLine.Length < 1) || (Utils.Common.RemoveFromString(CurrentLine, new string[] { " " }).Length < 1))
                        {
                            //Empty Line
                            CurrentType = ContextTypes.EMPTY;
                        }
                        else if(CurrentLine.StartsWith("//"))
                        {
                            //Comment Line
                            CurrentType = ContextTypes.COMMENT;
                        }
                        else
                        {
                            //Everything that could be a valid Var Line
                            CurrentType = ContextTypes.VAR;
                        }
                        Lines.Add(new ContextLine(CurrentType, lineCount, CurrentLine));
                        lineCount++;
                    }
                }

                //Close and dispose the StreamReader
                Reader.Close();
                Reader.Dispose();
            }
            catch(Exception e)
            {
                Console.WriteLine(e.Message);
                return null;
            }

            //Return Lines List
            return Lines;
        }
    }
}
