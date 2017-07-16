using System;
using System.Collections.Generic;
using System.Reflection;
using System.Linq;

namespace DeveloperConsole.CommandFramework
{
    class CommandRegister
    {
        private static CommandRegister instance;
        /// <summary>
        /// 命令注册器 单例
        /// </summary>
        public static CommandRegister _ins{
            get {
                if (instance == null)
                    instance = new CommandRegister();
                return instance;
            }
            private set { instance = value; }
        }
        /// <summary>
        /// @TODO:将带有Command特性的类注册到命令仓库中
        /// </summary>
        /// <param name="asm">typeof(Target).Assembly</param>
        public void Register(Assembly asm)
        {
            CommandsRepository repository = CommandsRepository._ins;
            Type[] types = asm.GetTypes();
            //Type[] types = asm.GetExportedTypes();
            /***
             * 在所有程序集中查找特性为CommandAttribute的类型
             ***/
            Func<System.Attribute[], bool> IsCommand = attrs =>
            {
                foreach (Attribute cm in attrs)
                    if (cm is CommandAttribute)
                        return true;

                return false;
            };
            /***
             * 在所有程序集中查找特性为CommandAttribute的类型
             ***/
            Type[] commandTypes = types.Where(attrs =>{
                return IsCommand(System.Attribute.GetCustomAttributes(attrs, true));
            }).ToArray();
            /***
             * 遍历特性为CommandAttribute的类,注册到命令仓库 
             ***/
            foreach (var command in commandTypes)
            {
                //创建命令类实例
                var obj = command.Assembly.CreateInstance(command.FullName);
                if(obj != null && obj is CommandBase)
                {
                    var preExecuteCommand = obj as CommandBase;
                    CommandsRepository._ins.RegisterCommand(command.GetCustomAttribute<CommandAttribute>().CommandName, preExecuteCommand);
                }
            }
        }
    }
}
