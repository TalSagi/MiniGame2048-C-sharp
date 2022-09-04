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
    public class UserGeneratedPicture : Picture
    {
        private int _value;

                public override int Value
        {
            get
            {
                return _value;
            }
        }
  protected override Color BackColor
  {
    get
    {
            if (Value % 1024 == 0) return Color.Pink;
            if (Value % 512 == 0) return Color.Red;
            if (Value % 256 == 0) return Color.DarkViolet;
            if (Value % 128 == 0) return Color.Blue;
            if (Value % 64 == 0) return Color.Brown;
            if (Value % 32 == 0) return Color.Coral;
            if (Value % 16 == 0) return Color.Cyan;
            if (Value % 8 == 0) return Color.Maroon;
            return base.BackColor;
    }
  }

        public UserGeneratedPicture(int value, int row, int column) : base(row, column)
        {
            _value = value;
        }
    }
}