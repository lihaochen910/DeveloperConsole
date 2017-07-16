using System;
using DeveloperConsole.CommandFramework;

namespace DeveloperConsole
{
    enum MoneyType
    {
        Gold,
        Diamond,
        PkPt,
    }
    [Command("hi", "测试命令：hi",CommandType.Client)]
    class TestCommand : CommandBase
    {
        public override void Execute(string[] arguments)
        {
            Console.ForegroundColor = ConsoleColor.White;
        }
    }
}
