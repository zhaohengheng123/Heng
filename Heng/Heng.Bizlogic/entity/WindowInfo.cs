using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Heng.Bizlogic.entity
{
    public class WindowInfo
    {
        public IntPtr hWnd { get; set; }
        public string szWindowName { get; set; }
        public string szClassName { get; set; }
    }
}
