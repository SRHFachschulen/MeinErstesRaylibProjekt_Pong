
using System.Numerics;
using Raylib_cs;

namespace MeinErstesRaylibProjekt;

public class DVDLogo : GameObject{
    
    private Vector2 Velocity;
    //private float Radius = 20; // <- Freie Wahl, damit wir bestätigen können, dass es funktioniert.
    private Color Color;
    private Vector2 Bounds;
    private Texture2D Texture = Raylib.LoadTexture("DVD_logo.svg.png");

    public DVDLogo(){
        Position = Raylib.GetScreenCenter();
        Velocity = Vector2.One;
        Bounds.X = 960 / 8; 
        Bounds.Y = 423 / 8;
        SwapColor();
        
    }
    
    public override void Update(){
        Position += Velocity;
        if (Position.X + Bounds.X >= Raylib.GetScreenWidth()){
            Velocity.X = -1;
            SwapColor();
        }
        if (Position.X<= 0){
            Velocity.X = 1;
            SwapColor();
        }
        if (Position.Y + Bounds.Y >= Raylib.GetScreenHeight()){
            Velocity.Y = -1;
            SwapColor();
        }
        if (Position.Y <= 0){
            Velocity.Y = 1;
            SwapColor();
        }
    }
    public override void Draw(){
        //Raylib.DrawCircleV(Position, Radius, Color);
        //Raylib.DrawRectangleV(Position,Bounds,Color);
        Raylib.DrawTexturePro(
            Texture,
            new Rectangle(0,0,Texture.Width,Texture.Height),
            new Rectangle(Position, Bounds),
            Vector2.Zero,
            0,
            Color);
    }

    void SwapColor(){
        Random rnd = new();
        Color = Raylib.ColorFromHSV(rnd.NextSingle() * 360, 1, 1);
    }
}