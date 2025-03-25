using System.Diagnostics.Contracts;

class Treasure : GameObject
{
    public Treasure(int x, int y) : base(x, y)
    {
        
    }

    public override void Draw()
    {
        throw new NotImplementedException();
    }
}