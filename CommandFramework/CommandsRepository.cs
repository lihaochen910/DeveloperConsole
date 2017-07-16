using System;
using System.Collections.Generic;

namespace DeveloperConsole.CommandFramework
{
    public delegate string CommandCallback(params string[] args);
    class CommandsRepository
    {
        private static CommandsRepository           instance;
        private Dictionary<string, CommandCallback> CallbackRepository;
        private Dictionary<string, CommandBase>     CommandClassRepository;
        /// <summary>
        /// 命令仓库 单例
        /// </summary>
        public static CommandsRepository _ins
        {
            get
            {
                if (instance == null)
                    instance = new CommandsRepository();
                return instance;
            }
            private set { instance = value; }
        }

        private CommandsRepository()
        {
            CallbackRepository = new Dictionary<string, CommandCallback>();
            CommandClassRepository = new Dictionary<string, CommandBase>();
        }
        /// <summary>
        /// 向仓库中注册指令
        /// </summary>
        /// <param name="command"></param>
        /// <param name="callback"></param>
        public void RegisterCommand(string command, CommandCallback callback)
        {
            Console.WriteLine("import " + command + " " + callback.Target + "()");
            CallbackRepository[command] = new CommandCallback(callback);
        }
        public void RegisterCommand(string command, CommandBase commandClass)
        {
            Console.WriteLine("import " + command + " " + commandClass.GetType().Name);
            CommandClassRepository[command] = commandClass;
        }
        /// <summary>
        /// 执行指令
        /// </summary>
        /// <param name="command">指令字符串</param>
        /// <param name="args">指令参数</param>
        /// <returns></returns>
        public string ExecuteCommand(string command, string[] args)
        {
            if (CallbackRepository.ContainsKey(command))
            {
                return CallbackRepository[command](args);
            }
            else if (CommandClassRepository.ContainsKey(command))
            {
                CommandClassRepository[command].Execute(args);
                return null;
            }
            else
            {
                Console.WriteLine("'" + command + "' Command not found");
                return "'" + command +  "' not found";
            }
        }
        /// <summary>
        /// 在所有命令中查找以指定头开始的命令
        /// </summary>
        /// <param name="InPrefix">待匹配的指令字符串</param>
        /// <returns></returns>
        public List<CommandBase> FilterByString(string InPrefix)
        {
            if (string.IsNullOrEmpty(InPrefix))
                return null;
            List<CommandBase> Results = new List<CommandBase>(16);

            var Iter = CommandClassRepository.GetEnumerator();

            while (Iter.MoveNext())
            {
                var Command = Iter.Current.Value;

                var baseCommand = (Command.GetType().GetCustomAttributes(typeof(CommandAttribute), false)[0] as CommandAttribute).CommandName;

                if (baseCommand.StartsWith(InPrefix, StringComparison.CurrentCultureIgnoreCase) ||
                    string.IsNullOrEmpty(InPrefix)
                    )
                {
                    Results.Add(Command);
                }
            }

            return Results;
        }
    }
}
