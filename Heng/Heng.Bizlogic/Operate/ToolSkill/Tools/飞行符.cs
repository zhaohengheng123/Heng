using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Heng.Bizlogic.Operate.ToolSkill
{
    /// <summary>
    /// 使用方式！！！！，丢弃炼妖等等，每件物品需要不一样的类和不一样的用法
    /// </summary>
    public class 飞行符 : IToolSkill
    {
        public bool AfterCheck(Point point)
        {
            throw new NotImplementedException();
        }

        public void ErrorAct(string insuct)
        {
            throw new NotImplementedException();
        }

        public bool IsSelfUse()
        {
            throw new NotImplementedException();
        }

        public bool PreCheck(string insuct)
        {
            throw new NotImplementedException();
        }

        public void Use(string name)
        {
            throw new NotImplementedException();
        }

        public void UseMethod(Point point)
        {
            throw new NotImplementedException();
        }
    }
}
