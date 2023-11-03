using System;

class Program
{
    static void Main(string[] args){
        DisplayWelcomeMessage();
        string Name = UserName();
        int Number = UserNumber();
        int squaredNumber = SquareNumber(Number);
        DisplayResult(Name, squaredNumber);
    }

    static void DisplayWelcomeMessage(){
        Console.WriteLine("Welcome to the program!");
    }

    static string UserName(){
        Console.Write("Please enter your name: ");
        string entername = Console.ReadLine();
        return entername;
    }

    static int UserNumber(){
        Console.Write("Please enter your favorite number: ");
        int enternumber = int.Parse(Console.ReadLine());

        return enternumber;
    }
    static int SquareNumber(int number){
        int square = number * number;
        return square;
    }
    static void DisplayResult(string name, int square){
        Console.WriteLine($"{name}, the square of your number is {square}");
    }
}