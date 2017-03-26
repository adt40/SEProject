using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
            //need better implementation of this, reference old java code for bad way

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
            while (k < numBombs)
            {
                Random rng = new Random();

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

        private void CreateMapFile(String filename)
        {
            StreamWriter file = new StreamWriter(filename);

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
