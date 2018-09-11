using Heng.Bizlogic.entity;
using Heng.Bizlogic.Utils;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Heng.Bizlogic.Operate.Dialog
{
    public class Click : IDialog
    {


        public void ErrorAct(string insuct)
        {
            throw new NotImplementedException();
        }

        public void How2Choice(int pX,int pY,int pRX,int pRY)
        {
            //点击选择，选择方式


        }


        public void How2Dialog(MapCoordinate coor, int windowNum)
        {
            //获取当前地图
            MoveBiz wbiz = new MoveBiz(windowNum);
            GameCommonUtil biz = new GameCommonUtil();
            MapCoordinate nCoor = wbiz.GetNowMap();
            bool flag = biz.CheckIsCloseToNPC(nCoor, coor);
            if (!flag)
            {
                //TODO,记录错误
                return;
            }
            wbiz.PointPutToGameCoor(coor.coor);
            //先按F9，在Alt+H
            wbiz.PingBiPlayer();
            WindowAPI.MMouseClick(1);
            Thread.Sleep(200);
            //checkDialog
            //Bitmap bm = PicUtil.GetScreen();
            Point po = new Point();
            //进入对话框了
            if (!biz.HasDialogExist(windowNum, out po))
            {
                Random ra = new Random();
                int num = ra.Next(-1, 2);
                //没进入对话框
                wbiz.MMoveRealCoor(num, num);
                How2Dialog(coor, windowNum);
            }
        }

        public void PreOperate(int windowNum)
        {
            GameCommonUtil biz = new GameCommonUtil();
            biz.CloseDialogIfExist(windowNum);
        }
    }
}
