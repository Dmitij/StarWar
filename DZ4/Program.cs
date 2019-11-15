using System;
using System.Collections.Generic;
using System.Linq;


namespace DZ4
{
    public class Program
    {
        public static void Main()
        {

            //            2.Дана коллекция List<T>, требуется подсчитать, сколько раз каждый элемент встречается в данной коллекции:
            //            а) для целых чисел;
            //            б) *для обобщенной коллекции;
            //            в) *используя Linq.
            //            3. * Дан фрагмент программы:
            //Dictionary<string, int> dict = new Dictionary<string, int>()
            //  {
            //    {"four",4 },
            //    {"two",2 },
            //    { "one",1 },
            //    {"three",3 },
            //  };
            //            var d = dict.OrderBy(delegate (KeyValuePair<string, int> pair) { return pair.Value; });
            //            foreach (var pair in d)
            //            {
            //                Console.WriteLine("{0} - {1}", pair.Key, pair.Value);
            //            }
            //            а) Свернуть обращение к OrderBy с использованием лямбда - выражения $.
            //        б) *Развернуть обращение к OrderBy с использованием делегата Predicate<T>.
            Console.Clear();
            var rand = new Random();
            List<int> intList = new List<int>();
            int j = 10000;
            for (int i = 0; i < j; i++)
                intList.Add(rand.Next(0, 100));
            //Console.WriteLine(intList.ToString());


            int counter=0;
            int a= rand.Next(0, 100);


            foreach (var item in intList)
            {
                if (item == a)
                    counter++;
            }
            Console.WriteLine("В случайном списке из " + j + " элементов, число " + a +  " встречается " + counter + " раз");  
            
            Console.WriteLine("В случайном списке из " + j + " элементов, число " + a + " встречается " + (from x in intList where x == a select x).Count() + " раз");


            Dictionary<string, int> dict = new Dictionary<string, int>()
              {
                {"four",4 },
                {"two",2 },
                {"one",1 },
                {"three",3 },
              };
            var d = dict.OrderBy(delegate (KeyValuePair<string, int> pair) { return pair.Value; });
            var d1 = dict.OrderBy(s => s.Value);
            //var d2 = Predicate<Dictionary<string, int>>.CreateDelegate(KeyValuePair<string, int>,);
            foreach (var pair in d)
            {
                Console.WriteLine("{0} - {1}", pair.Key, pair.Value);
            }
            foreach (var pair in d1)
            {
                Console.WriteLine("{0} - {1}", pair.Key, pair.Value);
            }
            Console.ReadKey(); 
        }
    }
}
