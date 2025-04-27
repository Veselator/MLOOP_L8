using System.Collections;
using System.Drawing;

namespace MLOOP_L8
{
    // Приклад класу для демонстрації роботи делегатів
    public class Window
    {
        private string? title;
        private Point position;
        private Point size;

        public int X 
        { 
            get
            {
                return position.X;
            } 
        }

        public int Y
        {
            get
            {
                return position.Y;
            }
        }

        public int Width
        {
            get
            {
                return size.X;
            }
        }

        public int Height
        {
            get
            {
                return size.Y;
            }
        }

        public string? Title
        {
            get
            {
                return title;
            }
            set
            {
                if (value is null) return;
                if (value.Length > 70) return;
                title = value;
            }
        }

        public Window(string title, int x, int y, int width, int height)
        {
            this.title = title;
            position = new Point(x, y);
            size = new Point(width, height);
        }

        public Window(string title, int width, int height)
        {
            this.title = title;
            position = new Point(0, 0);
            size = new Point(width, height);
        }

        public Window(string title)
        {
            this.title = title;
            position = new Point(0, 0);
            size = new Point(800, 600);
        }

        public Window()
        {
            this.title = "TITLE";
            position = new Point(100, 100);
            size = new Point(800, 600);
        }

        public override string ToString()
        {
            return $"Window {title} at position {position} with size {size}";
        }

        public override int GetHashCode()
        {
            return ToString().GetHashCode();
        }

        public override bool Equals(object? obj)
        {
            if (obj is null) return false;
            if (obj is not Window) return false;
            return GetHashCode() == obj.GetHashCode();
        }
    }
}
