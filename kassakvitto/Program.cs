using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace kassakvitto
{
	class Program
	{
		static void Main(string[] args)
		{
			Console.Title = "Växel pengar - nivå A";

			double subtotal = 0d;		
			uint total = 0;
			double avrundatBelopp = 0d;
			int tillbaka = 0;
			int pengarTillbaka = 0;
			int erhalletBelopp = 0;
			
			while(true)
			{
				try
				{
					Console.Write("Ange totalsumma     :  ");
					subtotal = double.Parse(Console.ReadLine());

					if (subtotal < 0.50)
					{
						Console.BackgroundColor = ConsoleColor.Red;
						Console.WriteLine("Totalsumman är för liten. Köpet kunde inte genomföras.");
						Console.ResetColor();
						return;
					}
				}
				catch
				{
					Console.BackgroundColor = ConsoleColor.Red;
					Console.WriteLine("FEL! Erhållet belopp felaktigt.");
					Console.ResetColor();
					return;
				}
				break;
			}
			while(true)
			{
				try 
				{
					Console.Write("Ange erhållet belopp:  ");
					erhalletBelopp = int.Parse(Console.ReadLine());
					if (erhalletBelopp < subtotal)
					{
						Console.BackgroundColor = ConsoleColor.Red;
						Console.WriteLine("Erhållet belopp är för litet. Köpet kunde inte genomföras");
						Console.ResetColor();
						return;
					}
				}
				catch
				{
					Console.BackgroundColor = ConsoleColor.Red;
					Console.WriteLine("FEL! Erhållet belopp felaktigt.");
					Console.ResetColor();
					return;
				}
				break;
			}
			total = (uint)Math.Round(subtotal);
			avrundatBelopp = total - subtotal;
			tillbaka = erhalletBelopp - (int)total;

			Console.WriteLine("\nKVITTO");
			Console.WriteLine("-------------------------------");
			Console.WriteLine("Totalt           : {0,12:c}", subtotal);
			Console.WriteLine("Öresavrundning   : {0,12:c}", avrundatBelopp);
			Console.WriteLine("Att betala       : {0,12:c0}", total);
			Console.WriteLine("Kontant          : {0,12:c0}", erhalletBelopp);
			Console.WriteLine("Tillbaka         : {0,12:c0}", tillbaka);
			Console.WriteLine("-------------------------------");

			int femhundra = 0;
			int hundra = 0;
			int tjugo = 0;
			int femkronor = 0;
			int enkrona = 0;

			femhundra = tillbaka / 500;
			tillbaka = tillbaka % 500;
			hundra = tillbaka / 100;
			tillbaka = tillbaka % 100;
			tjugo = tillbaka / 20;
			tillbaka = tillbaka % 20;
			femkronor = tillbaka / 5;
			tillbaka = tillbaka % 5;
			enkrona = tillbaka / 1;
			tillbaka = tillbaka % 1;

			if (pengarTillbaka >= 0)
			{
				Console.WriteLine("500-lappar       : {0}", femhundra);
			}
			if (pengarTillbaka >= 0)
			{
				Console.WriteLine("100-lappar       : {0}", hundra);
			}
			if (pengarTillbaka >= 0)
			{
				Console.WriteLine("20-lappar        : {0}", tjugo);
			}
			if (pengarTillbaka >= 0)
			{
				Console.WriteLine("5-kronor         : {0}", femkronor);
			}
			if (pengarTillbaka >= 0)
			{
				Console.WriteLine("1-kronor         : {0}", enkrona);
			}
		}
	}
}
