string? input = "";
const string EXIT_COMMAND = "EXIT";

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
            input = Console.ReadLine();
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