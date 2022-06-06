using System;
using System.Data.SqlTypes;

namespace Kursova.Model
{
    public struct Range : INullable
    {
        public double? MinValue, MaxValue;
        public bool MinIsIncluded, MaxIsIncluded;
        public bool IsNull { get; private set; }

        public Range(double? min, double? max, bool minIsIncluded = false, bool maxIsIncluded = false)
        {
            IsNull = min is not null && max is not null && min > max;
            MinValue = min;
            MaxValue = max;
            MinIsIncluded = minIsIncluded;
            MaxIsIncluded = maxIsIncluded;
        }

        public override string ToString()
        {
            return (MinIsIncluded ? "[" : "(") + (MinValue is null ? "-inf" : MinValue) + ";" +
                   (MaxValue is null ? "+inf" : MaxValue) + (MaxIsIncluded ? "]" : ")");
        }

        public static Range operator &(Range range1, Range range2)
        {
            if ((range1.MaxValue ?? Double.MaxValue) < (range2.MinValue ?? Double.MinValue)
                || (range2.MaxValue ?? Double.MaxValue) < (range1.MinValue ?? Double.MinValue))
            {
                range1.IsNull = true;
                return range1;
            }
            (double? newRangeMin, bool newRangeMinIsIncluded) = GetNewRangeMin(range1, range2);
            (double? newRangeMax, bool newRangeMaxIsIncluded) = GetNewRangeMax(range1, range2);
            if (newRangeMin!=newRangeMax || newRangeMaxIsIncluded&&newRangeMinIsIncluded)
                return new(newRangeMin, newRangeMax, newRangeMinIsIncluded, newRangeMaxIsIncluded);
            range1.IsNull = true;
            return range1;
        }

        private static (double?, bool) GetNewRangeMax(Range range1, Range range2)
        {
            if ((range1.MaxValue??Double.MaxValue) == (range2.MaxValue??Double.MaxValue))
                return (range1.MaxValue, range1.MaxIsIncluded && range2.MaxIsIncluded);
            if ((range1.MaxValue??Double.MaxValue) < (range2.MaxValue??Double.MaxValue))
                return (range1.MaxValue, range1.MaxIsIncluded);
            return (range2.MaxValue, range2.MaxIsIncluded);
        }
        
        private static (double?, bool) GetNewRangeMin(Range range1, Range range2)
        {
            if ((range1.MinValue??Double.MinValue) == (range2.MinValue??Double.MinValue))
                return (range1.MinValue, range1.MinIsIncluded && range2.MinIsIncluded);
            if ((range1.MinValue??Double.MinValue) > (range2.MinValue??Double.MinValue))
                return (range1.MinValue, range1.MinIsIncluded);
            return (range2.MinValue, range2.MinIsIncluded);
        }
    }
}