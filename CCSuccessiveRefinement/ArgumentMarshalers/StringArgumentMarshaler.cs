using System;
using System.Collections.Generic;
using System.Text;

namespace CCSuccessiveRefinement
{
    class StringArgumentMarshaler : ArgumentMarshaler
    {
        private string stringValue = "";
        
        public void Set(IEnumerator<string> currentArgument)
        {
            try
            {
                //TODO: Figure out this dang iterator
                stringValue = currentArgument.Current;
            }
            catch (InvalidOperationException e)
            {
                throw new ArgsException(ErrorCode.MISSING_STRING);
            }
        }

        public static string GetValue(ArgumentMarshaler am)
        {
            if (am != null && am is StringArgumentMarshaler)
            {
                return ((StringArgumentMarshaler)am).stringValue;
            }
            else
            {
                return "";
            }
        }
    }
}
