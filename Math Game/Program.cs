using System;
using System.Numerics;

const string EXIT_COMMAND = "EXIT";

int points = 0;
string? input = "";
List<int[]> history = new List<int[]>();
Random randomizer = new Random();



do
{
    Console.Clear();
    Console.WriteLine("Welcome to the Math Game!");
    Console.WriteLine("Choose an option:");
    Console.WriteLine("1. Addition challenge");
    Console.WriteLine("2. Subtraction challenge");
    Console.WriteLine("3. Multiplication challenge");
    Console.WriteLine("4. Division challenge");
    input = Console.ReadLine();

    switch (input)
    {
        case "1":
            Console.Clear();
            Console.WriteLine("Addition challenges");
            AdditionChallenges();
            break;
        case "2":
            Console.Clear();
            Console.WriteLine("Subtraction challenges");
            input = Console.ReadLine();
            break;
        case "3":
            Console.Clear();
            Console.WriteLine("Multiplication challenges");
            input = Console.ReadLine();
            break;
        case "4":
            Console.Clear();
            Console.WriteLine("Division challenges");
            input = Console.ReadLine();
            break;
        default:
            Console.WriteLine("Invalid option. Press ENTER to go back or type EXIT to exit the game");
            input = Console.ReadLine();
            break;
    }

} while (!string.Equals(input, EXIT_COMMAND, StringComparison.OrdinalIgnoreCase));


void AdditionChallenges()
{
    string? guessInput = "";
    int guess;
    bool fail = false;
    int firstNumber = 0;
    int secondNumber = 0;

    do
    {
        firstNumber = randomizer.Next(1,100);
        secondNumber = randomizer.Next(1,100);

        Console.Write($"{firstNumber} + {secondNumber} = ");
        guessInput = Console.ReadLine();
        
        if (int.TryParse(guessInput, out guess))
        {
            bool isCorrect = guess == firstNumber + secondNumber;
            if (guess == firstNumber + secondNumber)
            {
                Console.WriteLine("CORRECT! +1 point");
                points++;
            } else
            {
                Console.WriteLine("INCORRECT! You lose");
                fail = true;
            }

            history.Add([(int)Operations.Addition, firstNumber, secondNumber, guess, Convert.ToInt32(isCorrect)]);
        }

    } while (!fail);
}

public enum Operations
{
    Addition,
    Subtraction,
    Multiplication,
    Division
}