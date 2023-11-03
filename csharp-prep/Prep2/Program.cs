using System;

class Program
{
    static void Main(string[] args)
    {
        Console.Write("What is your grade percentage? ");
        string number = Console.ReadLine();
        int percent = int.Parse(number);

        string grade = "A";

        if (percent >= 90){
            grade = "A";
        }
        else if (percent >= 80){
            grade = "B";
        }
        else if (percent >= 70){
            grade = "C";
        }
        else if (percent >= 60){
            grade = "D";
        }
        else{
            grade = "F";
        }

        Console.WriteLine($"Your grade is: {grade}");
        if (percent >= 70){
            Console.WriteLine("Good job!");
        }
        else{
            Console.WriteLine("You will get it next time!");
        }
    }
}