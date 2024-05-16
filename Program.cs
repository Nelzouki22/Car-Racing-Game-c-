using System;
using System.Threading;

namespace CarRacingGame
{
    class Program
    {
        static int playerPosition = 20; // Initial position of the player's car
        static int opponentPosition = 20; // Initial position of the opponent's car

        static void Main(string[] args)
        {
            Console.WriteLine("Welcome to the Car Racing Game!");

            while (true)
            {
                Console.Clear();
                DrawTrack();
                DrawCars();
                MoveOpponent();
                MovePlayer();

                // Check for collision
                if (playerPosition == opponentPosition)
                {
                    Console.WriteLine("Game Over! You crashed into the opponent's car.");
                    break;
                }

                Thread.Sleep(100);
            }
        }

        static void DrawTrack()
        {
            Console.WriteLine("|-------------------------------------------------|");
        }

        static void DrawCars()
        {
            Console.SetCursorPosition(playerPosition, 1);
            Console.Write("X");

            Console.SetCursorPosition(opponentPosition, 2);
            Console.Write("O");
        }

        static void MoveOpponent()
        {
            // Randomly move the opponent's car left or right
            Random rand = new Random();
            int move = rand.Next(-1, 2);
            opponentPosition += move;

            // Ensure the opponent's car stays within the track boundaries
            if (opponentPosition < 0)
                opponentPosition = 0;
            else if (opponentPosition > 39)
                opponentPosition = 39;
        }

        static void MovePlayer()
        {
            // Read player input to move the car left or right
            if (Console.KeyAvailable)
            {
                ConsoleKeyInfo key = Console.ReadKey(true);
                if (key.Key == ConsoleKey.LeftArrow)
                {
                    playerPosition--;
                    if (playerPosition < 0)
                        playerPosition = 0;
                }
                else if (key.Key == ConsoleKey.RightArrow)
                {
                    playerPosition++;
                    if (playerPosition > 39)
                        playerPosition = 39;
                }
            }
        }
    }
}

