using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;

namespace Minesweeper
{
    class Map
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
            SetAdjBombVals();
        }

        public Map(String filename)
        {
            squares = Generate(filename);
            SetAdjBombVals();
        }

        public void SetAdjBombVals()
        {
            for (int x = 0; x < width; x++)
            {
                for (int y = 0; y < height; y++)
                {
                    int adj = 0;
                    Coordinate c1 = new Coordinate(x + 1, y);
                    Coordinate c2 = new Coordinate(x, y + 1);
                    Coordinate c3 = new Coordinate(x - 1, y);
                    Coordinate c4 = new Coordinate(x, y - 1);
                    Coordinate c5 = new Coordinate(x + 1, y + 1);
                    Coordinate c6 = new Coordinate(x - 1, y + 1);
                    Coordinate c7 = new Coordinate(x + 1, y - 1);
                    Coordinate c8 = new Coordinate(x - 1, y - 1);
                    if (squares.ContainsKey(c1))
                    {
                        adj += squares[c1].isBomb;
                    }
                    if (squares.ContainsKey(c2))
                    {
                        adj += squares[c2].isBomb;
                    }
                    if (squares.ContainsKey(c3))
                    {
                        adj += squares[c3].isBomb;
                    }
                    if (squares.ContainsKey(c4))
                    {
                        adj += squares[c4].isBomb;
                    }
                    if (squares.ContainsKey(c5))
                    {
                        adj += squares[c5].isBomb;
                    }
                    if (squares.ContainsKey(c6))
                    {
                        adj += squares[c6].isBomb;
                    }
                    if (squares.ContainsKey(c7))
                    {
                        adj += squares[c7].isBomb;
                    }
                    if (squares.ContainsKey(c8))
                    {
                        adj += squares[c8].isBomb;
                    }

                    squares[new Coordinate(x, y)].numAdjBombs = adj;

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
                    squares.Add(c, new Square(c, 0));
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
                if (s.isBomb == 0)
                {
                    s.isBomb = 1;
                    k++;
                }
            }
            return squares;
        }

        private Dictionary<Coordinate, Square> Generate(String filename)
        {
            Dictionary<Coordinate, Square> squares = new Dictionary<Coordinate, Square>();
            StreamReader file = new StreamReader(filename + ".map");
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
                        squares.Add(c, new Square(c, 1));
                        numBombs++;
                    }
                    else
                    {
                        squares.Add(c, new Square(c, 0));
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
                    if (squares[c].isBomb == 1)
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
    }
}
