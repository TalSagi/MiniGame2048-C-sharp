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
    public class ComputerGeneratedPicture : Picture
    {
        public override int Value
        {
            get
            {
                return 2;
            }
        }
  protected override Color BackColor
  {
    get
    {
        return Color.Yellow;
    }
    }

    public ComputerGeneratedPicture(int row, int column) : base(row, column) {}
}