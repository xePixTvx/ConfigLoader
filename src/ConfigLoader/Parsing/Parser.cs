using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;
using ConfigLoader.Lexing;

namespace ConfigLoader.Parsing
{
    internal class Parser
    {
        //Parse Lexed Context Lines
        public List<Dvar.Dvar> ParseContext(List<ContextLine> contextLines)
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
                            return null;
                        }

                        //Check if a var name can be found
                        if ((var_name == "") || (var_name == null))
                        {
                            Console.WriteLine("BAD SYNTAX @ " + (Line.LinePos + 1) + ": No Dvar Name Defined!");
                            return null;
                        }

                        //Check if Params part starts and ends with "{" and "}"
                        if((!Utils.Common.RemoveFromString(var_context.Split('=')[1], new string[] { " ", ";" }).StartsWith("{")) || (!Utils.Common.RemoveFromString(var_context.Split('=')[1], new string[] { " ", ";" }).EndsWith("}")))
                        {
                            Console.WriteLine("BAD SYNTAX @ " + (Line.LinePos + 1) + ": \"{\" or \"}\" missing!");
                            return null;
                        }

                        //Check if we are able to get 3 params
                        if(Utils.Common.RemoveFromString(var_context.Split('=')[1], new string[] { " ", ";", "\"" }).Split(',').Length != 3)
                        {
                            Console.WriteLine("BAD SYNTAX @ " + (Line.LinePos + 1) + ": Parameter or \",\" missing!");
                            return null;
                        }

                        //Param Context
                        string[] param_context = Utils.Common.RemoveFromString(var_context.Split('=')[1], new string[] { ";", "\"", "{", "}" }).Split(',');

                        //Value param
                        string param_value = Utils.Common.RemoveFromString(param_context[0], new string[] { " ", "," });
                        
                        //Default Value param
                        string param_defaultValue = Utils.Common.RemoveFromString(param_context[1], new string[] { " ", "," });
                        
                        //Info Text param
                        string param_infoText = Utils.Common.RemoveFromString(param_context[2], new string[] { "," }).Trim(new char[] { ' ' });

                        //Check Types
                        Dvar.DvarTypes VarType = CheckDvarType(param_value);
                        Dvar.DvarTypes DefaultValueVarType = CheckDvarType(param_defaultValue);
                        if(VarType != DefaultValueVarType)
                        {
                            Console.WriteLine("BAD SYNTAX @ " + (Line.LinePos + 1) + ": Value and DefaultValue are not the same type!");
                            return null;
                        }

                        //add dvar
                        DvarList.Add(new Dvar.Dvar(VarType, Line.LinePos, var_name, param_value, param_defaultValue, param_infoText));
                    }
                    catch
                    {
                        Console.WriteLine("FATAL PARSING ERROR!");
                        return null;
                    }
                }
            }
            return DvarList;
        }


        private Dvar.DvarTypes CheckDvarType(string input)
        {
            if (Regex.Matches(input, @"[a-zA-Z]").Count >= 1)
            {
                if ((input == "true") || (input == "false"))
                {
                    return Dvar.DvarTypes.BOOL;
                }
                else
                {
                    return Dvar.DvarTypes.STRING;
                }
            }
            else
            {
                if (input.Contains('.'))
                {
                    return Dvar.DvarTypes.FLOAT;
                }
                else
                {
                    return Dvar.DvarTypes.INT;
                }
            }
        }
    }
}
