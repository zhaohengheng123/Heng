using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Heng.Bizlogic.Operate.Move
{
    public interface IMove
    {
        bool PreCheck(string insuct);

        void Move(Point point);

        bool AfterCheck(Point point);

        void ErrorAct(string insuct);
    }
}
