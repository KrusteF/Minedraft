namespace Minedraft
{
    using System;
    using System.Collections.Generic;

    public class StartUp
    {
        public static void Main()
        {
            DraftManager manager = new DraftManager();

            while (true)
            {
                string input = Console.ReadLine();
                string[] str = input.Split(" ");
                string command = str[0];

                List<string> args = new List<string>(str);
                args.RemoveAt(0);
                object[] prms = new[] { args };

                if (args.Count == 0)
                {
                    prms = new object[0];
                }

                string output = (string)manager.GetType().GetMethod(command).Invoke(manager, prms);
                Console.WriteLine(output);
                
                if (command.Equals("Shutdown"))
                {
                    break;
                }
                
            }
        }
    }
}
