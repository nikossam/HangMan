using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HangMan
{
    internal class Program
    {
        private static void printHangman(int wrong)
        {
            if (wrong == 0)
            {
                Console.WriteLine("\n+---+");
                Console.WriteLine("      |");
                Console.WriteLine("      |");
                Console.WriteLine("      |");
                Console.WriteLine("   ===");
            }
            else if(wrong == 1)
            {
                Console.WriteLine("\n+---+");
                Console.WriteLine("  O   |");
                Console.WriteLine("      |");
                Console.WriteLine("      |");
                Console.WriteLine("   ===");
            }
            else if(wrong == 2)
            {
                Console.WriteLine("\n+---+");
                Console.WriteLine("  O   |");
                Console.WriteLine("  |   |");
                Console.WriteLine("      |");
                Console.WriteLine("   ===");
            }
            else if(wrong == 3)
            {
                Console.WriteLine("\n+---+");
                Console.WriteLine("  O   |");
                Console.WriteLine(" /|   |");
                Console.WriteLine("      |");
                Console.WriteLine("   ===");
            }
            else if (wrong == 4)
            {
                Console.WriteLine("\n+---+");
                Console.WriteLine("  O   |");
                Console.WriteLine(" /|\\ |");
                Console.WriteLine("      |");
                Console.WriteLine("   ===");
            }
            else if(wrong == 5)
            {
                Console.WriteLine("\n+---+");
                Console.WriteLine("  O   |");
                Console.WriteLine(" /|\\ |");
                Console.WriteLine(" /    |");
                Console.WriteLine("   ===");
            }
            else if(wrong == 6)
            {
                Console.WriteLine("\n+---+");
                Console.WriteLine("  O   |");
                Console.WriteLine(" /|\\ |");
                Console.WriteLine(" / \\ |");
                Console.WriteLine("   ===");
            }
        }

        private static int printWord(List<char> guessesLetters,string randomWord)
        {
            int counter = 0;
            int rightLetters = 0;
            Console.Write("\r\n");
            foreach(char c in randomWord)
            {
                if (guessesLetters.Contains(c))
                {
                    Console.Write(c + " ");
                    rightLetters++;
                }
                else
                {
                    Console.Write(" ");
                }
                counter++;
            }
            return rightLetters;
        }

        private static void printLines(string randomWord)
        {
            Console.Write("\r");
            foreach(char c in randomWord)
            {
                Console.OutputEncoding = System.Text.Encoding.Unicode;
                Console.Write("\u0305 ");
            }
        }

        static void Main(string[] args)
        {
            Console.WriteLine("Welcome to Hangman!");
            Console.WriteLine("=================================");

            Random random = new Random();
            List<string> wordDictionary = new List<string> { "subway", "foxglove", "luxury", "abyss", "syndrome" };
            int index = random.Next(wordDictionary.Count);
            string randomWord = wordDictionary[index];

            foreach(char c in randomWord)
            {
                Console.Write("_ ");
            }

            int lengthOfWordToGuess = randomWord.Length;
            int amountOfTimesWrong = 0;
            List<char>currentLettersGuessed = new List<Char>();
            int currentLettersRight = 0;

            while(amountOfTimesWrong != 6 && currentLettersRight != lengthOfWordToGuess)
            {
                Console.Write("\nLetters guessed so far: ");
                foreach(char letter in currentLettersGuessed)
                {
                    Console.Write(letter + " ");
                }

                Console.Write("\nGuess a letter: ");
                char letterGuessed = Console.ReadLine()[0];

                if (currentLettersGuessed.Contains(letterGuessed))
                {
                    Console.Write("\r\nYou have already guessed this letter.");
                    printHangman(amountOfTimesWrong);
                    currentLettersRight = printWord(currentLettersGuessed, randomWord);
                    printLines(randomWord);
                }
                else
                {
                    bool right = false;
                    for(int i = 0; i < randomWord.Length; i++)
                    {
                        if(letterGuessed == randomWord[i])
                        {
                            right = true;
                        }
                    }

                    if(right)
                    {
                        printHangman(amountOfTimesWrong);
                        currentLettersGuessed.Add(letterGuessed);
                        currentLettersRight = printWord(currentLettersGuessed, randomWord);
                        Console.Write("\r\n");
                        printLines(randomWord);
                    }
                    else
                    {
                        amountOfTimesWrong++;
                        currentLettersGuessed.Add(letterGuessed);
                        printHangman(amountOfTimesWrong);
                        currentLettersRight = printWord(currentLettersGuessed,randomWord);
                        Console.Write("\r\n");
                        printLines(randomWord);
                    }
                }
            }
            Console.WriteLine("\r\nGame is over!");
            Console.ReadKey();
        }
    }
}
