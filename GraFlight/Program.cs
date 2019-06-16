using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace GraFlight
{
    class Program
    {
        int score = 0;
        public static char[] playerLine = new char[] { ' ', ' ', ' ', ' ', 'O', ' ', ' ', ' ', ' ' };

        public static char[] MovePlayer(System.Windows.Forms.Keys KeyUsed)
        {
            return new char[] { };
        }

        public static string DisplayLine(char[] Line)
        {
            string LineString = String.Empty;
            foreach(char el in Line)
            {
                LineString += el;
            }
            return LineString;
        }

        static void Main(string[] args)
        {
            Console.WriteLine(DisplayLine(playerLine));
        }
    }
}
