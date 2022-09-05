using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Physics
{
    public abstract class Tile
    {


        public PictureBox PictureBox { get; private set; }

  public Tile(int row, int column, Color backColor)
  {
    PictureBox = new PictureBox();
    PictureBox.Location = new Point(12 + 56 * column, 73 + 56 * row);
    PictureBox.Size = new Size(50, 50);
    PictureBox.BackColor = backColor;
  }

  public void BringToFront()
  {
    PictureBox.BringToFront();
  }

  public void Reposition(int row, int column)
  {
    PictureBox.Location = new Point(12 + 56 * column, 73 + 56 * row);
  }
    }
}