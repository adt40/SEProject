using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;

namespace Minesweeper
{
    public class Map
    {
        public int width { get; set; }
        public int height { get; set; }
        public int numBombs { get; set; }
        public Dictionary<Coordinate, Square> squares { get; private set; }

        public Map(int width, int height, int numBombs)
        {
            this.width = width;
            this.height = height;
            this.numBombs = numBombs;
            squares = Generate(width, height, numBombs);
        }

        public Map(String filename)
        {
            squares = Generate(filename);
        }

        public void SetAdjBombVals()
        {
            for (int x = 0; x < width; x++)
            {
                for (int y = 0; y < height; y++)
                {
                    Coordinate c = new Coordinate(x, y);
                    if (!squares[c].isBomb)
                    {
                        int bombAdjNum = 0;
                        for (int i = -1; i <= 1; i++)
                        {
                            for (int j = -1; j <= 1; j++)
                            {
                                if (j == 0 && i == 0) continue; //Don't need to check this square
                                Coordinate checkC = new Coordinate(x + i, y + j);
                                if (squares.ContainsKey(checkC))
                                {
                                    Square checkSquare = squares[checkC];
                                    if (checkSquare.isBomb)
                                        bombAdjNum++;
                                }
                            }
                        }
                        squares[new Coordinate(x, y)].numAdjBombs = bombAdjNum;
                    }
                }
            }
        }



        private Dictionary<Coordinate, Square> Generate(int width, int height, int numBombs)
        {
            Dictionary<Coordinate, Square> squares = new Dictionary<Coordinate, Square>();
            for (int i = 0; i < width; i++)
            {
                for (int j = 0; j < height; j++)
                {
                    Coordinate c = new Coordinate(i, j);
                    squares.Add(c, new Square(c, false));
                }
            }
            int k = 0;
            Random rng = new Random();
            while (k < numBombs)
            {
                int x = rng.Next(width);
                int y = rng.Next(height);
                Coordinate c = new Coordinate(x, y);

                Square s = squares[c];
                if (!s.isBomb)
                {
                    s.isBomb = true;
                    k++;
                }
            }
            return squares;
        }

        private Dictionary<Coordinate, Square> Generate(String filename)
        {
            Dictionary<Coordinate, Square> squares = new Dictionary<Coordinate, Square>();
            StreamReader file = new StreamReader(filename);
            width = int.Parse(file.ReadLine());
            height = int.Parse(file.ReadLine());

            String line = "";

            for (int y = 0; y < height; y++)
            {
                line = file.ReadLine();
                for (int x = 0; x < width; x++)
                {
                    Coordinate c = new Coordinate(x, y);
                    if (line.ElementAt(x) == 'X')
                    {
                        squares.Add(c, new Square(c, true));
                        numBombs++;
                    }
                    else
                    {
                        squares.Add(c, new Square(c, false));
                    }
                }
            }
            file.Close();
            return squares;
        }

        public void CreateMapFile(String filename)
        {
            StreamWriter file = new StreamWriter(filename + ".map");

            file.WriteLine(width);
            file.WriteLine(height);
            file.Flush();

            for (int y = 0; y < height; y++)
            {
                String line = "";
                for (int x = 0; x < width; x++)
                {
                    Coordinate c = new Coordinate(x, y);
                    if (squares[c].isBomb)
                    {
                        line += 'X';
                    }
                    else
                    {
                        line += 'O';
                    }
                }
                file.WriteLine(line);
                file.Flush();
            }

            file.Close();
        }

        public String viewBombsAndNums()
        {
            String result = "";
            for (int i = 0; i < width; i++)
            {
                for (int j = 0; j < height; j++)
                {
                    Coordinate toTest = new Coordinate(i, j);
                    if (squares[toTest].isBomb) result += "B";
                    else result += squares[toTest].numAdjBombs;
                }
                result += "\n";
            }
            return result;
        }

        public int testNumBombs()
        {
            int result = 0;
            for (int i = 0; i < width; i++)
            {
                for (int j = 0; j < height; j++)
                {
                    Coordinate toTest = new Coordinate(i, j);
                    if (squares[toTest].isBomb) result++;
                }
            }
            return result;
        }
    }
}
