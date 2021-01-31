using System;
using System.Collections.Generic;
using System.Text;

namespace ConfigLoader.Error
{
    class Error
    {
        public ErrorTypes Type;
        public string Message;

        internal Error(ErrorTypes type, string msg)
        {
            Type = type;
            Message = msg;
        }
    }
}
