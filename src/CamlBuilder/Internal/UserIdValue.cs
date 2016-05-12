﻿namespace CamlBuilder.Internal
{
    internal class UserIdValue : Value
    {
        public UserIdValue(ValueType type, bool? includeTimeValue)
            : base(type, includeTimeValue)
        {
        }

        internal override string GetCamlValue()
        {
            return "<UserID/>";
        }
    }
}