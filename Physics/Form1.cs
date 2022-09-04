using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using Tao.OpenGl;
using Tao.Platform;
using Tao.FreeGlut;
using System.Net.NetworkInformation;

namespace Physics
{
    public partial class Form1 : Form
    {
        public Tiles tiles;
        private int score = 0;

        public Form1()
        {
            InitializeComponent();
            tiles = new Tiles(this.Controls);
            this.KeyDown += new KeyEventHandler(OnKeyboardPressed);
        } 

        private void OnKeyboardPressed(object sender,KeyEventArgs e)
        {
            score = tiles.OnKeyboardPressed(e.KeyCode.ToString(), score, this.Controls);
            label1.Text = "Score: " + score;
    }
}
