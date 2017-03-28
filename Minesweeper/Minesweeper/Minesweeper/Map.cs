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
        }

        public Map(String filename)
        {
            squares = Generate(filename);
        }
        
        private Dictionary<Coordinate, Square> Generate(int width, int height, int numBombs)
        {
            Dictionary<Coordinate, Square> squares = new Dictionary<Coordinate, Square>();
            for (int i = 0; i < width; i++)
            {
                for (int j = 0; j < height; j++)
                {
                    Coordinate c = new Coordinate(i, j);
                    squares.Add(c, new Square(c, false, this));
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
                        squares.Add(c, new Square(c, true, this));
                        numBombs++;
                    }
                    else
                    {
                        squares.Add(c, new Square(c, false, this));
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

        public Square getSquare(Coordinate position)
        {
            if (position.x > width || position.x < 0 || position.y > height || position.y < 0)
                return null;
            return squares[position];

        }
    }
}
