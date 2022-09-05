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

        private void OnKeyboardPressed(object sender, KeyEventArgs e)
        {
            bool ifPicWasMoved = false;

            switch (e.KeyCode.ToString())
            {
                case "Right":
                    for (int k = 0; k < 4; k++)
                    {
                        for (int l = 2; l >= 0; l--)
                        {
                            if (!tiles.IsEmptyTile(k, l))
                            {
                                for (int j = l + 1; j < 4; j++)
                                {
                                    if (tiles.IsEmptyTile(k, j))
                                    {
                                        ifPicWasMoved = true;
                                        tiles.Move(k, j - 1, k, j);
                                    }
                                    else
                                    {
                                        int a = (tiles[k, j] as Picture).Value;
                                        int b = (tiles[k, j - 1] as Picture).Value;
                                        if (a == b)
                                        {
                                            ifPicWasMoved = true;
                                            score += tiles.Merge(k, j - 1, k, j, this.Controls);
                                            label1.Text = "Score: " + score;
                                        }
                                    }
                                }
                            }
                        }
                    }
                    break;
                case "Left":
                    for (int k = 0; k < 4; k++)
                    {
                        for (int l = 1; l < 4; l++)
                        {
                            if (!tiles.IsEmptyTile(k, l))
                            {
                                for (int j = l - 1; j >= 0; j--)
                                {
                                    if (tiles.IsEmptyTile(k, j))
                                    {
                                        ifPicWasMoved = true;
                                        tiles.Move(k, j + 1, k, j);
                                    }
                                    else
                                    {
                                        int a = (tiles[k, j] as Picture).Value;
                                        int b = (tiles[k, j + 1] as Picture).Value;
                                        if (a == b)
                                        {
                                            ifPicWasMoved = true;
                                            score += tiles.Merge(k, j + 1, k, j, this.Controls);
                                            label1.Text = "Score: " + score;
                                        }
                                    }
                                }
                            }
                        }
                    }
                    break;
                case "Down":
                    for (int k = 2; k >= 0; k--)
                    {
                        for (int l = 0; l < 4; l++)
                        {
                            if (!tiles.IsEmptyTile(k, l))
                            {
                                for (int j = k + 1; j < 4; j++)
                                {
                                    if (tiles.IsEmptyTile(j, l))
                                    {
                                        ifPicWasMoved = true;
                                        tiles.Move(j - 1, l, j, l);
                                    }
                                    else
                                    {
                                        int a = (tiles[j, l] as Picture).Value;
                                        int b = (tiles[j - 1, l] as Picture).Value;
                                        if (a == b)
                                        {
                                            ifPicWasMoved = true;
                                            score += tiles.Merge(j - 1, l, j, l, this.Controls);
                                            label1.Text = "Score: " + score;
                                        }
                                    }
                                }
                            }
                        }
                    }
                    break;
                case "Up":
                    for (int k = 1; k < 4; k++)
                    {
                        for (int l = 0; l < 4; l++)
                        {
                            if (!tiles.IsEmptyTile(k, l))
                            {
                                for (int j = k - 1; j >= 0; j--)
                                {
                                    if (tiles.IsEmptyTile(j, l))
                                    {
                                        ifPicWasMoved = true;
                                        tiles.Move(j + 1, l, j, l);
                                    }
                                    else
                                    {
                                        int a = (tiles[j, l] as Picture).Value;
                                        int b = (tiles[j + 1, l] as Picture).Value;
                                        if (a == b)
                                        {
                                            ifPicWasMoved = true;
                                            score += tiles.Merge(j + 1, l, j, l, this.Controls);
                                            label1.Text = "Score: " + score;
                                        }
                                    }
                                }
                            }
                        }
                    }
                    break;
            }
            if (ifPicWasMoved)
                tiles.AddComputerGeneratedPicture(this.Controls);
        }
    }
}
    
