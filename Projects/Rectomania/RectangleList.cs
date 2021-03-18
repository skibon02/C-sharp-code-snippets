using System;
using System.IO;
using System.Linq;


namespace Rectomania
{
    class RectangleList
    {
        Rect[] rects;
        public int count { get; private set; }

        public RectangleList()
        {
            Clear();
        }
        public bool AddRect(Rect rect)
        {
            if (count > 99)
            {
                Console.WriteLine("Достигнуто максимальное количество прямоугольников!");
                return false;
            }

            rects[count++] = rect;
            return true;
        }
        //индексатор (для чтения прямоугольника по индксу)
        public Rect this[int i]
        {
            get
            {
                return rects[i];
            }
        }

        public RectangleList(string filename)
        {
            Clear();
            ReadFromFile(filename);
        }

        /*
         * Функция инициализации списка прямоугольников из файла.
         * Каждая строка - отдельный прямоугольник, через пробел перечислены его параметры.
         */
        public bool ReadFromFile(string filename)
        {
            string[] lines = File.ReadAllLines(filename);

            foreach (string line in lines)
            {
                string[] values = line.Split(' ');
                if (values.Length != 4 && values.Length != 5)
                {
                    Console.WriteLine("Ошибка! Неверный формат файла!");
                    Clear();
                    return false;
                }
                for (int i = 0; i < 4; i++)
                {
                    if (!int.TryParse(values[i], out int res))
                    {
                        Console.WriteLine("Ошибка! Неверный формат значений!");
                        Clear();
                        return false;
                    }
                }

                //возможность чтения 4 или 5 значений (символ заполнения - опциональный)
                Rect rect;
                if (values.Length == 4)
                    rect = new Rect(int.Parse(values[0]), int.Parse(values[1]), int.Parse(values[2]), int.Parse(values[3]));
                else
                    rect = new Rect(int.Parse(values[0]), int.Parse(values[1]), int.Parse(values[2]), int.Parse(values[3]), values[4][0]);
                if (!AddRect(rect))
                {
                    Console.WriteLine("Ошибка! Считано только 100 первых значений!");
                    return false;
                }

            }
            return true;
        }


        public void Clear()
        {
            count = 0;
            rects = new Rect[100];
        }
    }
}