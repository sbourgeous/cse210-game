using Raylib_cs;

abstract class GameObject
{
    protected int _x;
    protected int _y;
    protected Color _color;
    protected int _width;
    protected int _height;

    public GameObject(int x, int y, Color color, int width, int height)
    {
        _x = x;
        _y = y;
        _color = color;
        _width = width;
        _height = height;
    }

    public virtual void Draw() { }
    public virtual void Move() { }

    public bool isAlive() { return _y < GameManager.SCREEN_HEIGHT; }
    public void unalive() { _y = GameManager.SCREEN_HEIGHT + 1; }

    public int GetX() { return _x; }
    public int GetY() { return _y; }
    public int GetWidth() { return _width; }
    public int GetHeight() { return _height; }
}
