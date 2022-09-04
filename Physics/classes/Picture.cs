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
public abstract class Picture : Tile
{
  public Label Label {get; private set;}
  public abstract int Value {get;}
  protected virtual Color BackColor
  {
    get
    {
      return Color.Green;
    }
  }

  public Picture(int row, int column) : base(row, column)
  {
            Label = new Label();
            Label.Text = Value.ToString();
            Label.Size = new Size(50, 50);
            Label.TextAlign = ContentAlignment.MiddleCenter;
            Label.Font = new Font(new FontFamily("Microsoft Sans Serif"), 15);

    PictureBox.Controls.Add(Label);
  }
)
}
}