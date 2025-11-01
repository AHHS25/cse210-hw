using System;

class Program
{
    // 1) Muestra el mensaje de bienvenida
    static void DisplayWelcome()
    {
        // Nota: el ejemplo usa "program" con p minúscula.
        Console.WriteLine("Welcome to the program!");
    }

    // 2) Pide y devuelve el nombre del usuario
    static string PromptUserName()
    {
        Console.Write("Please enter your name: ");
        string name = Console.ReadLine();
        return name;
    }

    // 3) Pide y devuelve el número favorito como entero
    static int PromptUserNumber()
    {
        Console.Write("Please enter your favorite number: ");
        string input = Console.ReadLine();
        int number = int.Parse(input); // si prefieres validación robusta, avísame y lo cambio a TryParse
        return number;
    }

    // 4) Recibe un int y devuelve su cuadrado
    static int SquareNumber(int value)
    {
        return value * value;
    }

    // 5) Recibe nombre y cuadrado, y los muestra
    static void DisplayResult(string userName, int squared)
    {
        Console.WriteLine($"{userName}, the square of your number is {squared}");
    }

    // Orquestación en Main
    static void Main()
    {
        DisplayWelcome();

        string name = PromptUserName();
        int favorite = PromptUserNumber();

        int squared = SquareNumber(favorite);

        DisplayResult(name, squared);
    }
}
