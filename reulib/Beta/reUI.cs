using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ruaraidheulib.Beta.reUI
{
    public class BRelative
    {
        double relx, rely, relw, relh;
        UIControl cont;

        public BRelative(UIControl control)
        {
            cont = control;
            ControlUpdate();
        }
        public void Update()
        {
            cont.x = (int)(relx * cont.parent.width);
            cont.y = (int)(rely * cont.parent.height);
            cont.width = (int)(relw * cont.parent.width);
            cont.height = (int)(relh * cont.parent.height);
        }
        public void ControlUpdate()
        {
            relx = (double)cont.x / (double)cont.parent.width;
            rely = (double)cont.y / (double)cont.parent.height;
            relw = (double)cont.width / (double)cont.parent.width;
            relh = (double)cont.height / (double)cont.parent.height;
        }
    }
    public class UIControl
    {
        public int x;
        public int y;
        public int width;
        public int height;
        public UIControl parent;
    }
}
