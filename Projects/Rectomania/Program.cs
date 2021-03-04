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

class Program
{
    /*
     *  Функция начальной инициализации буфера.
     */
    static char[,] InitBuffer(int width, int height)
    {
        char[,] buff = new char[height, width]; // первое измерение - строки, поэтому сначала идет высота, а потом ширина
        for (int i = 0; i < buff.GetLength(0); i++)
        {
            for (int j = 0; j < buff.GetLength(1); j++)
            {
                buff[i, j] = ' ';
            }
        }
        return buff;
    }

    /*
     *  Вывод содержимого буфера на экран. 
     */
    static void Display(char[,] buff)
    {
        // С точки зрения оптимизации, Console.Write отрабатывает мгновенно, задержки вывода имеются только в самой консоли
        // Поэтому использовать двойной цикл здесь удобнее, чем как-то конвертировать двумерный массив в одномерную строку.
        for (int i = 0; i < buff.GetLength(0); i++)
        {
            for (int j = 0; j < buff.GetLength(1); j++)
            {
                Console.Write(buff[i, j]);
            }
            Console.Write('\n');
        }
    }

    /* 
     *  Функция отрисовки фигуры (прямоугольника) в буфере "пикселей".
     */
    static void Draw(char[,] buff, Rect rect)
    {
        Console.Clear();
        for (int i = rect.y; i < rect.y + rect.height && i < buff.GetLength(0); i++)
        {
            for (int j = rect.x; j < rect.x + rect.width && j < buff.GetLength(1); j++)
            {
                buff[i, j] = rect.color;
            }
        }
    }
    static void Main()
    {

        Console.ForegroundColor = ConsoleColor.Yellow; // пример изменения цвета символов

        char[,] buff = InitBuffer(50, 20);

        Random rand = new Random();
        while (true)
        {
            int cx = rand.Next(10, 40); //коэффициенты подобраны для +- равномерного распределения
            int cy = rand.Next(5, 15);
            int width = rand.Next(1, 12);
            int height = rand.Next(1, 6);

            Rect rect = new Rect(cx - width / 2, cy - height / 2, width, height, (char)('░' + rand.Next(0, 3)));
            Draw(buff, rect);
            Display(buff);

            Thread.Sleep(300);
        }


        return;
    }
}
