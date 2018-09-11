using Heng.Bizlogic.entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Heng.Bizlogic.Operate.Dialog
{
    public class TakeRed : IDialog
    {
        public bool AfterCheck()
        {
            throw new NotImplementedException();
        }

        public void ErrorAct(string insuct)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Type,有的单纯点击类对话类，有的功能类的（买宝石等）！！！，里面也有个type，没什么特殊就也是pass的节奏
        /// </summary>
        /// <param name="num"></param>
        public void How2Choice(int num)
        {
            throw new NotImplementedException();
        }

        public void How2Dialog(MapCoordinate coor)
        {
            //Move
            //获取当前地图


            if ()
            {


            }
            


        }

        public bool PreCheck()
        {
           //在开始对话前，需保证，页面空白，无对话框，否则会导致失败



        }
    }
}
