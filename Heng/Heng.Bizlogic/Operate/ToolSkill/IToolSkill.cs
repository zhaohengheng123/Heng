using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Heng.Bizlogic.Operate.ToolSkill
{
    public interface IToolSkill
    {
        bool PreCheck(string insuct);

        bool AfterCheck(Point point);

        void ErrorAct(string insuct);

        bool IsSelfUse();

        void UseMethod(Point point);

        void Use(string name);
            
    }
}
