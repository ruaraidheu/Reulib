using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static Ruaraidheulib.Games.Card;

namespace Ruaraidheulib.Winforms
{
    public partial class Card : UserControl
    {
        Games.Card c = new Games.Card(Suits.Spades, Numbers.A);
        public Games.Card.Suits Suit
        {
            get { return c.Suit; }
            set
            {
                Direction tmp = c.direction;
                c = new Games.Card(value, c.Number);
                c.direction = tmp;
                Setupdisp();
            }
        }
        public Games.Card.Numbers Number
        {
            get { return c.Number; }
            set
            {
                Direction tmp = c.direction;
                c = new Games.Card(c.Suit, value);
                c.direction = tmp;
                Setupdisp();
            }
        }
        public Games.Card.Direction Direction
        {
            get { return c.direction; }
            set
            {
                c.direction = value;
                Setupdisp();
            }
        }

        Relative r1;
        Relative r2;
        Relative r3;
        Relative r4;

        public Card(Suits s, Numbers n)
        {
            InitializeComponent();
            c = new Games.Card(s, n);
            r1 = new Relative(label1);
            r2 = new Relative(label2);
            r3 = new Relative(label3);
            r4 = new Relative(panel1);
            Setupdisp();
        }
        public Card(Games.Card card)
        {
            InitializeComponent();
            c = card;
            r1 = new Relative(label1);
            r2 = new Relative(label2);
            r3 = new Relative(label3);
            r4 = new Relative(panel1);
            Setupdisp();
        }
        public Card()
        {
            InitializeComponent();
            r1 = new Relative(label1);
            r2 = new Relative(label2);
            r3 = new Relative(label3);
            r4 = new Relative(panel1);
            Setupdisp();
        }
        public void Changecard(Suits s, Numbers n)
        {
            Direction tmp = c.direction;
            c = new Games.Card(s, n);
            c.direction = tmp;
            Setupdisp();
        }
        public void Changecard(Games.Card card)
        {
            c = card;
            Setupdisp();
        }
        public void Setupdisp()
        {
            label1.Text = c.Number.ToString();
            label2.Text = c.Number.ToString();
            label3.Text = c.Suit.ToString();
            if (c.direction == Direction.Down)
            {
                label1.Visible = false;
                label2.Visible = false;
                label3.Visible = false;
                panel1.Visible = true;
            }
            else
            {
                label1.Visible = true;
                label2.Visible = true;
                label3.Visible = true;
                panel1.Visible = false;
            }
        }

        private void Card_Resize(object sender, EventArgs e)
        {
            r1.Update();
            r2.Update();
            r3.Update();
            r4.Update();
        }
    }
}
