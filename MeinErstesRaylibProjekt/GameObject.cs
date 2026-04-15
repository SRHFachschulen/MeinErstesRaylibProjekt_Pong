using System.Numerics;

namespace MeinErstesRaylibProjekt;

public abstract class GameObject{
    public Vector2 Position;
    public abstract void Update();
    public abstract void Draw();
}