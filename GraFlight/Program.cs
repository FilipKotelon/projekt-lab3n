using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace GraFlight
{
    public class Program
    {
        public static char[] playerLine = new char[] { '_', '_', '_', '_', 'A', '_', '_', '_', '_' };


        /// <summary>
        /// Funkcja, która wykonuje akcję poleconą przez użytkownika
        /// </summary>
        /// <param name="KeyUsed">Klawisz wciśnięty przez użytkownika</param>
        /// <param name="PlayerLine">Array z linią, w której znajduje się użytkownik</param>
        /// <param name="NextLine">Array z linią znajdującą się przed użytkownikiem</param>
        /// <returns>Array z linią, w której znajduje się użytkownik</returns>
        public static char[] MovePlayer(ConsoleKeyInfo KeyUsed, char[] PlayerLine, char[] NextLine)
        {
            int index = Array.FindIndex(PlayerLine, row => row == 'A');
            int newIndex = index;
            if(KeyUsed.Key == ConsoleKey.RightArrow && index < PlayerLine.Length - 1)
            {
                newIndex += 1;
            }
            else if (KeyUsed.Key == ConsoleKey.LeftArrow && index > 0)
            {
                newIndex -= 1;
            }

            if(NextLine[newIndex] != 'O')
            {
                NextLine[newIndex] = 'A';
            }
            else
            {
                return new char[] { 'X' };
            }

            return NextLine;
        }

        public static char[][] MoveLines(char[][] Lines)
        {
            for (int i = Lines.Length-1; i >= 0; i--)
            {
                if(i > 0)
                {
                    Lines[i] = Lines[i - 1];
                }
                else
                {
                    Lines[i] = GenerateLine();
                }
            }
            return Lines;
        }

        //Dodaj, że jeśli gracz ma pierwszy ruch, to nie powinno być więcej niż 2 przeszkody na środkowych polach
        public static char[] GenerateLine()
        {
            char[] Line = new char[] { '_', '_', '_', '_', '_', '_', '_', '_', '_' };
            int a, b, c;
            a = RandomIndex();
            do
            {
                b = RandomIndex();
                c = RandomIndex();
            }
            while (a == b || b == c || a == c);

            Line[a] = 'O';
            Line[b] = 'O';
            Line[c] = 'O';
            return Line;
        }

        public static void ShowScore(int score, int highScore)
        {
            Console.WriteLine("Wynik: " + score + " Najlepszy wynik: " + highScore);
        }

        public static void DisplayLine(char[] Line)
        {
            string LineString = String.Empty;
            for(int i = 0; i < Line.Length; i++)
            {
                if(Line[i] == 'A')
                {
                    ColoredWrite(ConsoleColor.Green, Line[i]);
                }
                else if(Line[i] == 'O')
                {
                    ColoredWrite(ConsoleColor.Red, Line[i]);
                }
                else if(Line[i] == '_')
                {
                    ColoredWrite(ConsoleColor.White, Line[i]);
                }
                if(i < Line.Length  - 1) Console.Write(' ');
            }
            Console.WriteLine();
        }

        public static void DisplayLines(char[][] Lines)
        {
            for (int i = 0; i < Lines.Length; i++)
            {
                DisplayLine(Lines[i]);
            }
        }

        public static char[][] GetNumberOfLines(int q)
        {
            char[][] Lines = new char[q][];
            for (int i = 0; i < q; i++)
            {
                Lines[i] = GenerateLine();
            }
            return Lines;
        }

        public static int RandomIndex()
        {
            Random random = new Random(DateTime.Now.Millisecond);
            int ranIndex = random.Next(0, 9);
            return ranIndex;
        }

        public static void ColoredWrite(ConsoleColor color, char character)
        {
            Console.ForegroundColor = color;
            Console.Write(character);
            Console.ResetColor();
        }
        

        public static void Game(int highScore)
        {
            Console.Clear();
            int score = 0;
            ShowScore(score, highScore);
            string gameStatus = "playing";
            char[][] CurrentLines = GetNumberOfLines(10);
            ConsoleKeyInfo keyUsed;
            while (gameStatus == "playing")
            {
                if (score != 0)
                {
                    CurrentLines = MoveLines(CurrentLines);
                }

                DisplayLines(CurrentLines);
                DisplayLine(playerLine);
                keyUsed = Console.ReadKey();
                if(keyUsed.Key == ConsoleKey.X || keyUsed.Key == ConsoleKey.Escape)
                {
                    Console.Clear();
                    break;
                }
                playerLine = (MovePlayer(keyUsed, playerLine, CurrentLines[CurrentLines.Length - 1]));
                Console.Clear();

                if(playerLine[0] == 'X')
                {
                    gameStatus = "lost";
                }
                else
                {
                    score++;
                    if (score > highScore) highScore = score;
                    ShowScore(score, highScore);
                }
            }
            Console.WriteLine("Koniec gry!");
            Console.WriteLine("Twój wynik: " + score);
            Console.WriteLine("Czy chcesz zagrać jeszcze raz? (t/n)");
            ConsoleKeyInfo exitOrPlay = Console.ReadKey();
            if(exitOrPlay.Key == ConsoleKey.T)
            {
                playerLine = new char[] { '_', '_', '_', '_', 'A', '_', '_', '_', '_' };
                Game(highScore);
            }
            else
            {
                Console.WriteLine();
                return;
            }

        }

        public static void Main(string[] args)
        {
            Game(0);
        }
    }
}
