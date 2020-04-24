using System;

namespace TopCase.OlivaTaxi.Common.Models
{
    public class FormattedCost
    {
        private double _value;

        public FormattedCost()
        {
        }

        public FormattedCost(double value)
        {
            Value = value;
        }

        public double Value
        {
            get => _value;
            set => _value = Math.Round(value, 2, MidpointRounding.AwayFromZero);
        }

        public string Currency => "EUR";
    }
}