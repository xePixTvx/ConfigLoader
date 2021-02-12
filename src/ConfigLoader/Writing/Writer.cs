using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace ConfigLoader.Writing
{
    internal class Writer
    {
        private StreamWriter FileWriter;

        public void WriteConfig(string file, List<Dvar.Dvar> DvarList)
        {
            try
            {
                //FileWriter = new StreamWriter(file, false);
                foreach(Dvar.Dvar Var in DvarList)
                {
                    if(Var.Type == Dvar.DvarTypes.IGNORE)
                    {
                        //FileWriter.WriteLine(Var.getValueString());
                        //FileWriter.Flush();
                        Console.WriteLine(Var.Value);
                    }
                    else
                    {
                        //name = { value, defaultvalue, infotext };
                        string VarName = Var.Name;
                        string VarInfoText = Var.InfoText;

                        string VarSaveString = "";
                        if(Var.Type == Dvar.DvarTypes.INT)
                        {
                            //VarSaveString = VarName + " = {" + Var.getValueInt() + ", " + Var.getDefaultValueInt() + ", \"" + VarInfoText + "\"};";
                        }
                        if (Var.Type == Dvar.DvarTypes.FLOAT)
                        {
                            //VarSaveString = VarName + " = {" + Var.getValueFloat() + ", " + Var.getDefaultValueFloat() + ", \"" + VarInfoText + "\"};";
                        }
                        if (Var.Type == Dvar.DvarTypes.STRING)
                        {
                            //VarSaveString = VarName + " = {\"" + Var.getValueString() + "\", \"" + Var.getDefaultValueString() + "\", \"" + VarInfoText + "\"};";
                        }
                        if (Var.Type == Dvar.DvarTypes.BOOL)
                        {
                            //string boolValue = (Var.getValueBool() == true ? "true" : "false");
                            //string boolDefaultValue = (Var.getDefaultValueBool() == true ? "true" : "false");
                            //VarSaveString = VarName + " = {" + boolValue + ", " + boolDefaultValue + ", \"" + VarInfoText + "\"};";
                        }
                        else
                        {
                            //VarSaveString = VarName + " = {" + VarValue + ", " + VarDefaultValue + ", \"" + VarInfoText + "\"};";
                        }
                        Console.WriteLine(VarName + " = {" + Var.Value + ", " + Var.DefaultValue + ", \"" + VarInfoText + "\"};");
                        //FileWriter.WriteLine(VarSaveString);
                        //FileWriter.Flush();
                    }
                }
                //FileWriter.Close();
                //FileWriter.Dispose();
            }
            catch(Exception e)
            {
                ConfigLoader.Error.Add(Error.ErrorTypes.Fatal, "Saving Config Failed: " + e.Message);
            }
        }
    }
}
