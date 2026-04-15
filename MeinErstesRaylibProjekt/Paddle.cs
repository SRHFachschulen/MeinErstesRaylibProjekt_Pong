using System.Numerics;
using Raylib_cs;

namespace MeinErstesRaylibProjekt;

public class Paddle : GameObject{
    private Vector2 Bounds = new(40, 120);
    private int PlayerNo;
    private Color Color;

    public Paddle(float xPos, int playerNo, Color color){
        Position.X = xPos;
        PlayerNo = playerNo;
        Color = color;
        Position.Y = Raylib.GetScreenCenter().Y - Bounds.Y / 2; 
    }

    public Rectangle Hitbox(){
        return new(Position, Bounds);
    }
    
    public override void Update(){
        KeyboardKey UpKey;
        KeyboardKey DownKey;
        if (PlayerNo == 1){
            UpKey = KeyboardKey.W;
            DownKey = KeyboardKey.S;
        }
        else{
            UpKey = KeyboardKey.Kp8;
            DownKey = KeyboardKey.Kp2;
        }

        if (Raylib.IsKeyDown(UpKey)){
            Position.Y -= 6;
        }
        if (Raylib.IsKeyDown(DownKey)){
            Position.Y += 6;
        }

        if (Position.Y < 0){
            Position.Y = 0;
        }
        if (Position.Y + Bounds.Y > Raylib.GetScreenHeight()){
            Position.Y = Raylib.GetScreenHeight() - Bounds.Y;
        }
    }
    public override void Draw(){
        Raylib.DrawRectangleV(Position,Bounds, Color);
    }
}