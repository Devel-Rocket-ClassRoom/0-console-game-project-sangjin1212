using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Framework.Engine;
public class PlayScene : Scene
{
    public event GameAction TitleRequested;
    private const int BoardSize = 4;
    private readonly int[,] board = new int[BoardSize,BoardSize];

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
    //빈칸확인
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
    //랜덤 빈칸에 숫자 넣기
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
        int startX = 4;
        int startY = 5;

        int cellWidth = 8;
        int cellHeight = 4;

        for (int row = 0; row < BoardSize; row++)
        {
            for (int col = 0; col < BoardSize; col++)
            {
                int x = startX + col * cellWidth;
                int y = startY + row * cellHeight;

                buffer.DrawBox(x, y, cellWidth, cellHeight, ConsoleColor.DarkYellow);

                int value = board[row, col];

                if (value != 0)
                {
                    string text = value.ToString();

                    int textX = x + (cellWidth - text.Length) / 2;
                    int textY = y + 1;

                    buffer.WriteText(textX, textY, text, GetTileColor(value));
                }
            }
        }
    }
    public override void Draw(ScreenBuffer buffer)
    {

        buffer.WriteTextCentered(1, "2048", ConsoleColor.Yellow);
        buffer.DrawBox(2, 3, 36, 20, ConsoleColor.DarkYellow);
        buffer.DrawBox(40, 3, 18, 10, ConsoleColor.White);
        buffer.WriteText(46, 4, "INFO", ConsoleColor.Cyan);
        if (IsClear)
        {
            buffer.WriteText(43, 7, "CLEAR!", ConsoleColor.Green);
            buffer.WriteTextCentered(28, "You made 2048! Press ENTER", ConsoleColor.Green);
        }
        else if (IsGameOver)
        {
            buffer.WriteText(41, 7, "GAME OVER", ConsoleColor.Red);
            buffer.WriteTextCentered(28, "No more moves! Press ENTER", ConsoleColor.Red);
        }
        else
        {
            buffer.WriteText(43, 7, "PLAYING", ConsoleColor.Gray);
            buffer.WriteTextCentered(28, "Use Arrow Keys to move tiles", ConsoleColor.DarkGray);
        }

        buffer.DrawBox(40, 14, 18, 10, ConsoleColor.DarkGray);
        buffer.WriteText(45, 15, "KEY", ConsoleColor.Cyan);
        buffer.WriteText(42, 17, "Arrow : Move", ConsoleColor.White);
        buffer.WriteText(42, 18, "ESC : Quit", ConsoleColor.White);
        DrawBoard(buffer);
    }
}

