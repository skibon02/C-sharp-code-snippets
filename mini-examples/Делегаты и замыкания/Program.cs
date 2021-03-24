using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

class Program
{

    // Пример1 - счётчик, работающий на замыкании
    // здесь лямбда-выражение связывается с лексическим окружением функции и, следовательно, с переменной i
    // связь остаётся даже после завершения функции
    public delegate int CounterAction();
    public static CounterAction MakeCounter()
    {
        int c = 0;
        CounterAction increment = () => c++;
        return increment;
    }

    // Пример2 - функция возврашает лямбда выражение, которое мы так же можем вызвать как функцию
    // получается запись вида Sum(a)(b), причём второй вызов - вызов лямбда-выражения, 
    // которое берет аргумент a из лексического окружения
    public delegate int SumAction(int a);
    public static SumAction Sum(int a)
    {
        SumAction delegateSum = (b) => a + b;
        return delegateSum;
    }


    // Пример3 - комбинация полиморфизма, универсальных классов и новой темы делегатов
    // данная функция конвертирует каждый элемент перечесляемого объекта в другой тип,
    // и делает это при помощи функции action, которую мы передаем как аргумент
    delegate T ConvertAction<U, T>(U a);
    static List<T> ConvertTypes<U, T>(IEnumerable<U> inp, ConvertAction<U, T> action)
    {
        List<T> res = new List<T>();
        foreach (U val in inp)
        {
            res.Add(action(val));
        }
        return res;
    }


    static void Main(string[] args)
    {

        Console.WriteLine("Пример1");
        CounterAction counter = MakeCounter();

        Console.WriteLine(counter());
        Console.WriteLine(counter());
        Console.WriteLine(counter());

        //разные вызовы функций создают разные счетчики и лексические окружения
        CounterAction counter2 = MakeCounter();

        Console.WriteLine(counter2());
        Console.WriteLine(counter2());
        Console.WriteLine(counter2());
        Console.WriteLine();


        Console.WriteLine("Пример2");
        Console.WriteLine("3 + 6 = {0}", Sum(3)(6));
        Console.WriteLine();

        Console.WriteLine("Пример3");
        //для объекта List (можно использовать и обычные массивы)
        List<int> lst = new List<int> { 1,4,6,3,6};
        List<float> resLst = ConvertTypes<int, float>(lst, (a)=>a+0.5f);
        Console.WriteLine("Before: {0}\nAfter: {1}", string.Join(" ", lst), string.Join(" ", resLst));

        Console.Read();
    }
}
