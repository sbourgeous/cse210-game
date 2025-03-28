using Raylib_cs;

class Bomb : FallingElement
{
    public Bomb(int x, int y) : base(x, y, Color.Red, 20, 20, 3)
    {
    }

    public override void Draw()
    {
        Raylib.DrawCircle(_x, _y, 10, _color);
    }
}
