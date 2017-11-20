using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Ruaraidheulib.Winforms
{
    public class Relative
    {
        double relx, rely, relw, relh, relf;
        Control cont;

        public Relative(Control control)
        {
            cont = control;
            ControlUpdate();
        }
        public void Update()
        {
            cont.Left = (int)(relx * cont.Parent.Width);
            cont.Top = (int)(rely * cont.Parent.Height);
            cont.Width = (int)(relw * cont.Parent.Width);
            cont.Height = (int)(relh * cont.Parent.Height);
            cont.Font = new System.Drawing.Font(cont.Font.Name, (float)(relf*cont.Parent.Height));
        }
        public void ControlUpdate()
        {
            relx = (double)cont.Left / (double)cont.Parent.Width;
            rely = (double)cont.Top / (double)cont.Parent.Height;
            relw = (double)cont.Width / (double)cont.Parent.Width;
            relh = (double)cont.Height / (double)cont.Parent.Height;
            relf = (double)cont.Font.Size / (double)cont.Parent.Height;
        }
        public void FalseUpdate(int width, int height)
        {
            relx = (double)cont.Left / (double)width;
            rely = (double)cont.Top / (double)height;
            relw = (double)cont.Width / (double)width;
            relh = (double)cont.Height / (double)height;
            relf = (double)cont.Font.Size / (double)height;
        }
        public void ChangeControl(Control control)
        {
            cont = control;
            ControlUpdate();
        }
    }
}
