using System.Collections.Generic;

namespace CCSuccessiveRefinement
{
    public class BooleanArgumentMarshaler : ArgumentMarshaler
    {
        private bool booleanValue = false;

        public void Set(IEnumerator<string> currentArgument)
        {
            booleanValue = true;
        }

        public static bool GetValue(ArgumentMarshaler am)
        {
            if (am != null && am is BooleanArgumentMarshaler)
            {
                return ((BooleanArgumentMarshaler)am).booleanValue;
            }
            else
            {
                return false;
            }
        }
    }
}
