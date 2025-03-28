using Raylib_cs;
using System.Collections.Generic;

class GameManager
{
    public const int SCREEN_WIDTH = 800;
    public const int SCREEN_HEIGHT = 600;
    private string _title;
    private List<GameObject> _gameObjects = new List<GameObject>();
    private Player _player;

    public GameManager()
    {
        _title = "CSE 210 Game";
        _player = new Player(SCREEN_WIDTH / 2, SCREEN_HEIGHT - 50);
        _gameObjects.Add(_player);
        _gameObjects.Add(new Bomb(100, 100));
        _gameObjects.Add(new Points(300, 200, "Gold"));
    }

    private void InitializeGame()
    {
        _player = new Player(SCREEN_WIDTH / 2, SCREEN_HEIGHT - 50);
        _gameObjects.Add(_player);
        _gameObjects.Add(new Bomb(100, 100));
        _gameObjects.Add(new Points(300, 200, "Gold"));
    }

    public void Run()
    {
        Raylib.SetTargetFPS(60);
        Raylib.InitWindow(SCREEN_WIDTH, SCREEN_HEIGHT, _title);

        while (!Raylib.WindowShouldClose())
        {
            HandleInput();
            ProcessActions();
            HandleCollisions();

            Raylib.BeginDrawing();
            Raylib.ClearBackground(Color.White);
            DrawElements();
            Raylib.EndDrawing();
        }

        Raylib.CloseWindow();
    }

    private void HandleInput()
    {
        _player.Move();
    }

    private void ProcessActions()
    {
        for (int i = _gameObjects.Count - 1; i >= 0; i--)
        {
            var obj = _gameObjects[i];
            if (obj is FallingElement falling)
            {
                falling.Move();
                if (!falling.isOnScreen())
                {
                    _gameObjects.Remove(obj);
                }
            }
        }
    }

    private void HandleCollisions()
    {
        for (int i = _gameObjects.Count - 1; i >= 0; i--) // Iterate backwards to safely remove items
        {
            var obj = _gameObjects[i];
            if (obj is FallingElement falling && _player.CheckCollision(falling))
            {
                _player.CollideWith(falling);
                _gameObjects.Remove(obj); // Remove the object after collision
            }
        }
    }

    private void DrawElements()
    {
        foreach (GameObject item in _gameObjects)
        {
            item.Draw();
        }
    }
}
