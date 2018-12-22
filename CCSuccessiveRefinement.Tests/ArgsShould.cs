using Xunit;

namespace CCSuccessiveRefinement.Tests
{
    public class ArgsShould
    {
        [Fact]
        public void Return_bool_argument_marshaler()
        {
            Args arg;
            string[] args = new string[1];
            args[0] = "-l";
            arg = new Args("l", args);

            Assert.True(arg.GetBoolean('l'));
        }
    }
}
