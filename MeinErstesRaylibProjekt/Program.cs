
using Raylib_cs;


namespace MeinErstesRaylibProjekt;

class Program{
    static void Main(string[] args){
        Raylib.InitWindow(800,600, "Mein erstes Fenster! :)");
        Raylib.SetTargetFPS(60);
        int Score1 = 0;
        int Score2 = 0;
        

        List<GameObject> gameObjects = new();
        gameObjects.Add(new DVDLogo());
        Paddle SpielerEins = new(40, 1, Color.Red);
        gameObjects.Add(SpielerEins);
        Paddle SpielerZwei = new(Raylib.GetScreenWidth() - 40 - 40,2, Color.Blue);
        gameObjects.Add(SpielerZwei);
        Ball SpielBall = new Ball();
        gameObjects.Add(SpielBall);
        
        
        while (!Raylib.WindowShouldClose()){
            // LOGIK
            for (int i = 0; i < gameObjects.Count; i++){
                gameObjects[i].Update();
            }

            if (SpielBall.Position.X > Raylib.GetScreenWidth()){
                Score1++;
                SpielBall.Position = Raylib.GetScreenCenter();
            }
            if (SpielBall.Position.X < 0){
                Score2++;
                SpielBall.Position = Raylib.GetScreenCenter();
            }

            if (Raylib.CheckCollisionCircleRec(SpielBall.Position, SpielBall.Radius, SpielerEins.Hitbox())){
                SpielBall.BounceOffPlayer();
            }
            if (Raylib.CheckCollisionCircleRec(SpielBall.Position, SpielBall.Radius, SpielerZwei.Hitbox())){
                SpielBall.BounceOffPlayer();
            }
            
            // ZEICHNEN
            Raylib.BeginDrawing();
            Raylib.ClearBackground(Color.Black);
            //Raylib.GetColor(0xffffffff);

            for (int i = 0; i < gameObjects.Count; i++){
                gameObjects[i].Draw();
            }
            Raylib.DrawFPS(0,0);
            Raylib.DrawText(Score1.ToString(),0,0,80,Color.White);
            Raylib.DrawText(Score2.ToString(),720,0,80,Color.White);
            Raylib.EndDrawing();
        }
        
        
        Raylib.CloseWindow();
    }
}