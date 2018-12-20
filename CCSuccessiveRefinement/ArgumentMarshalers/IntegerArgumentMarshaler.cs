using System;
using System.Collections.Generic;

namespace CCSuccessiveRefinement
{
    public class IntegerArgumentMarshaler : ArgumentMarshaler
    {
        private int intValue = 0;

        public void Set(IEnumerator<string> currentArgument)
        {
            string parameter = null;
            try
            {
                currentArgument.MoveNext();
                parameter = currentArgument.Current;
                intValue = int.Parse(parameter);
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

        public static int GetValue(ArgumentMarshaler am)
        {
            if (am != null && am is IntegerArgumentMarshaler)
            {
                return ((IntegerArgumentMarshaler)am).intValue;
            }
            else
            {
                return 0;
            }
        }
    }
}

