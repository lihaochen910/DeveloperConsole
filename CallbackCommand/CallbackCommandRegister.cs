using DeveloperConsole.CommandFramework;
using System;
using System.Collections.Generic;

namespace DeveloperConsole.CallbackCommand
{
    /// <summary>
    /// 普通回调指令注册器
    /// </summary>
    class CallbackCommandRegister
    {
        /// <summary>
        /// 所有回调命令在此注册
        /// </summary>
        /// <param type="string">指令名</param>
        /// <param type="Func<string[],string>">指令回调接口</param>
        private Dictionary<string, Func<string[], string>> preReg = new Dictionary<string, Func<string[], string>>()
        {
            { "cls", TestCommand4.Execute },
            { "clean", TestCommand4.Execute },
            { "about", TestCommand5.Execute },
            { "info", TestCommand5.Execute },





        };

        private static CallbackCommandRegister instance;
        public static CallbackCommandRegister _ins
        {
            get
            {
                if (instance == null)
                    instance = new CallbackCommandRegister();
                return instance;
            }
            private set { instance = value; }
        }
        private CallbackCommandRegister() { Init(); }
        private void Init()
        {
            foreach(var preRegCommand in preReg)
            {
                CommandsRepository._ins.RegisterCommand(preRegCommand.Key, new CommandCallback(preRegCommand.Value));
            }
        }
    }
}
