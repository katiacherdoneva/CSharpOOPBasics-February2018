public class Rectangle
{
    private string id;
    private double width;
    private double height;
    private double y;
    private double x;

    public Rectangle(string id, double width,
                    double height, double x,
                    double y)
    {
        ID = id;
        Width = width;
        Height = height;
        Y = y;
        X = x;
    }

    public string ID
    {
        get { return id; }
        set { id = value; }
    }

    public double Width
    {
        get { return width; }
        set { width = value; }
    }


    public double Height
    {
        get { return height; }
        set { height = value; }
    }

    public double X
    {
        get { return x; }
        set { x = value; }
    }

    public double Y
    {
        get { return y; }
        set { y = value; }
    }

    public string Intersects(Rectangle rectangle)
    {
        if (rectangle.Y >= Y && rectangle.Y - rectangle.Height <= Y && rectangle.X <= X && rectangle.X + rectangle.Width >= X)
        {
            return "true";
        }
        else if (rectangle.Y >= Y && rectangle.Y - rectangle.Height <= Y && rectangle.X >= X && rectangle.X <= X + Width)
        {
            return "true";
        }
        else if (rectangle.Y <= Y && rectangle.Y >= Y - Height && rectangle.X <= X && rectangle.X + rectangle.Width >= X)
        {
            return "true";
        }
        else if (rectangle.Y <= Y && rectangle.Y >= Y - Height && rectangle.X >= X && rectangle.X <= X + Width)
        {
            return "true";
        }
        return "false";
    }
}

