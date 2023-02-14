using Raylib_cs;

public class Player
{
    public Position p;
    Color c;

    public Player(Color c_)
    {
        c = c_;
    }

    public void Render()
    {
        Raylib.DrawCircle(p.x, p.y, 10, c);
    }
}
