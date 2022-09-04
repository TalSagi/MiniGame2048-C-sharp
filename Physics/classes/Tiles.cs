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

    public Tiles(ControlCollection controls)
    {
        _tiles = new Tile[4, 4];
        CreateEmptyTiles(controls);
        CreatePics(controls);
        GenerateNewPic(controls);
    }

        public void Remove(int row, int column, ControlCollection controls)
    {
        if (this[row, column] is Picture picture)
        {
            controls.Remove(picture.PictureBox);
            controls.Remove(picture.Label);
        }
    }

    public void TurnEmpty(int row, int column, ControlCollection controls)
    {
        Remove(row, column, controls);

        this[row, column] = new EmptyTile(row, column);
    }

        public void AddComputerGeneratedPicture(ControlCollection controls)
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

    public void AddComputerGeneratedPicture(int row, int column, ControlCollection controls)
    {
        this[row, column] = new ComputerGeneratedPicture(row, column);
        controls.Add(this[row, column].PictureBox);
        this[row, column].BringToFront();
    }

    public void Move(int rowA, int columnA, int rowB, int columnB)
    {
        this[rowA, columnA].Reposition(rowB, columnB);
        this[rowB, columnB] = this[rowA, columnA];
        this[k, j - 1] = new EmptyTile();
    }

    public int Merge(int rowA, int columnA, int rowB, int columnB, ControlCollection controls)
    {
        int valueA = (this[rowA, columnA] as Picture).Value;
        int valueB = (this[rowB, valueB] as Picture).Value;

        Remove(rowB, columnB, controls);
        this[rowB, columnB] = new UserGeneratedPicture(valueA + valueB, rowB, columnB);
        controls.Add(this[rowB, columnB].PictureBox);
        this[rowB, columnB].BringToFront();

        return valueA + valueB;
    }

    private void CreateEmptyTiles(ControlCollection controls)
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

    private void CreatePics(ControlCollection controls)
        {
            AddComputerGeneratedPicture(0, 0);
            AddComputerGeneratedPicture(0, 1);
        }

        private bool IsEmptyTile(int row, int column)
        {
            return this[row, column] is EmptyTile;
        }

}
}