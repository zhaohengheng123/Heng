using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Heng.Bizlogic
{
    /// <summary>
    /// 指令执行统一入口
    /// 任何移动指令最大化，可拆分成以下步骤
    /// 1、打开物品栏目→使用道具→选择道具出来的对话框  道具技能使用  2种类型，1种自使用  2使用后需要移动鼠标再次点击选择 3种快捷键   是否需要关闭的属性 
    /// 2、打开地图→开始选点→移动到目的地   MoveType1
    /// 3、鼠标操作当地的地图→移动到指定位置 MoveType2
    /// 4、点击对应位置，移动到指定位置淡季→打开对话框→选择指定位置对话 Take  Dialog
    /// 5、点击到对应位置，变红 Dialog
    /// 6、不操作   进入的      Dialog
    /// 7、
    /// 
    /// </summary>
    public class MainEntrance
    {



    }
}
