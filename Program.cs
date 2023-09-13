using System;
using System.Threading;

namespace JuegoAhorcado
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Bienvenido al juego del ahorcado!");

            string? palabraOriginal;
            do
            {
                Console.Write("Por favor, ingresa la palabra a adivinar: ");
                palabraOriginal = Console.ReadLine();
            } while (string.IsNullOrEmpty(palabraOriginal));

            string palabra = palabraOriginal.ToUpper();
            bool esPalabraMayuscula = char.IsUpper(palabraOriginal[0]);

            string letrasAdivinadas = "";
            string letrasIncorrectas = "";
            int intentosRestantes = 6;

            while (intentosRestantes > 0 && !PalabraAdivinada(palabra, letrasAdivinadas))
            {
                Console.WriteLine("Intentos restantes: {0}", intentosRestantes);
                MostrarProgreso(palabraOriginal, palabra, letrasAdivinadas, letrasIncorrectas, esPalabraMayuscula);

                string? entrada;
                char letra;
                do
                {
                    Console.Write("Por favor, ingresa una letra: ");
                    entrada = Console.ReadLine();
                    if (string.IsNullOrEmpty(entrada))
                    {
                        continue;
                    }
                    letra = entrada[0];
                   
                    if (esPalabraMayuscula)
                    {
                        letra = char.ToUpper(letra);
                    }
                    break;
                } while (true);

                if (palabra.Contains(letra))
                {
                    Console.WriteLine("¡Adivinaste una letra!\n");
                    letrasAdivinadas += letra;
                }
                else
                {
                    Console.WriteLine("¡Incorrecto!");
                    letrasIncorrectas += letra;
                    intentosRestantes--;
                    DibujarAhorcado(intentosRestantes);
                }
            }

            Console.WriteLine();
            if (PalabraAdivinada(palabra, letrasAdivinadas))
            {
                Console.WriteLine("¡Ganaste! La palabra era: {0}", palabraOriginal);
                Thread.Sleep(6000);
                Environment.Exit(0);
            }
            else
            {
                Console.WriteLine("¡Perdiste! La palabra era: {0}", palabraOriginal);
                DibujarAhorcado(0);
                Thread.Sleep(6000);
                Environment.Exit(0);
            }

            Console.ReadLine();
        }

        static bool PalabraAdivinada(string palabra, string letrasAdivinadas)
        {
            foreach (char letra in palabra)
            {
                if (!letrasAdivinadas.Contains(letra.ToString()))
                {
                    return false;
                }
            }
            return true;
        }

        static void MostrarProgreso(string palabraOriginal, string palabra, string letrasAdivinadas, string letrasIncorrectas, bool esPalabraMayuscula)
        {
            string palabraAdivinada = ObtenerPalabraAdivinada(palabraOriginal, palabra, letrasAdivinadas, esPalabraMayuscula);
            Console.WriteLine("Palabra: {0}", palabraAdivinada);
            Console.WriteLine("Letras incorrectas: {0}", letrasIncorrectas);
        }

        static string ObtenerPalabraAdivinada(string palabraOriginal, string palabra, string letrasAdivinadas, bool esPalabraMayuscula)
        {
            string palabraAdivinada = "";
            for (int i = 0; i < palabra.Length; i++)
            {
                char letra = palabraOriginal[i];
                if (letrasAdivinadas.Contains(palabra[i].ToString()))
                {
                    palabraAdivinada += esPalabraMayuscula ? letra.ToString().ToUpper() : letra.ToString();
                }
                else
                {
                    palabraAdivinada += "_";
                }
            }
            return palabraAdivinada;
        }

        static void DibujarAhorcado(int intentosRestantes)
        {
            switch (intentosRestantes)
            {
                case 6:
                    Console.WriteLine("__________");
                    Console.WriteLine("|        |");
                    Console.WriteLine("|         ");
                    Console.WriteLine("|         ");
                    Console.WriteLine("|         ");
                    Console.WriteLine("|         ");
                    Console.WriteLine("|_________");
                    break;
                case 5:
                    Console.WriteLine("__________");
                    Console.WriteLine("|        |");
                    Console.WriteLine("|        O");
                    Console.WriteLine("|         ");
                    Console.WriteLine("|         ");
                    Console.WriteLine("|         ");
                    Console.WriteLine("|_________");
                    break;
                case 4:
                    Console.WriteLine("__________");
                    Console.WriteLine("|        |");
                    Console.WriteLine("|        O");
                    Console.WriteLine("|        |");
                    Console.WriteLine("|         ");
                    Console.WriteLine("|         ");
                    Console.WriteLine("|_________");
                    break;
                case 3:
                    Console.WriteLine("__________");
                    Console.WriteLine("|        |");
                    Console.WriteLine("|        O");
                    Console.WriteLine("|       /|");
                    Console.WriteLine("|         ");
                    Console.WriteLine("|         ");
                    Console.WriteLine("|_________");
                    break;
                case 2:
                    Console.WriteLine("__________");
                    Console.WriteLine("|        |");
                    Console.WriteLine("|        O");
                    Console.WriteLine("|       /|\\");
                    Console.WriteLine("|         ");
                    Console.WriteLine("|         ");
                    Console.WriteLine("|_________");
                    break;
                case 1:
                    Console.WriteLine("__________");
                    Console.WriteLine("|        |");
                    Console.WriteLine("|        O");
                    Console.WriteLine("|       /|\\");
                    Console.WriteLine("|       / ");
                    Console.WriteLine("|         ");
                    Console.WriteLine("|_________");
                    break;
                case 0:
                    Console.WriteLine("__________");
                    Console.WriteLine("|        |");
                    Console.WriteLine("|        O");
                    Console.WriteLine("|       /|\\");
                    Console.WriteLine("|       / \\");
                    Console.WriteLine("|         ");
                    Console.WriteLine("|_________");
                    break;
            }
        }
    }
}