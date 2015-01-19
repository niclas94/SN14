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
			while (true)
			{
				try
				{
					var count = ReadInt("Ange antal löner att mata in: ");
					Console.WriteLine();
					if(count < 2)
					{
						Console.BackgroundColor = ConsoleColor.Red;
						Console.WriteLine("Du måste mata in minst två löner för att kunna göra en beräkning!");
						Console.ResetColor();	
					}
					else
					{
						ProcessSalaries(count);
					}
				}
				catch{}
				Console.WriteLine();
				Console.BackgroundColor = ConsoleColor.DarkGreen;
				Console.WriteLine("\nTryck tangent för en ny beräkning - ESC avslutar.");
				Console.ResetColor();
				
				if (Console.ReadKey(true).Key == ConsoleKey.Escape)
				{
					System.Environment.Exit(0);
				}
			}
		}
			static void ProcessSalaries(int count)
			{
				int[] antal = new int[count];
				int[] osorteradeLoner = new int[count];
				var lonespridning = 0;
				var maxLon = 0;
				var minLon = 0;
				var medellon = 0;
				var medianlon = 0;

			for (int i = 0; i < antal.Length; i++) 
			{
				antal[i] = ReadInt(string.Format("Ange lön nummer {0}: ", i + 1));
				osorteradeLoner[i] = antal[i];
			}

			maxLon = antal.Max();
			minLon = antal.Min();
			lonespridning = maxLon - minLon;
			medellon = (int)antal.Average();
			Array.Sort(antal);
			int medianlonen = count / 2;

			if (count % 2 == 0)      // jämt antal                                                        
			{
				medianlon = (antal[medianlonen - 1] + antal[medianlonen]) / 2;             
			}                                                                               
			else
			{
				medianlon = antal[medianlonen];
			}

				Console.WriteLine("\n-------------------------------"   );
				Console.WriteLine("Medianlön:     {0:c0}", medianlon    );
				Console.WriteLine("Medellön:      {0:c0}", medellon     );
				Console.WriteLine("Lönespridning: {0:c0}", lonespridning);
				Console.WriteLine("-------------------------------"     );

				for (int i = 0; i <= count; i++)
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
						var count = int.Parse(input);
						return count;
					}
					catch (Exception)
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