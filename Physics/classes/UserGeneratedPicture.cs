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

        public UserGeneratedPicture(int value, int row, int column) : base(value, row, column, GetBackColor(value))
        {
        }

        private static Color? GetBackColor(int value)
        {
            if (value % 1024 == 0) return Color.Pink;
            if (value % 512 == 0) return Color.Red;
            if (value % 256 == 0) return Color.DarkViolet;
            if (value % 128 == 0) return Color.Blue;
            if (value % 64 == 0) return Color.Brown;
            if (value % 32 == 0) return Color.Coral;
            if (value % 16 == 0) return Color.Cyan;
            if (value % 8 == 0) return Color.Maroon;
            return default(Color?);

        }
    }
}