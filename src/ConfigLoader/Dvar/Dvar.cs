using System;
using System.Collections.Generic;
using System.Text;

namespace ConfigLoader.Dvar
{
    class Dvar
    {
        public DvarTypes Type;
        public int LinePos;
        public string Name;
        public string InfoText;

        private int IntValue;
        private int DefaultIntValue;
        private float FloatValue;
        private float DefaultFloatValue;
        private string StringValue;
        private string DefaultStringValue;
        private bool BoolValue;
        private bool DefaultBoolValue;


        public Dvar(DvarTypes type, int linePos, string name, int value, int defaultValue, string info)
        {
            Type = type;
            LinePos = linePos;
            Name = name;
            InfoText = info;

            IntValue = value;
            DefaultIntValue = defaultValue;
        }

        public Dvar(DvarTypes type, int linePos, string name, float value, float defaultValue, string info)
        {
            Type = type;
            LinePos = linePos;
            Name = name;
            InfoText = info;

            FloatValue = value;
            DefaultFloatValue = defaultValue;
        }

        public Dvar(DvarTypes type, int linePos, string name, string value, string defaultValue, string info)
        {
            Type = type;
            LinePos = linePos;
            Name = name;
            InfoText = info;

            StringValue = value;
            DefaultStringValue = defaultValue;
        }

        public Dvar(DvarTypes type, int linePos, string name, bool value, bool defaultValue, string info)
        {
            Type = type;
            LinePos = linePos;
            Name = name;
            InfoText = info;

            BoolValue = value;
            DefaultBoolValue = defaultValue;
        }


        public dynamic getValue()
        {
            switch(Type)
            {
                case DvarTypes.INT:
                    return IntValue;

                case DvarTypes.FLOAT:
                    return FloatValue;

                case DvarTypes.STRING:
                    return StringValue;

                case DvarTypes.BOOL:
                    return BoolValue;

                default:
                    return null;
            }
        }
        public dynamic getDefaultValue()
        {
            switch (Type)
            {
                case DvarTypes.INT:
                    return DefaultIntValue;

                case DvarTypes.FLOAT:
                    return DefaultFloatValue;

                case DvarTypes.STRING:
                    return DefaultStringValue;

                case DvarTypes.BOOL:
                    return DefaultBoolValue;

                default:
                    return null;
            }
        }

    }
}
