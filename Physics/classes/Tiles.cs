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

    public Tiles(ControlCollection controls)
    {
        _tiles = new Tile[4, 4];
        CreateEmptyTiles(controls);
        CreatePics(controls);
        GenerateNewPic(controls);
    }

    private void CreateEmptyTiles(ControlCollection controls)
    {
        for(int i = 0; i < 4; i++)
            {
                for(int j = 0; j < 4; j++)
                {
                    _tiles[i, j] = new EmptyTile(i, j);
                    controls.Add(_tiles[i, j].PictureBox);
                }
            }
    }

    private void CreatePics(ControlCollection controls)
        {
            _tiles[0, 0] = new ComputerGeneratedPicture(0, 0);
            controls.Add(_tiles[0, 0].PictureBox);
            _tiles[0, 0].BringToFront();
            _tiles[0, 1] = new ComputerGeneratedPicture(0, 1);
            controls.Add(_tiles[0, 1].PictureBox);
            _tiles[0, 1].BringToFront();
        }

                private void GenerateNewPic(ControlCollection controls)
        {
            Random rnd = new Random();
            int a = rnd.Next(0, 4);
            int b = rnd.Next(0, 4);
            while (!IsEmptyTile(a, b))
            {
                a = rnd.Next(0, 4);
                b = rnd.Next(0, 4);
            }
            _tiles[a, b] = new ComputerGeneratedPicture(a, b);
            controls.Add(_tiles[a, b]);
            _tiles[a, b].BringToFront();
        }

        private bool IsEmptyTile(int row, int column)
        {
            return _tiles[row, column] is EmptyTile;
        }

        public int OnKeyboardPressed(string direction, int score, ControlCollection controls)
        {
            bool ifPicWasMoved = false;

            switch (direction)
            {
                case "Right":
                    for(int k = 0; k < 4; k++)
                    {
                        for(int l = 2; l >= 0; l--)
                        {
                            if(!IsEmptyTile(k, l))
                            {
                                for(int j = l + 1; j < 4; j++)
                                {
                                    if(IsEmptyTile(k, j))
                                    {
                                        ifPicWasMoved = true;
                                        _tiles[k, j - 1].Move(k, j);
                                        _tiles[k, j] = _tiles[k, j - 1];
                                        _tiles[k, j - 1] = new EmptyTile();
                                    }else
                                    {
                                        int a = (_tiles[k, j] as Picture).Value;
                                        int b = (_tiles[k, j-1] as Picture).Value;
                                        if (a == b)
                                        {
                                            ifPicWasMoved = true;
                                            score += (a + b);
                                            controls.Remove(_tiles[k, j].PictureBox);
                                            controls.Remove((_tiles[k, j] as Picture).Label);
                                            _tiles[k, j] = new UserGeneratedPicture(a + b, k, j);
                                            controls.Add(_tiles[k, j].PictureBox);
                                            _tiles[k, j].BringToFront();
                                            controls.Remove(_tiles[k, j - 1].PictureBox);
                                            controls.Remove((_tiles[k, j - 1] as Picture).Label);
                                            _tiles[k, j - 1] = new EmptyTile();
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
                            if (!IsEmptyTile(k, l))
                            {
                                for (int j = l - 1; j >= 0; j--)
                                {
                                    if (IsEmptyTile(k, j))
                                    {
                                        ifPicWasMoved = true;
                                        _tiles[k, j + 1].Move(k, j);
                                        _tiles[k, j] = _tiles[k, j  + 1];
                                        _tiles[k, j + 1] = new EmptyTile();
                                    }
                                    else
                                    {
                                        int a = (_tiles[k, j] as Picture).Value;
                                        int b = (_tiles[k, j+1] as Picture).Value;
                                        if (a == b)
                                        {
                                            ifPicWasMoved = true;
                                            score += (a + b);
                                            controls.Remove(_tiles[k, j].PictureBox);
                                            controls.Remove((_tiles[k, j] as Picture).Label);
                                            _tiles[k, j] = new UserGeneratedPicture(a + b, k, j);
                                            controls.Add(_tiles[k, j].PictureBox);
                                            _tiles[k, j].BringToFront();
                                            controls.Remove(_tiles[k, j + 1].PictureBox);
                                            controls.Remove((_tiles[k, j + 1] as Picture).Label);
                                            _tiles[k, j + 1] = new EmptyTile();
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
                        for (int l = 0; l <4; l++)
                        {
                            if (!IsEmptyTile(k, l))
                            {
                                for (int j = k + 1; j < 4; j++)
                                {
                                    if (IsEmptyTile(j, l))
                                    {
                                        ifPicWasMoved = true;
                                        _tiles[j - 1, l].Move(j, l);
                                        _tiles[j, l] = _tiles[j-1, l];
                                        _tiles[j - 1, l] = new EmptyTile();
                                    }
                                    else
                                    {
                                        int a = (_tiles[j, l] as Picture).Value;
                                        int b = (_tiles[j-1, l] as Picture).Value;
                                        if (a == b)
                                        {
                                            ifPicWasMoved = true;
                                            score += (a + b);
                                            controls.Remove(_tiles[j, l].PictureBox);
                                            controls.Remove((_tiles[j, l] as Picture).Label);
                                            _tiles[j, l] = new UserGeneratedPicture(a + b, j, l);
                                            controls.Add(_tiles[j, l].PictureBox);
                                            _tiles[j , l].BringToFront();
                                            controls.Remove(_tiles[j - 1, l].PictureBox);
                                            controls.Remove((_tiles[j-1, l] as Picture).Label);
                                            _tiles[j-1, l] = new EmptyTile();
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
                            if (!IsEmptyTile(k, l))
                            {
                                for (int j = k - 1; j >=0; j--)
                                {
                                    if (IsEmptyTile(j, l))
                                    {
                                        ifPicWasMoved = true;
                                        _tiles[j + 1, l].Move(j, l);
                                        _tiles[j, l] = _tiles[j+1, l];
                                        _tiles[j + 1, l] = new EmptyTile();
                                    }
                                    else
                                    {
                                        int a = (_tiles[j, l] as Picture).Value;
                                        int b = (_tiles[j+1, l] as Picture).Value;
                                        if (a == b)
                                        {
                                            ifPicWasMoved = true;
                                            score += (a + b);
                                            controls.Remove(_tiles[j, l].PictureBox);
                                            controls.Remove((_tiles[j, l] as Picture).Label);
                                            _tiles[j, l] = new UserGeneratedPicture(a + b, j, l);
                                            controls.Add(_tiles[j, l].PictureBox);
                                            _tiles[j , l].BringToFront();
                                            controls.Remove(_tiles[j + 1, l].PictureBox);
                                            controls.Remove((_tiles[j+1, l] as Picture).Label);
                                            _tiles[j+1, l] = new EmptyTile();
                                        }
                                    }
                                }
                            }
                        }
                    }
                    break;
            }
            if (ifPicWasMoved)
                GenerateNewPic(controls);
            
            return score;
        }

}
}