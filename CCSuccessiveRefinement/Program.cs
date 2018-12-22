using System;

namespace CCSuccessiveRefinement
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                Args arg = new Args("l,p#,d*", new string[] { "-p", "2"});
                bool logging = arg.GetBoolean('l');
                int port = arg.GetInt('p');
                string directory = arg.GetString('d');
                //executeApplication(logging, port, directory);
            }
            catch (ArgumentException e)
            {
                Console.WriteLine("Argument Error: %s\n", e.Message);
            }
        }
    }
}
