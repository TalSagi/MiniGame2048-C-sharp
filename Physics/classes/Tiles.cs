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
public class Tiles
{
    private Tile[,] _tiles;

    public Tile this[int row, int column]
    {
        get
        {
            return _tiles[row, column];
        }
        private set
        {
            _tiles[row, column] = value;
        }
    }

    public Tiles(Control.ControlCollection controls)
    {
        _tiles = new Tile[4, 4];
        CreateEmptyTiles(controls);
        CreatePics(controls);
        AddComputerGeneratedPicture(controls);
    }

        public void Remove(int row, int column, Control.ControlCollection controls)
    {
            Picture picture = this[row, column] as Picture;
        if (picture != null)
        {
            controls.Remove(picture.PictureBox);
            controls.Remove(picture.Label);
        }
    }

    public void TurnEmpty(int row, int column, Control.ControlCollection controls)
    {
        Remove(row, column, controls);

        this[row, column] = new EmptyTile(row, column);
    }

        public void AddComputerGeneratedPicture(Control.ControlCollection controls)
        {
            Random rnd = new Random();
            int a = rnd.Next(0, 4);
            int b = rnd.Next(0, 4);
            while (!IsEmptyTile(a, b))
            {
                a = rnd.Next(0, 4);
                b = rnd.Next(0, 4);
            }
            AddComputerGeneratedPicture(a,b, controls);
        }

    public void AddComputerGeneratedPicture(int row, int column, Control.ControlCollection controls)
    {
        this[row, column] = new ComputerGeneratedPicture(row, column);
        controls.Add(this[row, column].PictureBox);
        this[row, column].BringToFront();
    }

    public void Move(int rowA, int columnA, int rowB, int columnB)
    {
        this[rowB, columnB] = this[rowA, columnA];
        this[rowB, columnB].Reposition(rowA, columnA);
        this[rowA, columnA] = new EmptyTile(rowA, columnA);
    }

    public int Merge(int rowA, int columnA, int rowB, int columnB, Control.ControlCollection controls)
    {
        int valueA = (this[rowA, columnA] as Picture).Value;
        int valueB = (this[rowB, columnB] as Picture).Value;

            TurnEmpty(rowA, columnA, controls);
        Remove(rowB, columnB, controls);
        this[rowB, columnB] = new UserGeneratedPicture(valueA + valueB, rowB, columnB);
        controls.Add(this[rowB, columnB].PictureBox);
        this[rowB, columnB].BringToFront();

        return valueA + valueB;
    }

    public void CreateEmptyTiles(Control.ControlCollection controls)
    {
        for(int i = 0; i < 4; i++)
            {
                for(int j = 0; j < 4; j++)
                {
                    this[i, j] = new EmptyTile(i, j);
                    controls.Add(this[i, j].PictureBox);
                }
            }
    }

    private void CreatePics(Control.ControlCollection controls)
        {
            AddComputerGeneratedPicture(0, 0, controls);
            AddComputerGeneratedPicture(0, 1, controls);
        }

        public bool IsEmptyTile(int row, int column)
        {
            return this[row, column] is EmptyTile;
        }

}
}