using System;
using Framework.Engine;
public class PlayScene : Scene
{
    private const int BoardSize = 4;
    // 한 칸 크기
    private const int CellWidth = 8;
    private const int CellHeight = 4;

    public override void Draw(ScreenBuffer buffer)
    {
        buffer.WriteTextCentered(2, "2048", ConsoleColor.Yellow);
        DrawBoard(buffer);
    }

    public override void Load()
    {
    }

    public override void Unload()
    {
    }

    public override void Update(float deltaTime)
    {
    }
    private void DrawBoard(ScreenBuffer buffer)
    {
    
        int boardWidth = CellWidth * BoardSize;   
        int boardHeight = CellHeight * BoardSize; 

        //  가운데 정렬 시작 위치 계산
        int startX = (buffer.Width - boardWidth) / 2;
        int startY = (buffer.Height - boardHeight) / 2;


        // 보드 외곽 테두리

        buffer.DrawBox(startX - 1, startY - 1,
                       boardWidth + 2, boardHeight + 2,
                       ConsoleColor.White);

       
        // 4x4 칸 생성
       
        for (int row = 0; row < BoardSize; row++)
        {
            for (int col = 0; col < BoardSize; col++)
            {
                int x = startX + col * CellWidth;
                int y = startY + row * CellHeight;

                buffer.DrawBox(x, y, CellWidth, CellHeight, ConsoleColor.DarkYellow);
            }
        }
    }
}