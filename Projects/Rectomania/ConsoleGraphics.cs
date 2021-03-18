using System;



namespace Rectomania
{
    class ConsoleGraphics
    {
        char[,] buff;
        int width, height;


        /*
         *  Конструктор, который инициализирует буфер
         */
        public ConsoleGraphics(int _width = 50, int _height = 20)
        {
            width = _width;
            height = _height;
            buff = new char[height, width]; // первое измерение - строки, поэтому сначала идет высота, а потом ширина
            for (int i = 0; i < buff.GetLength(0); i++)
            {
                for (int j = 0; j < buff.GetLength(1); j++)
                {
                    buff[i, j] = ' ';
                }
            }

        }

        /*
         *  Вывод содержимого буфера на экран. 
         */
        public void Display()
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
        public void Draw(Rect rect)
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
        public void Draw(RectangleList rectlst)
        {
            Console.Clear();
            for (int k = 0; k < rectlst.count; k++)
            {
                Rect rect = rectlst[k];
                for (int i = rect.y; i < rect.y + rect.height && i < buff.GetLength(0); i++)
                {
                    for (int j = rect.x; j < rect.x + rect.width && j < buff.GetLength(1); j++)
                    {
                        buff[i, j] = rect.color;
                    }
                }
            }
        }
    }

}