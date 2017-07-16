using DeveloperConsole.CommandFramework;
using System;

namespace DeveloperConsole
{
    [Command("loop", "测试命令：hi", CommandType.Client)]
    class TestCommand2 : CommandBase
    {
        public override void Execute(string[] arguments)
        {
            Console.ForegroundColor = ConsoleColor.Green;
            for (int i = 0;i < int.Parse(arguments[0]); i++)
            {
                Console.WriteLine("loop " + i);
            }
            Console.ForegroundColor = ConsoleColor.White;
        }
    }
}
