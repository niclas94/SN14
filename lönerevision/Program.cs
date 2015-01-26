using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lönerevision
{
	class Program
	{
		static void Main(string[] args)
		{

			do
			{
				Console.Clear();

				int count = ReadInt("Ange antal löner att mata in: ");
				Console.WriteLine();
				if (count < 2)
				{
					Console.BackgroundColor = ConsoleColor.Red;
					Console.WriteLine("Du måste mata in minst två löner för att kunna göra en beräkning!");
					Console.ResetColor();
				}
				else
				{
					ProcessSalaries(count);
				}

				Console.WriteLine();
				Console.BackgroundColor = ConsoleColor.DarkGreen;
				Console.WriteLine("\nTryck tangent för en ny beräkning - ESC avslutar.");
				Console.ResetColor();

			}
			while (Console.ReadKey(true).Key != ConsoleKey.Escape);
		}

		static void ProcessSalaries(int count)
		{
			int[] loner = new int[count];
			int[] osorteradeLoner = new int[count];
			int lonespridning = 0;
			int maxLon = 0;
			int minLon = 0;
			int medellon = 0;
			int medianlon = 0;

			for (int i = 0; i < loner.Length; i++)
			{
				loner[i] = ReadInt(string.Format("Ange lön nummer {0}: ", i + 1));
			}

			maxLon = loner.Max();
			minLon = loner.Min();
			lonespridning = maxLon - minLon;
			medellon = (int)loner.Average();
			Array.Copy(loner, osorteradeLoner, count);
			Array.Sort(loner);

			if (count % 2 == 0)      // jämt antal                                                        
			{
				medianlon = (loner[(count / 2) - 1] + loner[(count / 2)]) / 2;
			}
			else
			{
				medianlon = loner[(count / 2)];
			}

			Console.WriteLine("\n-------------------------------");
			Console.WriteLine("Medianlön:     {0:c0}", medianlon);
			Console.WriteLine("Medellön:      {0:c0}", medellon);
			Console.WriteLine("Lönespridning: {0:c0}", lonespridning);
			Console.WriteLine("-------------------------------");

			for (int i = 0; i < count; i++)
			{
				Console.Write("{0,8}", osorteradeLoner[i]);

				if (i % 3 == 2)
				{
					Console.WriteLine();
				}
			}
		}
		static int ReadInt(string prompt)
		{
			while (true)
			{
				Console.Write(prompt);
				string input = Console.ReadLine();
				try
				{
					int count = int.Parse(input);
					return count;
				}

				catch
				{
					Console.BackgroundColor = ConsoleColor.Red;
					Console.WriteLine("FEL! '{0}' kan inte tolkas som ett heltal!", input);
					Console.WriteLine();
					Console.ResetColor();
				}
			}
		}
	}
}