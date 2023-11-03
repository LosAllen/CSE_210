using System;

class Program
{
    static void Main(string[] args)
    {
        Random randomGenerator = new Random();
        int magicNumber = randomGenerator.Next(0, 100);

        int guess = -1;

        while (guess != magicNumber) {

            Console.Write("Enter your guess: ");
            guess = int.Parse(Console.ReadLine());

            if (magicNumber > guess) {
                Console.WriteLine("Too low");
            }
            else if (magicNumber < guess) {
                Console.WriteLine("Too high");
            }
            else {
                Console.WriteLine("You guessed it!");
            }

        }                    
    }
}