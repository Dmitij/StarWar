using System;

//1. Построить три класса(базовый и 2 потомка), описывающих некоторых работников с почасовой оплатой(один из потомков) и фиксированной оплатой(второй потомок).
//а) Описать в базовом классе абстрактный метод для расчёта среднемесячной заработной платы.Для «повременщиков» формула для расчета такова: «среднемесячная заработная плата = 20.8 * 8 * почасовая ставка», для работников с фиксированной оплатой «среднемесячная заработная плата = фиксированная месячная оплата».
//б) Создать на базе абстрактного класса массив сотрудников и заполнить его.
//в) * Реализовать интерфейсы для возможности сортировки массива, используя Array.Sort().
//г) * Создать класс, содержащий массив сотрудников, и реализовать возможность вывода данных с использованием foreach.

//Рязанцев Дмитрий
namespace DZ2
{

    public abstract class Person : IComparable
    {


        private string Name { get; set; }
        private int Age { get; set; }
        private string Position { get; set; }
        private double Rate { get; set; }

        public Person(string name, int age, string position, double rate)
        {
            Name = name;
            Age = age;
            Position = position;
            Rate = rate;
        }

        public abstract double MiddleSalary(double rate);

        public void GetInfo()
        {
            Console.WriteLine($"Имя: {Name}  Возраст: {Age} Должность: {Position} Средняя ЗП: {MiddleSalary(Rate)}");
        }

        //public int CompareTo(object obj)
        //{
        //    Person p;
        //    p = (Person)obj;
        //    return Name.CompareTo(p.Name);
        //}
        public int CompareTo(object obj)
        {
            Person p = obj as Person;
            if (p != null)
                return this.Name.CompareTo(p.Name);
            else
                throw new Exception("Невозможно сравнить два объекта");
        }
    }

    public class HourlyWorker : Person
    {
        public HourlyWorker(string name, int age, string position, double rate) : base(name, age, position, rate)
        {

        }
        public override double MiddleSalary(double hourlyrate)
        {
            return 20.8 * 8 * hourlyrate;
        }


    }

    public class MonthWorker : Person
    {
        public MonthWorker(string name, int age, string position, double rate) : base(name, age, position, rate)
        {

        }
        public override double MiddleSalary(double rate)
        {
            return rate;
        }
    }


    public class Program
    {
        public static void Main()
        {
            Console.Clear();

            HourlyWorker vlad = new HourlyWorker("Владимир", 34, "Охранник", 500);
            HourlyWorker tat = new HourlyWorker("Татьяна", 29, "Кассир", 700);
            MonthWorker dim = new MonthWorker("Дмитрий", 39, "Гендир", 150000);
            MonthWorker olg = new MonthWorker("Ольга", 35, "Бухгалтер", 50000);

            Person[] workers = new Person[] { dim, olg, vlad, tat };
            Console.WriteLine("Заданный массив");
            foreach (Person wor in workers)
                wor.GetInfo();

            Array.Sort(workers);
            Console.WriteLine("Отсортированный массив");
            foreach (Person wor in workers)
                wor.GetInfo();

            Console.ReadKey();
        }


    }
}
