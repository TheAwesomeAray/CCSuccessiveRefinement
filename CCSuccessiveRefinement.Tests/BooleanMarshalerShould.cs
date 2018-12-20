using Xunit;

namespace CCSuccessiveRefinement.Tests
{
    public class BooleanMarshalerShould
    {
        Args arg;

        public BooleanMarshalerShould()
        {
            string[] args = new string[5];
            arg = new Args("l,p#,d*", args);
        }

        [Fact]
        public void Test1()
        {

        }
    }
}
