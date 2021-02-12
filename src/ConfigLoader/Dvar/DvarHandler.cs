using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ConfigLoader.Dvar
{
    class DvarHandler
    {
        //Full List(including Ignore Lines)
        private List<Dvar> DvarListFull;

        public DvarHandler(List<Dvar> ParsedLines)
        {
            /*foreach(Dvar v in ParsedLines)
            {
                Console.WriteLine(v.getValue() + " ---- " + v.getDefaultValue());
            }*/


            DvarListFull = ParsedLines;
        }


        public List<Dvar> GetFullDvarList()
        {
            return DvarListFull;
        }

        public List<Dvar> GetFullDvarListSortedByLinePos()
        {
            return DvarListFull.OrderBy(e => e.LinePos).ToList();
        }






    }
}
