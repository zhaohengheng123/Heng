using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Heng.Bizlogic.Operate.ToolSkill.Dialog
{
    public class 道具 : IToolSkill
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
            //查看是否打开
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
