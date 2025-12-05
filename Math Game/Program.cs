using System;
using System.Numerics;

const string EXIT_COMMAND = "EXIT";

int points = 0;
string? input = "";
int choice;
List<int[]> history = new List<int[]>();
Random randomizer = new Random();



do
{
    Console.Clear();
    Console.WriteLine("Welcome to the Math Game!");
    Console.WriteLine($"Current Points: {points}\n");
    Console.WriteLine("Choose an option:");
    Console.WriteLine("1. Addition challenge");
    Console.WriteLine("2. Subtraction challenge");
    Console.WriteLine("3. Multiplication challenge");
    Console.WriteLine("4. Division challenge");
    Console.WriteLine("'exit' to close the program\n");
    Console.WriteLine("History:");

    foreach ( int[]match in history){
        Console.WriteLine(match[0] switch
        {
            0 => $"{match[1]} + {match[2]} = {match[3]} : {(match[4] == 1 ? "Correct" : "Incorrect")}",
            1 => $"{match[1]} - {match[2]} = {match[3]} : {(match[4] == 1 ? "Correct" : "Incorrect")}",
            2 => $"{match[1]} * {match[2]} = {match[3]} : {(match[4] == 1 ? "Correct" : "Incorrect")}",
            3 => $"{match[1]} / {match[2]} = {match[3]} : {(match[4] == 1 ? "Correct" : "Incorrect")}",
            _ => "Unknown operation"
        });
    }

    input = Console.ReadLine();
    input = input?.Trim();
    
    bool success = int.TryParse(input, out choice);
    if (!success) {
        continue;
    }
    Console.Clear();
    
    if (choice < 5 && choice > 0) {
        Challenges(choice);
    }
} while (!string.Equals(input, EXIT_COMMAND, StringComparison.OrdinalIgnoreCase));


void Challenges(int choice)
{
    string? guessInput = "";
    int guess;
    bool fail = false;
    int firstNumber = 0;
    int secondNumber = 0;
    int result = 0;

    void AddHistory(Operations op, int a, int b, int g, bool correct)
    {
        history.Add([(int)op, a, b, g, Convert.ToInt32(correct)]);
    }

    Operations resolvedOperation = choice switch
    {
        1 => Operations.Addition,
        2 => Operations.Subtraction,
        3 => Operations.Multiplication,
        4 => Operations.Division,
        _ => throw new ArgumentOutOfRangeException(nameof(choice))
    };

    do
    {
        Console.WriteLine("<ENTER> to go back");

        switch (choice)
        {
            case 1:
                firstNumber = randomizer.Next(1, 100);
                secondNumber = randomizer.Next(1, 100);
                result = firstNumber + secondNumber;
                Console.Write($"{firstNumber} + {secondNumber} = ");
                break;
            case 2:
                firstNumber = randomizer.Next(1, 100);
                secondNumber = randomizer.Next(1, 100);
                result = firstNumber - secondNumber;
                Console.Write($"{firstNumber} - {secondNumber} = ");
                break;
            case 3:
                firstNumber = randomizer.Next(0, 50);
                secondNumber = randomizer.Next(0, 10);
                result = firstNumber * secondNumber;
                Console.Write($"{firstNumber} * {secondNumber} = ");
                break;
            case 4:
                secondNumber = randomizer.Next(1, 13);
                int quotient = randomizer.Next(1, 13);
                firstNumber = secondNumber * quotient;
                result = quotient;
                Console.Write($"{firstNumber} / {secondNumber} = ");
                break;
        }
        guessInput = Console.ReadLine();

        if (string.IsNullOrWhiteSpace(guessInput) || string.Equals(guessInput, EXIT_COMMAND, StringComparison.OrdinalIgnoreCase))
        {
            fail = true;
            Console.Clear();
            break;
        }

        if (int.TryParse(guessInput, out guess))
        {
            bool isCorrect = guess == result;
            if (isCorrect)
            {
                Console.WriteLine("CORRECT! +1 point");
                points++;
                Console.ReadLine();
                Console.Clear();
            }
            else
            {
                Console.WriteLine("INCORRECT! You lose");
                fail = true;
                Console.ReadLine();
                Console.Clear();
            }
            AddHistory(resolvedOperation, firstNumber, secondNumber, guess, isCorrect);
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