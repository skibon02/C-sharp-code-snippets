using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Closure
{
    class Program
    {
        // В теории данная функция должна пользоваться свойствами замыкания и создавать массив "функций-стрелков"
        // и каждая из таких функций при её вызове должна выводить свой номер от 0 до 10.
        public static List<Action> MakeArmy()
        {
            List<Action> shooters = new List<Action>();
            int i = 0;
            while (i < 10)
            {
                Action shooter = () =>
                {
                    Console.WriteLine(i);
                };
                shooters.Add(shooter);
                i++;
            }
            return shooters;
        }

        static void Main(string[] args)
        {
            // Создаём армию стрелков
            List<Action> shooters = MakeArmy();
            // ... и пытаемся "выстрелить" каким-нибудь элементом
            shooters[0]();
            shooters[3]();
            shooters[4]();
            // Однако результат работы программы получается совсем не тот, который мы ожидали...
            // Как можно доработать эту функцию, чтобы каждый стрелок выводил свой номер корректно (используя свойства замыкания)? Допустимо несколько способов.

            Console.Read();
        }
    }
}
