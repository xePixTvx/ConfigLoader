using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;
using ConfigLoader.Lexing;

namespace ConfigLoader.Parsing
{
    internal class Parser
    {
        public Parser()
        {
            //Something here??
        }


        //Return a Dvar List or something
        public void ParseContext(List<ContextLine> contextLines)
        {
            List<Dvar.Dvar> DvarList = new List<Dvar.Dvar>();

            foreach(ContextLine Line in contextLines)
            {
                if((Line.Type == ContextTypes.EMPTY) || (Line.Type == ContextTypes.COMMENT))
                {
                    //Empty and Comment Lines
                    DvarList.Add(new Dvar.Dvar(Dvar.DvarTypes.IGNORE, Line.LinePos, "", Line.Context, "", ""));
                }
                else
                {
                    //Var Lines
                    try
                    {
                        //Line Context
                        string var_context = Line.Context;

                        //Var Name
                        string var_name = Utils.Common.RemoveFromString(var_context.Split('=')[0], new string[] { " " });


                        //Check if line context ends with ";"
                        if (!var_context.EndsWith(";"))
                        {
                            Console.WriteLine("BAD SYNTAX @ " + (Line.LinePos + 1) + ": \";\" missing!");
                        }

                        //Check if a var name can be found
                        if ((var_name == "") || (var_name == null))
                        {
                            Console.WriteLine("BAD SYNTAX @ " + (Line.LinePos + 1) + ": No Dvar Name Defined!");
                        }

                        //Check if Params part starts and ends with "{" and "}"
                        if((!Utils.Common.RemoveFromString(var_context.Split('=')[1], new string[] { " ", ";" }).StartsWith("{")) || (!Utils.Common.RemoveFromString(var_context.Split('=')[1], new string[] { " ", ";" }).EndsWith("}")))
                        {
                            Console.WriteLine("BAD SYNTAX @ " + (Line.LinePos + 1) + ": \"{\" or \"}\" missing!");
                        }

                        //Check if we are able to get 3 params
                        if(Utils.Common.RemoveFromString(var_context.Split('=')[1], new string[] { " ", ";", "\"" }).Split(',').Length != 3)
                        {
                            Console.WriteLine("BAD SYNTAX @ " + (Line.LinePos + 1) + ": Parameter or \",\" missing!");
                        }

                        //Param Context
                        string[] param_context = Utils.Common.RemoveFromString(var_context.Split('=')[1], new string[] { ";", "\"", "{", "}" }).Split(',');

                        //Value param
                        string param_value = Utils.Common.RemoveFromString(param_context[0], new string[] { " ", "," });//dont remove whitespaces cause of string types
                        
                        //Default Value param
                        string param_defaultValue = Utils.Common.RemoveFromString(param_context[1], new string[] { " ", "," });
                        
                        //Info Text param
                        string param_infoText = Utils.Common.RemoveFromString(param_context[2], new string[] { "," }).Trim(new char[] { ' ' });


                        //if value contains letters
                        if(Regex.Matches(param_value, @"[a-zA-Z]").Count >= 1)
                        {
                            if((param_value == "true") || (param_value == "false"))
                            {
                                if(param_value == "true")
                                {
                                    //true
                                    Console.WriteLine("Line " + (Line.LinePos + 1) + " bool -- true");
                                }
                                else
                                {
                                    //false
                                    Console.WriteLine("Line " + (Line.LinePos + 1) + " bool -- false");
                                }
                            }
                            else
                            {
                                //string
                                Console.WriteLine("Line " + (Line.LinePos + 1) + " string -- " + param_value);
                            }
                        }
                        else//if value doesnt contain letters
                        {
                            if(param_value.Contains('.'))
                            {
                                //float
                                Console.WriteLine("Line " + (Line.LinePos + 1) + " float -- " + param_value);
                            }
                            else
                            {
                                //int
                                Console.WriteLine("Line " + (Line.LinePos + 1) + " int -- " + param_value);
                            }
                        }

                        //add dvar as ignore type
                    }
                    catch
                    {
                        Console.WriteLine("FATAL PARSING ERROR!");
                    }
                }
            }
        }



    }
}
