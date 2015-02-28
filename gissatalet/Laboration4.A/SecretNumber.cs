using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Laboration4.A
{
	public class SecretNumber
	{
		private int _count;
		private int _number;
		public const int MaxNumberOfGuesses = 7;

		public SecretNumber()
		{
			Initialize();		// anropa 
		}

		public void Initialize()
		{
			Random myRandom = new Random();
			_number = myRandom.Next(1, 101);
			_count = 0;
		}

		public bool MakeGuess(int number)
		{
			if (_count >= MaxNumberOfGuesses)
			{
				throw new ApplicationException();
			}

			if (number < 1 || number > 100)
			{
				throw new ArgumentOutOfRangeException();
			}

			++_count;

			if(number == _number)
			{
				Console.WriteLine("Rätt gissat. Du klararde det på {0} försök.",_count);
				return true;
			}

			if(number > _number)
			{
				Console.WriteLine("{0} är för högt. Du har {1} gissningar kvar.", number, MaxNumberOfGuesses - _count);

			}
			else
			{
				Console.WriteLine("{0} är för lågt. Du har {1} gissningar kvar.",number, MaxNumberOfGuesses - _count);
			}

			if (MaxNumberOfGuesses == _count)
			{
				Console.WriteLine("Det hemliga talet är {0}.", _number);
			}

			return false;
		}
	}
}
