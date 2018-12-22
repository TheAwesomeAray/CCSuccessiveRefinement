using System;
using System.Collections.Generic;

namespace CCSuccessiveRefinement
{
    internal class DoubleArgumentMarshaler : ArgumentMarshaler
    {
        private double doubleValue = 0;

        internal static double GetValue(ArgumentMarshaler am)
        {
            if (am != null && am is DoubleArgumentMarshaler)
            {
                return ((DoubleArgumentMarshaler)am).doubleValue;
            }
            else
            {
                return 0;
            }
        }

        public void Set(IEnumerator<string> currentArgument)
        {
            string parameter = null;
            try
            {
                currentArgument.MoveNext();
                parameter = currentArgument.Current;
                doubleValue = double.Parse(parameter);
            }
            catch (InvalidOperationException e)
            {
                throw new ArgsException(ErrorCode.MISSING_INTEGER);
            }
            catch (FormatException e)
            {
                throw new ArgsException(ErrorCode.INVALID_INTEGER, parameter);
            }
        }
    }
}