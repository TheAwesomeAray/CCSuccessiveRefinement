using System;

namespace CCSuccessiveRefinement
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                args = new string[3];
                args[0] = "-l";
                args[1] = "-p";
                args[2] = "-d";
                Args arg = new Args("l,p#,d*", args);
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
