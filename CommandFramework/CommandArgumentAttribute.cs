using System;

namespace DeveloperConsole.CommandFramework
{
    [AttributeUsage(AttributeTargets.Class)]
    class CommandArgumentAttribute : Attribute
    {
        public CommandArgumentAttribute(int index,)
        {

        }
    }
}
