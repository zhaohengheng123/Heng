using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Heng.Bizlogic.Operate.Dialog
{
    /// <summary>
    /// dialog,点击出dialog，以及接下来做的操作
    /// 比如点击出来后，购买物品！
    /// </summary>
    public interface IDialog
    {
        bool PreCheck(string insuct);//坐标点检测

        bool AfterCheck();//对话完毕指定位置色块消失

        void ErrorAct(string insuct);//失败应对，走远点（随机），调整下坐标再回来

        void How2Dialog(string insuct);

        void How2Choice(int num);


    }
}
