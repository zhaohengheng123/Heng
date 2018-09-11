using Heng.Bizlogic.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Heng.Bizlogic.Enum
{
    public class DeviceEnum
    {
        public static class KeyBoardEnum
        {
            public static Byte Alt = 0x40;
            public static Byte Ctrl = 0x10;
            public static Byte Shift = 0x20;
            public static Byte Win = 0x80;
            public static string a = StringUtil.Chr(0x04);
            public static string b = StringUtil.Chr(0x05);
            public static string c = StringUtil.Chr(0x06);
            public static string d = StringUtil.Chr(0x07);
            public static string e = StringUtil.Chr(0x08);
            public static string f = StringUtil.Chr(0x09);
            public static string g = StringUtil.Chr(0x0a);
            public static string h = StringUtil.Chr(0x0b);
            public static string i = StringUtil.Chr(0x0c);
            public static string j = StringUtil.Chr(0x0d);
            public static string k = StringUtil.Chr(0x0e);
            public static string l = StringUtil.Chr(0x0f);
            public static string m = StringUtil.Chr(0x10);
            public static string n = StringUtil.Chr(0x11);
            public static string o = StringUtil.Chr(0x12);
            public static string p = StringUtil.Chr(0x13);
            public static string q = StringUtil.Chr(0x14);
            public static string r = StringUtil.Chr(0x15);
            public static string s = StringUtil.Chr(0x16);
            public static string t = StringUtil.Chr(0x17);
            public static string u = StringUtil.Chr(0x18);
            public static string v = StringUtil.Chr(0x19);
            public static string w = StringUtil.Chr(0x1a);
            public static string x = StringUtil.Chr(0x1b);
            public static string y = StringUtil.Chr(0x1c);
            public static string z = StringUtil.Chr(0x1d);
            public static string num1 = StringUtil.Chr(0x1e);
            public static string num2 = StringUtil.Chr(0x1f);
            public static string num3 = StringUtil.Chr(0x20);
            public static string num4 = StringUtil.Chr(0x21);
            public static string num5 = StringUtil.Chr(0x22);
            public static string num6 = StringUtil.Chr(0x23);
            public static string num7 = StringUtil.Chr(0x24);
            public static string num8 = StringUtil.Chr(0x25);
            public static string num9 = StringUtil.Chr(0x26);
            public static string num0 = StringUtil.Chr(0x27);
            public static string Return= StringUtil.Chr(0x28);
            public static string ESCAPE = StringUtil.Chr(0x29);
            public static string DELETE = StringUtil.Chr(0x2a);
            public static string Tab = StringUtil.Chr(0x2b);
            public static string Spacebar = StringUtil.Chr(0x2c);
            public static string F1 = StringUtil.Chr(0x3a);
            public static string F2 = StringUtil.Chr(0x3b);
            public static string F3 = StringUtil.Chr(0x3c);
            public static string F4 = StringUtil.Chr(0x3d);
            public static string F5 = StringUtil.Chr(0x3e);
            public static string F6 = StringUtil.Chr(0x3f);
            public static string F7 = StringUtil.Chr(0x40);
            public static string F8 = StringUtil.Chr(0x41);
            public static string F9 = StringUtil.Chr(0x42);
            public static string F10 = StringUtil.Chr(0x43);
            public static string F11 = StringUtil.Chr(0x44);
            public static string F12 = StringUtil.Chr(0x45);
            public static string PrintScreen = StringUtil.Chr(0x46);
        }

        public static class MouseEnum
        {
            public static int Left = 1;
            public static int Right = 2;
            public static int Middle = 4;
            public static int Release = 0;
        }


    }
}
