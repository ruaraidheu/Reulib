using Ruaraidheulib.Interface.reulib64.Win64.Version;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static Ruaraidheulib.Winforms.MessageBox;

namespace Ruaraidheulib.Winforms
{
    public struct MessageBox
    {
        public enum ButtonLayout
        {
            One, Two, Three, Four
        }
        /// <summary>
        /// Shows a Message dialog.
        /// </summary>
        /// <param name="msg">Text that the dialog displays</param>
        /// <param name="title">Text in the title bar</param>
        /// <param name="buttonlayout">How many buttons are displayed</param>
        /// <param name="defaultbutton">Accept button</param>
        /// <param name="button1">Text on button one</param>
        /// <param name="button2">Text on button two</param>
        /// <param name="button3">Text on button three</param>
        /// <param name="button4">Text on button four</param>
        /// <returns>Text of the button that was clicked</returns>
        public static string Show(string msg, string title, ButtonLayout buttonlayout, ButtonLayout defaultbutton, string button1, string button2 = "", string button3 = "", string button4 = "")
        {
            using (MsgBox m = new MsgBox(msg, title, buttonlayout, defaultbutton, button1, button2, button3, button4))
            {
                m.UsingRECompute = true;
                m.ShowDialog();
                return m.response;
            }
        }
        /// <summary>
        /// Shows a Message dialog.
        /// </summary>
        /// <param name="msg">Text that the dialog displays</param>
        /// <returns>Text of the button that was clicked</returns>
        public static string Show(string msg)
        {
            using (MsgBox m = new MsgBox(msg, "", ButtonLayout.One, ButtonLayout.One, "OK", "", "", ""))
            {
                m.UsingRECompute = true;
                m.ShowDialog();
                return m.response;
            }
        }
        /// <summary>
        /// Shows a Message dialog.
        /// </summary>
        /// <param name="msg">Text that the dialog displays</param>
        /// <param name="title">Text in the title bar</param>
        /// <returns>Text of the button that was clicked</returns>
        public static string Show(string msg, string title)
        {
            using (MsgBox m = new MsgBox(msg, title, ButtonLayout.One, ButtonLayout.One, "OK", "", "", ""))
            {
                m.UsingRECompute = true;
                m.ShowDialog();
                return m.response;
            }
        }
        /// <summary>
        /// Shows a Message dialog.
        /// </summary>
        /// <param name="msg">Text that the dialog displays</param>
        /// <param name="title">Text in the title bar</param>
        /// <param name="button1">Text on button one</param>
        /// <returns>Text of the button that was clicked</returns>
        public static string Show(string msg, string title, string button1)
        {
            using (MsgBox m = new MsgBox(msg, title, ButtonLayout.One, ButtonLayout.One, button1, "", "", ""))
            {
                m.UsingRECompute = true;
                m.ShowDialog();
                return m.response;
            }
        }
        /// <summary>
        /// Shows a Message dialog.
        /// </summary>
        /// <param name="msg">Text that the dialog displays</param>
        /// <param name="title">Text in the title bar</param>
        /// <param name="bl">How many buttons are displayed</param>
        /// <param name="button1">Text on button one</param>
        /// <param name="button2">Text on button two</param>
        /// <param name="button3">Text on button three</param>
        /// <param name="button4">Text on button four</param>
        /// <returns>Text of the button that was clicked</returns>
        public static string Show(string msg, string title, ButtonLayout bl, string button1, string button2 = "", string button3 = "", string button4 = "")
        {
            using (MsgBox m = new MsgBox(msg, title, bl, ButtonLayout.One, button1, button2, button3, button4))
            {
                m.UsingRECompute = true;
                m.ShowDialog();
                return m.response;
            }
        }
        public static ButtonLayout ShowBL(string msg, string title, ButtonLayout buttonlayout, ButtonLayout defaultbutton, string button1, string button2 = "", string button3 = "", string button4 = "")
        {
            using (MsgBox m = new MsgBox(msg, title, buttonlayout, defaultbutton, button1, button2, button3, button4))
            {
                m.UsingRECompute = true;
                m.ShowDialog();
                return m.responsebl;
            }
        }
        public static ButtonLayout ShowBL(string msg)
        {
            using (MsgBox m = new MsgBox(msg, "", ButtonLayout.One, ButtonLayout.One, "OK", "", "", ""))
            {
                m.UsingRECompute = true;
                m.ShowDialog();
                return m.responsebl;
            }
        }
        public static string ErrorWrite(Exception e)
        {
            string error = e.GetType().Name+" in " + e.Source + Environment.NewLine + Environment.NewLine
                + "Message: " + e.Message + Environment.NewLine
                + "Target Site: " + e.TargetSite + Environment.NewLine + Environment.NewLine
                + "Stack Trace: " + e.StackTrace + Environment.NewLine + Environment.NewLine;
            Exception ex = e;
            while (ex.InnerException != null)
            {
                ex = ex.InnerException;
                error += Environment.NewLine + "---Inner Exception---" + Environment.NewLine + ex.GetType().Name + Environment.NewLine + Environment.NewLine
                + "Message: " + ex.Message + Environment.NewLine
                + "Target Site: " + ex.TargetSite + Environment.NewLine + Environment.NewLine
                + "Stack Trace: " + ex.StackTrace + Environment.NewLine + Environment.NewLine;
            }
            return error;
        }
    }
    internal partial class MsgBox : Form
    {
        public string response;
        public ButtonLayout responsebl;
        int minwidth;
        int maxwidth = 486;
        int minheight = 106;
        int maxheight;
        bool debug = false;
        bool usingrecompute = true;
        public ButtonLayout bl;

        public bool Debug
        { get => debug;
            set
            {
                debug = value; textBox1.Text
                    = "Location: " + Location.ToString() + Environment.NewLine
                    + "Size: " + Size.ToString() + Environment.NewLine
                    + "Label Location: " + textBox1.Size.ToString() + Environment.NewLine
                    + "Label Size: " + textBox1.Size.ToString() + Environment.NewLine
                    + "Button1 Location: " + button1.Size.ToString() + Environment.NewLine
                    + "Button1 Size: " + button1.Size.ToString() + Environment.NewLine
                    + "Button2 Location: " + button2.Size.ToString() + Environment.NewLine
                    + "Button2 Size: " + button2.Size.ToString() + Environment.NewLine
                    + "Button3 Location: " + button3.Size.ToString() + Environment.NewLine
                    + "Button3 Size: " + button3.Size.ToString() + Environment.NewLine
                    + "Button4 Location: " + button4.Size.ToString() + Environment.NewLine
                    + "Button4 Size: " + button4.Size.ToString() + Environment.NewLine
                    + "Panel Location: " + panel1.Size.ToString() + Environment.NewLine
                    + "Panel Size: " + panel1.Size.ToString() + Environment.NewLine;
                RECompute();
            }
        }

        public bool UsingRECompute { get => usingrecompute; set => usingrecompute = value; }

        public MsgBox(string msg, string title, ButtonLayout buttonlayout, ButtonLayout defaultbutton, string but1, string but2, string but3, string but4)
        {
            InitializeComponent();
            bl = buttonlayout;
            Text = title;
            textBox1.Text = msg;
            button1.Text = but1;
            button2.Text = but2;
            button3.Text = but3;
            button4.Text = but4;
            switch (defaultbutton)
            {
                case ButtonLayout.One: AcceptButton = button1; break;
                case ButtonLayout.Two: AcceptButton = button2; break;
                case ButtonLayout.Three: AcceptButton = button3; break;
                case ButtonLayout.Four: AcceptButton = button4; break;
            }
            RECompute();
            if (VersionInfo.Get().Usingmono)
            {
                panel1.BackColor = BackColor;
            }
        }
        public void RECompute()
        {
            switch (bl)
            {
                case ButtonLayout.One: button1.Show(); button2.Hide(); button3.Hide(); button4.Hide(); break;
                case ButtonLayout.Two: button1.Show(); button2.Show(); button3.Hide(); button4.Hide(); break;
                case ButtonLayout.Three: button1.Show(); button2.Show(); button3.Show(); button4.Hide(); break;
                case ButtonLayout.Four: button1.Show(); button2.Show(); button3.Show(); button4.Show(); break;
            }
            int b1 = 149;
            int b2 = 242;
            int b3 = 340;
            int b4 = 470;
            if (button1.Size.Width > 75)
            {
                button1.Width = 75;
                button2.Width = 75;
                button3.Width = 75;
                button4.Width = 75;
                button1.Location = new Point(63, button1.Location.Y);
                button2.Location = new Point(158, button2.Location.Y);
                button3.Location = new Point(253, button3.Location.Y);
                button4.Location = new Point(348, button4.Location.Y);
            }
            b1 = button1.Location.X + button1.Size.Width + button1.Location.X;
            button2.Location = new Point((b1- button1.Location.X) + 20, button2.Location.Y);
            b2 = button2.Location.X + button2.Size.Width + button1.Location.X;
            button3.Location = new Point((b2- button1.Location.X) + 20, button3.Location.Y);
            b3 = button3.Location.X + button3.Size.Width + button1.Location.X;
            button4.Location = new Point((b3- button1.Location.X) + 20, button4.Location.Y);
            b4 = button4.Location.X + button4.Size.Width + button1.Location.X;
            maxwidth = b4;
            Graphics g = textBox1.CreateGraphics();
            Size s2 = g.MeasureString(textBox1.Text, textBox1.Font, b4 - (textBox1.Location.X * 2)).ToSize();
            textBox1.Width = s2.Width + 10;
            if (textBox1.Width > b4-(textBox1.Location.X*2))
            {
                textBox1.Width = b4 - (textBox1.Location.X * 2);
            }
            minwidth = textBox1.Width+ (textBox1.Location.X * 2);
            switch (bl)
            {
                case ButtonLayout.One:
                    if (minwidth < b1)
                    {
                        minwidth = b1;
                    }
                    break;
                case ButtonLayout.Two:
                    if (minwidth < b2)
                    {
                        minwidth = b2;
                    }
                    break;
                case ButtonLayout.Three:
                    if (minwidth < b3)
                    {
                        minwidth = b3;
                    }
                    break;
                case ButtonLayout.Four:
                    if (minwidth < b4)
                    {
                        minwidth = b4;
                    }
                    break;
            }
            if (minwidth>maxwidth)
            {
                minwidth = maxwidth;
            }
            s2 = g.MeasureString(textBox1.Text, textBox1.Font, textBox1.Width).ToSize();
            if (s2.Height + 20 > minheight)
            {
                minheight = s2.Height + 20;
            }
            maxheight = (int)(Screen.FromControl(this).Bounds.Height * 0.7f);

            if (minheight > maxheight)
            {
                minheight = maxheight;
                textBox1.ScrollBars = ScrollBars.Vertical;
                //textBox1.Width = textBox1.Width - 20;
            }

            ClientSize = new Size(minwidth, minheight);
            textBox1.Height =  ClientSize.Height - panel1.Height - (textBox1.Location.Y * 2);
            CenterToScreen();
        }
        [Obsolete]
        public void Compute(bool? useRECompute)
        {
            Graphics g = textBox1.CreateGraphics();
            Size s2 = g.MeasureString(textBox1.Text, textBox1.Font, textBox1.Width).ToSize();
            s2 = new Size(s2.Width + 10, s2.Height);
            switch (bl)
            {
                case ButtonLayout.One: if (s2.Width < 165)s2.Width = 145; button1.Show(); button2.Hide(); button3.Hide(); button4.Hide(); break;
                case ButtonLayout.Two: if (s2.Width < 258) s2.Width = 238; button1.Show(); button2.Show(); button3.Hide(); button4.Hide(); break;
                case ButtonLayout.Three: if (s2.Width < 391) s2.Width = 371; button1.Show(); button2.Show(); button3.Show(); button4.Hide(); break;
                case ButtonLayout.Four: if (s2.Width < 486) s2.Width = 466; button1.Show(); button2.Show(); button3.Show(); button4.Show(); break;
            }
            g.Dispose();
            textBox1.Size = new Size(s2.Width, s2.Height+20);
            minwidth = s2.Width + 24+12 > minwidth ? s2.Width+24+12 : minwidth;
            if (minwidth > 486)
            {
                minwidth = 486;
            }
            minheight = textBox1.Size.Height + 44 + 45+16  > minheight ? textBox1.Size.Height + 44 + 45+16 : minheight;
            Size = Size.Width < minwidth ? new Size(minwidth, Size.Height) : new Size(Size.Width, Size.Height);
            Size = Size.Width > minwidth ? new Size(minwidth, Size.Height) : new Size(Size.Width, Size.Height);
            Size = Size.Height < minheight ? new Size(Size.Width, minheight) : new Size(Size.Width, Size.Height);
            CenterToScreen();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            response = button1.Text;
            responsebl = ButtonLayout.One;
            DialogResult = DialogResult.OK;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            response = button2.Text;
            responsebl = ButtonLayout.Two;
            DialogResult = DialogResult.OK;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            response = button3.Text;
            responsebl = ButtonLayout.Three;
            DialogResult = DialogResult.OK;
        }

        private void button4_Click(object sender, EventArgs e)
        {
            response = button4.Text;
            responsebl = ButtonLayout.Four;
            DialogResult = DialogResult.OK;
        }
    }
}
