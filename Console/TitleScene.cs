using System;
using Framework.Engine;
public class TitleScene : Scene
{
    public event GameAction StartRequested;
    public override void Load()
    {
    }

    public override void Unload()
    {
    }

    public override void Update(float deltaTime)
    {
        if (Input.IsKeyDown(ConsoleKey.Enter))
        {
            StartRequested?.Invoke();
        }
   
    }
    public override void Draw(ScreenBuffer buffer)
    {  
        buffer.DrawBox(5, 2, 50, 24, ConsoleColor.DarkYellow);

       
        buffer.WriteTextCentered(5, " 2222   000   4  4   8888", ConsoleColor.Yellow);
        buffer.WriteTextCentered(6, "    2  0   0  4  4  8    8", ConsoleColor.Yellow);
        buffer.WriteTextCentered(7, " 222   0   0  4444   8888", ConsoleColor.Yellow);
        buffer.WriteTextCentered(8, "2      0   0     4  8    8", ConsoleColor.Yellow);
        buffer.WriteTextCentered(9, "2222    000      4   8888", ConsoleColor.Yellow);

        buffer.WriteTextCentered(12, "C O N S O L E   2 0 4 8", ConsoleColor.DarkGray);

        buffer.WriteTextCentered(15, "Arrow Key : Move Tiles", ConsoleColor.White);
        buffer.WriteTextCentered(16, "Merge Same Numbers", ConsoleColor.White);
        buffer.WriteTextCentered(17, "Make 2048 to Win!", ConsoleColor.White);

        if (DateTime.Now.Second % 2 == 0)
        {
            buffer.WriteTextCentered(20, ">> PRESS ENTER TO START <<", ConsoleColor.Green);
        }

        buffer.WriteTextCentered(22, "ESC : Quit Game", ConsoleColor.Red);
    }
 }