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