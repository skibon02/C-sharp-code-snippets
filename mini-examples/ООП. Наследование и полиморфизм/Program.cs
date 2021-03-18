using System;

/*
 * Абстрактный класс для любой геометрической фигуры.
 */
abstract class Figure
{
    public int x, y;
    public abstract int Area();
}
class Square : Figure
{
    public int width;

    public override int Area() // при наследовании от абстрактного класса необходимо определить все неопределённые методы
    {
        return width * width;
    }
    public Square(int _x, int _y, int _width)
    {
        x = _x;
        y = _y;
        width = _width;
    }
}

class Rectangle : Square
{
    public int height;

    new public int Area()   // для правильного поведения при работе с прямоугольником как с квадратом, необходимо записать не override, а new
    {
        return width * height;
    }
    public Rectangle(int _x, int _y, int _width, int _height) : base(_x, _y, _width)
    {
        height = _height;
    }
}

class Program
{
    static void Main()
    {
        Rectangle rect = new Rectangle(3, 3, 10, 12);
        Console.WriteLine("Площадь прямоугольника {0}x{1}: \t{2}", rect.width, rect.height, rect.Area());

        Square square = rect; //работа с прямоугольником как с квадратом (свойство height теперь не учитывается, и меняется метод Area)
        Console.WriteLine("Площадь квадрата {0}x{0}: \t{1}", square.width, square.Area());
        Console.WriteLine("-------------------");

        //Вот так теперь можно пользоваться абстрактным классом
        Figure[] figures = new Figure[2] { rect, new Square(1,2, 5) };
        int i = 0;
        foreach( Figure fig in figures)
        {
            Console.WriteLine("Figures[{0}] это {1}", i,  fig is Rectangle ? "прямоугольник" : "квадрат");
            i++;
        }
        Console.Read();
    }
}