using System;

class Program
{
    static void Main()
    {
        // Generador de números aleatorios (se reutiliza entre partidas)
        Random rng = new Random();

        string playAgain;
        do
        {
            // ---- Core: generar número mágico 1..100 ----
            int magic = rng.Next(1, 101);

            // (Si quieres probar con uno fijo, descomenta la siguiente línea y comenta la de arriba)
            // int magic = 6;

            Console.WriteLine("I'm thinking of a number between 1 and 100.");

            int guesses = 0;   // Stretch: contador de intentos
            int guess = int.MinValue;

            // ---- Core: bucle hasta acertar ----
            while (guess != magic)
            {
                Console.Write("What is your guess? ");

                // Validación sencilla
                string input = Console.ReadLine()?.Trim();
                if (!int.TryParse(input, out guess))
                {
                    Console.WriteLine("Please enter a whole number.");
                    continue;
                }

                guesses++; // contamos solo intentos válidos

                if (guess < magic)
                {
                    Console.WriteLine("Higher");
                }
                else if (guess > magic)
                {
                    Console.WriteLine("Lower");
                }
                else
                {
                    Console.WriteLine("You guessed it!");
                }
            }

            // ---- Stretch: reportar intentos ----
            Console.WriteLine($"You guessed it in {guesses} guess{(guesses == 1 ? "" : "es")}!");

            // ---- Stretch: preguntar si juega otra vez ----
            Console.Write("Do you want to play again? (yes/no): ");
            playAgain = (Console.ReadLine() ?? "").Trim().ToLower();

            Console.WriteLine(); // línea en blanco entre partidas

        } while (playAgain == "yes");
    }
}
