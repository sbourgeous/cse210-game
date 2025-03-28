using Raylib_cs;

class FallingElement : GameObject
{
    protected int _speed;

    public FallingElement(int x, int y, Color color, int width, int height, int speed)
        : base(x, y, color, width, height)
    {
        _speed = speed;
    }

    public override void Move()
    {
        _y += _speed;
    }

    public bool isOnScreen() { return _y < GameManager.SCREEN_HEIGHT; }
}