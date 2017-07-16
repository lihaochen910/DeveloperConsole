using DeveloperConsole.CommandFramework;
using System;
using System.Runtime.InteropServices;

namespace DeveloperConsole
{
    [Command("exit", "测试命令：exit", CommandType.Client)]
    class TestCommand3 : CommandBase
    {
        public override void Execute(string[] arguments)
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.ForegroundColor = ConsoleColor.White;
            Environment.Exit(0);
        }
    }
}
