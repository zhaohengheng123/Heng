using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Heng.Bizlogic.Enum
{
    public static class GameEnum
    {
        public static class EntranceType
        {
            public static string 点击触发until = "Click";
            public static string 走入出发 = "Walk";
            public static string 悬浮变红触发until = "Hover";
        }

        public static class UntilType
        {
            public static string 截图有红色 = "takeRed";
            public static string 弹出会话框 = "dialog";
            public static string 无持续 = "";
        }
    }
  

}
