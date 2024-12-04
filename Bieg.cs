using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Gra_konsolowa_kopalnia
{
    internal class Bieg
    {

        public void uruchomBieg()
        {

            Console.Clear();
            //Console.OutputEncoding = Encoding.UTF8;
            Console.OutputEncoding = System.Text.Encoding.UTF8;
            int width = 100;
            int height = 30;
            int speed = 30; //the lower number, the faster you go
            const int roadWidth = 12;

            char[,] scene;
            int score = 0;
            int carPosition;
            int carVelocity;
            bool gameRunning;
            bool keepPlaying = true;
            int previousRoadUpdate = 0;

            Console.CursorVisible = false;
            try
            {
                //LaunchScreen();
                while (keepPlaying)
                {
                    InitializeScene();
                    while (gameRunning)
                    {
                        HandleInput();
                        Update();
                        Render();
                        if (gameRunning)
                        {
                            Thread.Sleep(TimeSpan.FromMilliseconds(speed));
                        }
                    }
                    if (keepPlaying)
                    {
                        GameOverScreen();
                    }
                }
                Console.Clear();
            }
            finally
            {
                Console.CursorVisible = true;
            }

            //void LaunchScreen()
            //{
            //    Console.Clear();
            //    Console.WriteLine("This is a driving game.");
            //    Console.WriteLine();
            //    Console.WriteLine("Stay on the road!");
            //    Console.WriteLine();
            //    Console.WriteLine("Use A, W, and D to control your velocity.");
            //    Console.WriteLine();
            //    Console.Write("Press [enter] to start...");
            //    PressEnterToContinue();
            //}

            void InitializeScene()
            {
                gameRunning = true;
                carPosition = width / 2;
                carVelocity = 0;
                int leftEdge = (width - roadWidth) / 2;
                int rightEdge = leftEdge + roadWidth + 1;
                scene = new char[height, width];
                for (int i = 0; i < height; i++)
                {
                    for (int j = 0; j < width; j++)
                    {
                        if (j < leftEdge || j > rightEdge)
                        {
                            scene[i, j] = '.';
                        }
                        else
                        {
                            scene[i, j] = ' ';
                        }
                    }
                }
            }

            void Render()
            {
                StringBuilder stringBuilder = new StringBuilder(width * height); // alternative constructor
                for (int i = height - 1; i >= 0; i--)
                {
                    for (int j = 0; j < width; j++)
                    {
                        if (i is 1 && j == carPosition)
                        {
                            stringBuilder.Append(
                                !gameRunning ? 'X' :
                                carVelocity < 0 ? '<' :
                                carVelocity > 0 ? '>' :
                                '^');
                        }
                        else
                        {
                            stringBuilder.Append(scene[i, j]);
                        }
                    }
                    if (i > 0)
                    {
                        stringBuilder.AppendLine();
                    }
                }
                Console.SetCursorPosition(0, 0);
                Console.Write(stringBuilder);
            }

            void HandleInput()
            {
                while (Console.KeyAvailable)
                {
                    ConsoleKey key1 = Console.ReadKey(true).Key;
                    switch (key1)
                    {
                        case ConsoleKey.LeftArrow:
                            carVelocity = -1;
                            break;
                        case ConsoleKey.RightArrow:
                            carVelocity = +1;
                            break;
                        case ConsoleKey.UpArrow:
                            carVelocity = 0;
                            break;
                        case ConsoleKey.DownArrow:
                            carVelocity = 0;
                            break;
                        case ConsoleKey.Escape:
                            gameRunning = false;
                            keepPlaying = false;
                            break;
                        case ConsoleKey.Enter:
                            Console.ReadLine();
                            break;
                    }
                }
            }

            void GameOverScreen()
            {
                Console.SetCursorPosition(0, 0);
                Console.WriteLine("Game Over");
                Console.WriteLine($"Score: {score}");
                Console.WriteLine($"Play Again (Y/N)?");
            GetInput:
                ConsoleKey key2 = Console.ReadKey(true).Key;
                switch (key2)
                {
                    case ConsoleKey.Y:
                        keepPlaying = true;
                        break;
                    case ConsoleKey.Escape:
                        keepPlaying = false;
                        break;
                    default:
                        goto GetInput;
                }
            }

            void Update()
            {
                for (int i = 0; i < height - 1; i++)
                {
                    for (int j = 0; j < width; j++)
                    {
                        scene[i, j] = scene[i + 1, j];
                    }
                }
                Random random = new Random();
                int roadUpdate = random.Next(5) < 4 ? previousRoadUpdate : random.Next(3) - 1;

                if (roadUpdate is -1 && scene[height - 1, 0] is ' ') roadUpdate = 1;
                if (roadUpdate is 1 && scene[height - 1, width - 1] is ' ') roadUpdate = -1;
                switch (roadUpdate)
                {
                    case -1: // left
                        for (int i = 0; i < width - 1; i++)
                        {
                            scene[height - 1, i] = scene[height - 1, i + 1];
                        }
                        scene[height - 1, width - 1] = '.';
                        break;
                    case 1: // right
                        for (int i = width - 1; i > 0; i--)
                        {
                            scene[height - 1, i] = scene[height - 1, i - 1];
                        }
                        scene[height - 1, 0] = '.';
                        break;
                }
                previousRoadUpdate = roadUpdate;
                carPosition += carVelocity;
                if (carPosition < 0 || carPosition >= width || !(scene[1, carPosition] == ' '))
                {
                    gameRunning = false;
                }

                score++;
            }

            void PressEnterToContinue()
            {
            GetInput:
                ConsoleKey key3 = Console.ReadKey(true).Key;
                switch (key3)
                {
                    case ConsoleKey.Enter:
                        break;
                    case ConsoleKey.Escape:
                        keepPlaying = false;
                        break;
                    default: goto GetInput;
                }
            }

        }
    }
}
