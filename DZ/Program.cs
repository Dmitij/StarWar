using System;
using DZ2;
using StarWar;
//Рязанцев Дмитрий
namespace DZ
{

    class Program
    {


        static void Menu()
        {
            Console.Clear();
            Console.WriteLine("1 - Игра StarWar");
            Console.WriteLine("2 - Домашнее задание 2");
            Console.WriteLine("3 - Домашнее задание 3. Добавить в пример Lesson3 обобщенный делегат");
            Console.WriteLine("4 - Домашнее задание 4");

            Console.WriteLine("AnyKey - Exit");
            ConsoleKeyInfo key = Console.ReadKey();
            switch (key.Key)
            {
                case ConsoleKey.D1:
                    StarWar.Program.Main();
                    break;
                case ConsoleKey.D2:
                    DZ2.Program.Main();
                    break;
                case ConsoleKey.D3:
                    DZ3.Program.Main();
                    break;
                case ConsoleKey.D4:
                    DZ4.Program.Main();
                    break;

                case ConsoleKey.D0:
                case ConsoleKey.Escape:
                    Console.WriteLine("Bye-bye");
                    return;
                default:
                    break;
            }
        }

        static void Main(string[] args)
        {
            Menu();
        }
    }
}