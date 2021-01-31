using System;
using System.Collections.Generic;
using System.Text;

namespace ConfigLoader.Dvar
{
    class DvarHandler
    {
        //Full List(including Ignore Lines)
        private List<Dvar> DvarListFull;

        public DvarHandler(List<Dvar> ParsedLines)
        {
            DvarListFull = new List<Dvar>();
            foreach(Dvar var in ParsedLines)
            {
                DvarListFull.Add(var);
            }



            Console.WriteLine("Full List Size: " + DvarListFull.Count);
        }






    }
}
