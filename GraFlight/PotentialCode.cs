using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

//TEN PLIK MA GŁÓWNIE POMYSŁY, NIEKONIECZNIE DZIAŁAJĄCE
namespace GraFlight
{
    public class Program
    {
        int score = 0;
        public static char[] playerLine = new char[] { '_', '_', '_', '_', 'A', '_', '_', '_', '_' };

        /*public static char[] MovePlayer(System.Windows.Forms.Keys KeyUsed)
        {
			//check the movement and move accordingly
            return new char[] { };
        }*/
        	
		//Dodaj, że jeśli gracz ma pierwszy ruch, to nie powinno być więcej niż 2 przeszkody na środkowych polach
		public static char[] GenerateLine()
		{
		 	char[] Line = new char[] { '_', '_', '_', '_', '_', '_', '_', '_', '_' };
			int a, b, c;
			a = RandomIndex();
			do{
				b = RandomIndex();
				c = RandomIndex();
			}
			while(a==b||b==c||a==c);
			
			Line[a] = 'U';
			Line[b] = 'U';
			Line[c] = 'U';
			return Line;
		}
		
		public static void DisplayLine(char[] Line)
		{
			string LineString = String.Empty;
			foreach(char el in Line)
			{
				LineString += el+' ';
			}
			Console.WriteLine(LineString);
		}
		
		public static void DisplayNumberOfLines(int q)
		{
			for(int i=0; i<q; i++)
			{
				DisplayLine(GenerateLine());
			}
		}
		
		public static int RandomIndex(){
			Random random = new Random(DateTime.Now.Millisecond);
			int ranIndex = random.Next(0, 9);
			return ranIndex;
		}

        public static void Main(string[] args)
		{
			DisplayNumberOfLines(10);
			DisplayLine(playerLine);
		}
    }
}
