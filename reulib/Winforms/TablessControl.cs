using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Ruaraidheulib.Winforms
{
    public class TablessControl : TabControl
    {
        /// <summary>
        /// Creates a tab control with tabs hidden during runtime.
        /// </summary>
        /// <param name="m"></param>
        protected override void WndProc(ref Message m)
        {
            if (m.Msg == 0x1328 && !DesignMode) m.Result = (IntPtr)1;
            else base.WndProc(ref m);
        }
    }
}
