using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _1DV402.S2.L1B
{
    public class SecretNumber
    {
        //Fields
        public const int MaxNumberOfGuesses = 7;
        private int[] _guessedNumbers = new int[MaxNumberOfGuesses];
        private int _number;
        
        //Constructor
        public SecretNumber()
        {
            Initialize();
        }

        //Properties
        public bool CanMakeGuess { get; set; }
        public int Count { get; set; }
        public int GuessesLeft
        {
            get
            {
                return (MaxNumberOfGuesses - Count);
            }
        }

        //Methods
        public void Initialize()
        {
            Array.Clear(_guessedNumbers, 0, Count);
            CanMakeGuess = true;
            Random random = new Random();
            _number = random.Next(1, 101);
            Count = 0;
        }
       
        public bool MakeGuess(int number)
        {
            /* I could put some logic from the beginning of this method
             * , into class properties but I read that it is not 
             * recommandation to have a logic in the properties.
             */

            if (1 > number || number > 100)
                throw new ArgumentOutOfRangeException("Du måste ange ett värde mellan 1 och 100!");

            if (GuessesLeft == 0)
                throw new ApplicationException("Det är inte möjligt att gissa mer än 7 gånger!");

            if (_guessedNumbers.Contains(number))
            {
                Console.WriteLine("Du har redan gissat {0}. Gör om gissningen!", number);
                return false;
            }

            Count++;

            if (number == _number)
            {
                Console.WriteLine("RÄTT GISSAT! Du klarade det på {0} försök.", Count);
                CanMakeGuess = false;
                return true;
            }
            else if (number < _number)
                Console.WriteLine("{0} är för lågt. Du har {1} gissningar kvar.", number, GuessesLeft);
            
            else if (number > _number)
                Console.WriteLine("{0} är för högt. Du har {1} gissningar kvar.", number, GuessesLeft);
            
            while (GuessesLeft == 0)
            {
                CanMakeGuess = false;
                Console.WriteLine("Det hemliga talet är {0}", _number);
                return true;
            }
            _guessedNumbers[Count - 1] = number;
            return false;
        }
    }
}
