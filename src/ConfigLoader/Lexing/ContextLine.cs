namespace ConfigLoader.Lexing
{
    class ContextLine
    {
        public ContextTypes Type;
        public int LinePos;
        public string Context;

        public ContextLine(ContextTypes type, int linePos, string context)
        {
            Type = type;
            LinePos = linePos;
            Context = context;
        }
    }
}
