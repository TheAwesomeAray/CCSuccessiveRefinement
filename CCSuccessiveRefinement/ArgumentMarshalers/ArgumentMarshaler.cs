using System;
using System.Collections.Generic;
using System.Text;

namespace CCSuccessiveRefinement
{
    public interface ArgumentMarshaler
    {
        void Set(IEnumerator<string> currentArgument);
    }
}
