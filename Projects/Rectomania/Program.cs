using System;
using System.Threading;

struct Rect
{
    public int x, y;
    public int width, height;
    public char color;

    public Rect(int _x, int _y, int _width, int _height, char _color = '░')
    {
        x = _x;
        y = _y;
        width = _width;
        height = _height;
        color = _color;
    }
}

namespace Rectomania
{
    class Program
    {
        static void Main()
        {
            Console.ForegroundColor = ConsoleColor.Yellow; // пример изменения цвета символов

            ConsoleGraphics consoleGraphics = new ConsoleGraphics(50, 20);

            Random rand = new Random();
            while (true)
            {
                int cx = rand.Next(10, 40); //коэффициенты подобраны для +- равномерного распределения
                int cy = rand.Next(5, 15);
                int width = rand.Next(1, 12);
                int height = rand.Next(1, 6);

                Rect rect = new Rect(cx - width / 2, cy - height / 2, width, height, (char)('░' + rand.Next(0, 3)));
                consoleGraphics.Draw(rect);
                consoleGraphics.Display();

                Thread.Sleep(300);
            }

            //RectangleList lst = new RectangleList("list.txt"); //пример чтения из файла
            //consoleGraphics.Draw(lst);
            //consoleGraphics.Display();

            //Console.Read();
            //return;
        }
    }

}