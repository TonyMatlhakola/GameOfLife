using GameOfLife.Uitls;
using System;
using System.Collections.Generic;
using System.Text;

namespace GameOfLife
{
    public class GameOfLifeService : IGameOfLifeService
    {
        private int Heigth;
        private int Width;
        private bool[,] cells;

        // Initializes a new Game of Life.          
        public GameOfLifeService()
        {
            //Get app settings
            var _appSettings = ConfigurationSettings.GetConfiurationSettings();
            this.Heigth = _appSettings.Heigth;
            this.Width = _appSettings.Width;
            cells = new bool[_appSettings.Heigth, _appSettings.Width];
            GenerateField();
        } 
            //  Advances the game by one generation and prints the current state to console.
   
            public void DrawAndGrow()
            {
                DrawGame();
                Grow();
            }


            // Advances the game by one generation according to GoL's ruleset.
   

            private void Grow()
            {
                for (int i = 0; i < Heigth; i++)
                {
                    for (int j = 0; j < Width; j++)
                    {
                        int numOfAliveNeighbors = GetNeighbors(i, j);

                        if (cells[i, j])
                        {
                            if (numOfAliveNeighbors < 2)
                            {
                                cells[i, j] = false;
                            }

                            if (numOfAliveNeighbors > 3)
                            {
                                cells[i, j] = false;
                            }
                        }
                        else
                        {
                            if (numOfAliveNeighbors == 3)
                            {
                                cells[i, j] = true;
                            }
                        }
                    }
                }
            }

    
            // Checks how many alive neighbors are in the vicinity of a cell.
        

            private int GetNeighbors(int x, int y)
            {
                int NumOfAliveNeighbors = 0;

                for (int i = x - 1; i < x + 2; i++)
                {
                    for (int j = y - 1; j < y + 2; j++)
                    {
                        if (!((i < 0 || j < 0) || (i >= Heigth || j >= Width)))
                        {
                            if (cells[i, j] == true) NumOfAliveNeighbors++;
                        }
                    }
                }
                return NumOfAliveNeighbors;
            }

        
            // Draws the game to the console.
           

            private void DrawGame()
            {
                for (int i = 0; i < Heigth; i++)
                {
                    for (int j = 0; j < Width; j++)
                    {
                        Console.Write(cells[i, j] ? "*" : " ");
                        if (j == Width - 1) Console.WriteLine("\r");
                    }
                }
                Console.SetCursorPosition(0, Console.WindowTop);
            }

          
            // Initializes the field with random boolean values.
          

            private void GenerateField()
            {
                Random generator = new Random();
                int number;
                for (int i = 0; i < Heigth; i++)
                {
                    for (int j = 0; j < Width; j++)
                    {
                        number = generator.Next(2);
                        cells[i, j] = ((number == 0) ? false : true);
                    }
                }
            }
        }
    
}
