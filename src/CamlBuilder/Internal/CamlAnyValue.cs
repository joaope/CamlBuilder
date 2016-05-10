namespace CamlBuilder.Internal
{
    internal class CamlAnyValue : CamlValue
    {
        private readonly object anyValue;

        public CamlAnyValue(CamlValueType type, bool? includeTimeValue, object anyValue)
            : base(type, includeTimeValue)
        {
            this.anyValue = anyValue;
        }

        internal override string GetCamlValue()
        {
            return anyValue.ToString();
        }
    }
}