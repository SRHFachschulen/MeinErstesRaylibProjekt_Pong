using System.Numerics;
using Raylib_cs;

namespace MeinErstesRaylibProjekt;

public class Ball : GameObject{
    private Vector2 Velocity;
    public float Radius = 20;

    public Ball(){
        Position = Raylib.GetScreenCenter();
        Velocity = Vector2.One * 4;
        
    }
    
    public override void Update(){
        Position += Velocity;
        if (Position.Y - Radius < 0){
            Velocity.Y *= -1;
        }

        if (Position.Y + Radius > Raylib.GetScreenHeight()){
            Velocity.Y *= -1;
        }
    }
    public override void Draw(){
        Raylib.DrawCircleV(Position,Radius,Color.White);
    }

    public void BounceOffPlayer(){
        Velocity.X *= -1.01f;
    }
}