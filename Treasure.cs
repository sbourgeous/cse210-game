using Raylib_cs;

class Points : FallingElement
{
    public string _pointType;

    public Points(int x, int y, string pointType) : base(x, y, Color.Gold, 20, 20, 2)
    {
        _pointType = pointType;
    }

    public override void Draw()
    {
        Raylib.DrawRectangle(_x, _y, _width, _height, _color);
    }
}