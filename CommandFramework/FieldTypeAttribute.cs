using System;

namespace DeveloperConsole.CommandFramework
{
    [AttributeUsage(AttributeTargets.Class)]
    class FieldAttribute : Attribute
    {
        public int      index { get; private set; }
        public string   field { get; private set; }
        public Type     fieldEnum { get; private set; }

        /// <summary>
        /// 参数构造
        /// </summary>
        /// <param name="index">参数索引</param>
        /// <param name="fieldEnum">参数枚举(eg.gold/diamond/PkPt)</param>
        public FieldAttribute(int index,Type fieldEnum)
        {
            this.index =        index;
            this.fieldEnum =    fieldEnum;
        }
        /// <summary>
        /// 参数构造
        /// </summary>
        /// <param name="index">参数索引</param>
        /// <param name="field">普通参数</param>
        public FieldAttribute(int index,string field)
        {
            this.index =    index;
            this.field =    field;
        }
    }
}
