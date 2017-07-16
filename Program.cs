using DeveloperConsole.CallbackCommand;
using DeveloperConsole.CommandFramework;
using System;
using System.Collections;
using System.Collections.Generic;

namespace DeveloperConsole
{
    class Program
    {
        static void Main(string[] args)
        {
            CallbackCommandRegister._ins.ToString();
            CommandRegister._ins.Register(typeof(Program).Assembly);

            Console.WriteLine();
            
            while (true)
            {
                Console.Write(">");
                string line = Console.ReadLine();
                string[] command_and_arg = line.Split(' ');
                List<string> l = new List<string>(command_and_arg);
                string command = l[0];
                l.RemoveAt(0);
                Console.WriteLine(CommandsRepository._ins.ExecuteCommand(command, l.ToArray()));
            }

        }
    }
}
