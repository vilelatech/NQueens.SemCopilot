namespace NQueens.SemCopilot;

public class NQueensProblem
{
    private int size = 8;
    private int[,] chessboard;

    public NQueensProblem(int size)
    {
        this.size = size;
        this.chessboard = new int[size, size];
        SolveNQueens(chessboard, 0);
        Print(this.chessboard);
    }


    private bool SolveNQueens(int[,] board, int col)
    {
        if (col >= size)
        {
            return true;
        }

        for (int i = 0; i < size; i++)
        {
            if (IsSafe(board, i, col))
            {
                board[i, col] = 1;
                if (SolveNQueens(board, col + 1))
                {
                    return true;
                }

                board[i, col] = 0;
            }
        }

        return false;
    }

    private bool IsSafe(int[,] board, int row, int col)
    {
        int i, j;

        for (i = 0; i < col; i++)
        {
            if (board[row, i] == 1)
            {
                return false;
            }
        }

        for (i = row, j = col; i >= 0 && j >= 0; i--, j--)
        {
            if (board[i, j] == 1)
            {
                return false;
            }
        }

        for (i = row, j = col; j >= 0 && i < size; i++, j--)
        {
            if (board[i, j] == 1)
            {
                return false;
            }
        }

        return true;
    }

    private void Print(int[,] board)
    {
        for (int i = 0; i < size; i++)
        {
            for (int j = 0; j < size; j++)
            {
                Console.Write(board[i, j] + " ");
            }

            Console.WriteLine();
        }
    }
}