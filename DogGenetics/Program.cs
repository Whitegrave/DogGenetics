using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DogGenetics
{
    class Program
    {
        static void Main(string[] args)
        {
            string dogName = "";
            bool nameValid = false;
            while (!nameValid)
            {
                Console.WriteLine("What is your dog's name?");
                dogName = Console.ReadLine();
                // Cycle through each character with a Linq lambda to validate each character as a letter
                // Extra cycle done to ensure the name contains letters, and not just empty spaces "    "
                bool containsLetter = dogName.Any(c => Char.IsLetter(c));
                // Cycle through each character, check if a letter or space
                bool charsValid = dogName.All(c => Char.IsLetter(c) || Char.IsWhiteSpace(c));
                // Name contained characters other than letters/spaces
                if (!charsValid)
                {
                    Console.WriteLine("That name was not valid. Please use letters only, no spaces or other characters.");
                }
                // Name contained no invalid characters, but did not have at least 1 letter (invalid)
                else if (!containsLetter)
                {
                    Console.WriteLine("That name was not valid. Please use letters only, no spaces or other characters.");
                }
                // Name contained no invalid characters, at least 1 letter, and no invalid characters (valid)
                else
                {
                    nameValid = true;
                    // Remove leading/trailing spaces
                    dogName.Trim();                
                }
            }
            Console.WriteLine($"Well then, I have this highly reliable report on {dogName}'s prestigious background right here.\n");
            Console.WriteLine($"{dogName} is:\n");

            // Generating 5 numbers totaling 100.
            // Pick 5 numbers, total them, and divide each by the total for a %

            Random rndGen = new Random();
            decimal breedOne = rndGen.Next(1, 101);
            decimal breedTwo = rndGen.Next(1, 101);
            decimal breedThree = rndGen.Next(1, 101);
            decimal breedFour = rndGen.Next(1, 101);
            decimal breedFive = rndGen.Next(1, 101);
            decimal breedTotal = breedOne + breedTwo + breedThree + breedFour + breedFive;
            // Convert to percentage of the whole with 1 decimal precision
            breedOne = Math.Round(breedOne / breedTotal, 5, MidpointRounding.AwayFromZero) * 100;
            breedTwo = Math.Round(breedTwo / breedTotal, 5, MidpointRounding.AwayFromZero) * 100;
            breedThree = Math.Round(breedThree / breedTotal, 5, MidpointRounding.AwayFromZero) * 100;
            breedFour = Math.Round(breedFour / breedTotal, 5, MidpointRounding.AwayFromZero) * 100;
            breedFive = Math.Round(breedFive / breedTotal, 5, MidpointRounding.AwayFromZero) * 100;
            // Add to an array for sorting
            decimal[] breedArrayForSort = { breedOne, breedTwo, breedThree, breedFour, breedFive };
            Array.Sort(breedArrayForSort);
            Array.Reverse(breedArrayForSort);
            // Move items into a string array for easier formatting, remove trailing spaces
            string[] breedArrayForDisplay = Array.ConvertAll(breedArrayForSort, item => item.ToString("0.###"));
            // Display to screen with breeds
            Console.WriteLine($"{breedArrayForDisplay[0]}% Husky");
            Console.WriteLine($"{breedArrayForDisplay[1]}% Dobermann");
            Console.WriteLine($"{breedArrayForDisplay[2]}% Terrier");
            Console.WriteLine($"{breedArrayForDisplay[3]}% Mongrel");
            Console.WriteLine($"{breedArrayForDisplay[4]}% Wolf\n");

            Console.WriteLine($"{dogName} is quite the dog!");

            Console.ReadKey();
        }
    }
}
