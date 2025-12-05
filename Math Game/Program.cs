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
    Console.WriteLine("Choose an option:");
    Console.WriteLine("1. Addition challenge");
    Console.WriteLine("2. Subtraction challenge");
    Console.WriteLine("3. Multiplication challenge");
    Console.WriteLine("4. Division challenge");
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

    do
    {
        firstNumber = randomizer.Next(1,100);
        secondNumber = randomizer.Next(1,100);

        switch (choice)
        {
            case 1:
                Console.Write($"{firstNumber} + {secondNumber} = ");
                result = firstNumber + secondNumber;
                break;
            case 2:
                Console.Write($"{firstNumber} - {secondNumber} = ");
                result = firstNumber - secondNumber;
                break;
            case 3:
                Console.Write($"{firstNumber} * {secondNumber} = ");
                result = firstNumber * secondNumber;
                break;
            case 4:
                Console.Write($"{firstNumber} / {secondNumber} = ");
                result = firstNumber / secondNumber;
                break;
        }
        guessInput = Console.ReadLine();
        
        if (int.TryParse(guessInput, out guess))
        {
            bool isCorrect = guess == result;
            if (isCorrect)
            {
                Console.WriteLine("CORRECT! +1 point");
                points++;
            } else
            {
                Console.WriteLine("INCORRECT! You lose");
                fail = true;
            }

            switch (choice)
            {
                case 1:
                    history.Add([(int)Operations.Addition, firstNumber, secondNumber, guess, Convert.ToInt32(isCorrect)]);
                    break;
                case 2:
                    history.Add([(int)Operations.Subtraction, firstNumber, secondNumber, guess, Convert.ToInt32(isCorrect)]);
                    break;
                case 3:
                    history.Add([(int)Operations.Multiplication, firstNumber, secondNumber, guess, Convert.ToInt32(isCorrect)]);
                    break;
                case 4:
                    history.Add([(int)Operations.Division, firstNumber, secondNumber, guess, Convert.ToInt32(isCorrect)]);
                    break;
            }
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