using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Framework.Engine;
public class PlayScene : Scene
{
    public event GameAction TitleRequested;
    private const int BoardSize = 4;
    private readonly int[,] board = new int[BoardSize,BoardSize];

    int CellWidth = 8;
    int CellHeight = 4;

    private bool IsMove;
    private bool IsGameOver;
    private bool IsClear;

    Random rand = new Random(); 
    public override void Load()
    {
        SpawnTile();
        SpawnTile();
       

        // Clear 테스트용
        //board[0, 0] = 1024;
        //board[0, 1] = 1024;

    }

    public override void Unload()
    {
    }

    public override void Update(float deltaTime)
    {
        if (IsClear || IsGameOver)
        {
            if (Input.IsKeyDown(ConsoleKey.Enter))
            {
                TitleRequested?.Invoke();
            }
            return;
        }
       
        if (Input.IsKeyDown(ConsoleKey.LeftArrow))
        {
            MoveLeft();
            if (IsMove)
            {
                SpawnTile();
            }
        }
        else if (Input.IsKeyDown(ConsoleKey.RightArrow))
        {
            MoveRight();
            if (IsMove)
            {
                SpawnTile();
            }
        }
        else if (Input.IsKeyDown(ConsoleKey.UpArrow))
        {
            MoveUp();
            if (IsMove)
            {
                SpawnTile();
            }
        }
        else if (Input.IsKeyDown(ConsoleKey.DownArrow))
        {
            MoveDown();
            if (IsMove)
            {
                SpawnTile();
            }
        }
        IsClear = CheckClear();
        IsGameOver = CheckGameOver();
    }

    //왼쪽 이동
    private void MoveLeft()
    {
        IsMove = false;
        // 왼쪽으로 밀기
        for (int row = 0; row < BoardSize; row++)
        {
            int targetcol = 0;
            int[] number = new int[BoardSize];

            for (int col = 0; col < BoardSize; col++)
            {
                if (board[row, col] != 0)
                {
                    number[targetcol] = board[row, col];
                    targetcol++;
                }
            }
            for (int col = 0; col < BoardSize; col++)
            {
                if (board[row, col] != number[col])
                { 
                    IsMove = true;
                }
                board[row, col] = number[col];
            }
        }
        // 합치기
        for (int row = 0; row < BoardSize; row++)
        {
            for (int col = 0; col < BoardSize - 1; col++)
            {
                if (board[row, col] != 0 && board[row, col] == board[row, col + 1])
                {
                    board[row, col] *= 2;
                    board[row, col + 1] = 0;
                    IsMove = true;
                }
            }
        }
        // 한번더 밀기
        for (int row = 0; row < BoardSize; row++)
        {
            int targetcol = 0;
            int[] number = new int[BoardSize];

            for (int col = 0; col < BoardSize; col++)
            {
                if (board[row, col] != 0)
                {
                    number[targetcol] = board[row, col];
                    targetcol++;
                }
            }
            for (int col = 0; col < BoardSize; col++)
            {
                if (board[row, col] != number[col])
                {
                    IsMove = true;
                }
                board[row, col] = number[col];
            }
        }
    }
    //오른쪽 이동
    private void MoveRight()
    {
        IsMove = false;
        //밀기
        for (int row = 0; row < BoardSize; row++)
        {
            int targetCol = BoardSize - 1; 
            int[] number = new int[BoardSize];
            
            for (int col = BoardSize - 1; col >= 0; col--)
            {
                if (board[row, col] != 0)
                {
                    number[targetCol] = board[row, col];
                    targetCol--; 
                }
            }
            for (int col = 0; col < BoardSize; col++)
            {
                if (board[row, col] != number[col])
                { 
                    IsMove = true;
                }
                board[row, col] = number[col];
            }
        }

        //합치기
        for (int row = 0; row < BoardSize; row++)
        {
            for (int col = BoardSize - 1; col > 0; col--)
            {
                if (board[row, col] != 0 && board[row, col] == board[row, col - 1])
                {
                    board[row, col] *= 2;
                    board[row, col - 1] = 0;
                    IsMove = true;
                }
            }
        }
        //밀기
        for (int row = 0; row < BoardSize; row++)
        {
            int targetCol = BoardSize - 1;
            int[] number = new int[BoardSize];

            for (int col = BoardSize - 1; col >= 0; col--)
            {
                if (board[row, col] != 0)
                {
                    number[targetCol] = board[row, col];
                    targetCol--;
                }
            }
            for (int col = 0; col < BoardSize; col++)
            {
                if (board[row, col] != number[col])
                {
                    IsMove = true;
                }
                board[row, col] = number[col];
            }
        }
    }
    //위로 이동
    private void MoveUp()
    {
        IsMove = false;
        //밀기
        for (int col = 0; col < BoardSize; col++)
        {
            int targetRow = 0;
            int[] number = new int[BoardSize];

            for (int row = 0; row < BoardSize; row++)
            {
                if (board[row, col] != 0)
                {
                    number[targetRow] = board[row, col];
                    targetRow++;
                }
            }
            for (int row = 0; row < BoardSize; row++)
            {
                if (board[row, col] != number[row])
                {
                    IsMove = true;
                }
                board[row, col] = number[row];
            }
        }
        //합치기
        for (int col = 0; col < BoardSize; col++)
        {
            for (int row = 0; row < BoardSize - 1; row++)
            {
                if (board[row, col] != 0 && board[row, col] == board[row + 1, col])
                {
                    board[row, col] *= 2;
                    board[row + 1, col] = 0;
                    IsMove = true;
                }
            }
        }
        //밀기
        for (int col = 0; col < BoardSize; col++)
        {
            int targetRow = 0;
            int[] number = new int[BoardSize];

            for (int row = 0; row < BoardSize; row++)
            {
                if (board[row, col] != 0)
                {
                    number[targetRow] = board[row, col];
                    targetRow++;
                }
            }
            for (int row = 0; row < BoardSize; row++)
            {
                if (board[row, col] != number[row])
                {
                    IsMove = true;
                }
                board[row, col] = number[row];
            }
        }
    }
    //아래로 이동
    private void MoveDown()
    {
        IsMove = false;
        //밀기
        for (int col = 0; col < BoardSize; col++)
        {
            int targetRow = BoardSize - 1;
            int[] number = new int[BoardSize];

            for (int row = BoardSize - 1; row >= 0; row--)
            {
                if (board[row, col] != 0)
                {
                    number[targetRow] = board[row, col];
                    targetRow--;
                }
            }
            for (int row = 0; row < BoardSize; row++)
            {
                if (board[row, col] != number[row])
                {
                    IsMove = true;
                }
                board[row, col] = number[row];
            }
        }
        //합치기
        for (int col = 0; col < BoardSize; col++)
        {
            for (int row = BoardSize - 1; row > 0; row--)
            {
                if (board[row, col] != 0 && board[row, col] == board[row - 1, col])
                {
                    board[row, col] *= 2;
                    board[row - 1, col] = 0;
                    IsMove = true;
                }
            }
        }
        //밀기
        for (int col = 0; col < BoardSize; col++)
        {
            int targetRow = BoardSize - 1;
            int[] number = new int[BoardSize];

            for (int row = BoardSize - 1; row >= 0; row--)
            {
                if (board[row, col] != 0)
                {
                    number[targetRow] = board[row, col];
                    targetRow--;
                }
            }
            for (int row = 0; row < BoardSize; row++)
            {
                if (board[row, col] != number[row])
                {
                    IsMove = true;
                }
                board[row, col] = number[row];
            }
        }
    }

    //클리어 조건
    private bool CheckClear()
    {
        for (int row = 0; row < BoardSize; row++)
        {
            for (int col = 0; col < BoardSize; col++)
            {
                if (board[row, col] == 2048)
                { 
                    return true;
                }
            }

        }
        return false;
    }
    //게임 오버 조건
    private bool CheckGameOver()
    {
        // 빈칸이 있으면 false
        for (int row = 0; row < BoardSize ; row++)
        {
            for (int col = 0; col < BoardSize; col++)
            {
                if (board[row, col] == 0)
                {
                    return false;
                }
            }
        }
        //가로 같은 숫자면 false
        for (int row = 0; row < BoardSize; row++)
        {
            for (int col = 0; col < BoardSize-1; col++)
            {
                if (board[row, col] == board[row, col + 1])
                {
                    return false;
                }
            }
        }
        //세로 같은 숫자면 false
        for (int row = 0; row < BoardSize - 1; row++)
        {
            for (int col = 0; col < BoardSize  ; col++)
            {
                if (board[row, col] == board[row + 1, col])
                {
                    return false;
                }
            }
        }
        return true;
    }
    private (int row, int col) GetRandomEmptyCell()
    {
        List<(int row, int col)> empty = new List<(int row, int col)>();

        for (int r = 0; r < BoardSize; r++)
        {
            for (int c = 0; c < BoardSize; c++)
            {
                if (board[r, c] == 0)
                {
                    empty.Add((r, c));
                }
            }
        }
        if (empty.Count == 0)
        {
            return (-1, -1);
        }
        return empty[rand.Next(empty.Count)];
    }
    private void SpawnTile()
    { 
        var (row, col) = GetRandomEmptyCell();

        if (row == -1)
        {
            return;
        }
        int value = rand.Next(10) < 9 ? 2 : 4;

        board[row, col] = value;
    }

    //숫자 색상
    private ConsoleColor GetTileColor(int value)
    {
        switch (value)
        {
            case 2: return ConsoleColor.White;
            case 4: return ConsoleColor.Cyan;
            case 8: return ConsoleColor.Green;
            case 16: return ConsoleColor.Yellow;
            case 32: return ConsoleColor.DarkYellow;
            case 64: return ConsoleColor.Red;
            case 128: return ConsoleColor.Magenta;
            case 256: return ConsoleColor.Blue;
            case 512: return ConsoleColor.DarkCyan;
            case 1024: return ConsoleColor.DarkGreen;
            case 2048: return ConsoleColor.DarkMagenta;
            default: return ConsoleColor.Gray;
        }
    }
    private void DrawBoard(ScreenBuffer buffer)
    {
        int startX = 14;
        int startY = 7;

        for (int row = 0; row < BoardSize; row++)
        {
            for (int col = 0; col < BoardSize; col++)
            {
                int x = startX + col * CellWidth;
                int y = startY + row * CellHeight;

                buffer.DrawBox(x, y, CellWidth, CellHeight, ConsoleColor.DarkYellow);

                int value = board[row, col];

                if (value != 0)
                {
                    string text = value.ToString();

                    int textX = x + (CellWidth - text.Length) / 2;
                    int textY = y + 1;

                    buffer.WriteText(textX, textY, text, GetTileColor(value));
                }
            }
        }
    }
    private void DrawResultPopup(ScreenBuffer buffer, string message, ConsoleColor color)
    {
        int boxX = 18;
        int boxY = 11;
        int boxWidth = 24;
        int boxHeight = 6;

        buffer.DrawBox(boxX, boxY, boxWidth, boxHeight, color);

        buffer.WriteTextCentered(boxY + 1, message, color);
        buffer.WriteTextCentered(boxY + 3, "ENTER : Title", ConsoleColor.White);
        buffer.WriteTextCentered(boxY + 4, "ESC : Quit", ConsoleColor.White);
    }
    public override void Draw(ScreenBuffer buffer)
    {
        // 상단 제목
        buffer.WriteTextCentered(1, "2048", ConsoleColor.Yellow);

        // 상단 짧은 설명
        buffer.WriteTextCentered(3, "Arrow Key : Move Tiles", ConsoleColor.Gray);

        // 보드 바깥 테두리
        buffer.DrawBox(12, 5, 36, 20, ConsoleColor.DarkYellow);

        // 실제 보드
        DrawBoard(buffer);

        // 하단 안내
        if (IsClear || IsGameOver)
        {
            buffer.WriteTextCentered(27, "ENTER : Title   ESC : Quit", ConsoleColor.White);
        }
        else
        {
            buffer.WriteTextCentered(27, "Merge same numbers to make 2048", ConsoleColor.DarkGray);
        }

        // 게임 종료 상태일 때만 팝업
        if (IsClear)
        {
            DrawResultPopup(buffer, "CLEAR!", ConsoleColor.Green);
        }
        else if (IsGameOver)
        {
            DrawResultPopup(buffer, "GAME OVER", ConsoleColor.Red);
        }
    }
}

