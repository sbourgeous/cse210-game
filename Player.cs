using Raylib_cs;

class Player : GameObject
{
    private int _speed = 5;
    private int _lives = 3;
    private int _points = 0;

    public Player(int x, int y) : base(x, y, Color.Blue, 50, 10)
    {
    }

    public override void Move()
    {
        if (Raylib.IsKeyDown(KeyboardKey.Left) && _x > 0) _x -= _speed;
        if (Raylib.IsKeyDown(KeyboardKey.Right) && _x < GameManager.SCREEN_WIDTH - _width) _x += _speed;
    }

    public void CollideWith(GameObject other)
    {
        if (other is Bomb)
        {
            _lives--;
            if (_lives <= 0)
            {
                Raylib.CloseWindow();
            }
        }
        else if (other is Points)
        {
            _points++;
        }
    }

    public override void Draw()
    {
        Raylib.DrawRectangle(_x, _y, _width, _height, _color);
    }

    public bool CheckCollision(GameObject other)
    {
        Rectangle playerRect = new Rectangle(GetX(), GetY(), GetWidth(), GetHeight());
        Rectangle otherRect = new Rectangle(other.GetX(), other.GetY(), other.GetWidth(), other.GetHeight());
        return Raylib.CheckCollisionRecs(playerRect, otherRect);
    }
}
