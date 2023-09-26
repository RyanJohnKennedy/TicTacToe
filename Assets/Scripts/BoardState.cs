using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum Tile
{
    NOUGHT,
    CROSS,
    EMPTY,
    DRAW
}

public class BoardState
{
    private Tile[,] board;

    public Tile[,] Board
    {
        get { return board; }
        set { board = value; }
    }

    private int width;

    public int Width
    {
        get { return width; }
        set { width = value; }
    }

    private int height;

    public int Height
    {
        get { return height; }
        set { height = value; }
    }

    public BoardState(int width, int height)
    {
        Width = width;
        Height = height;

        Board = new Tile[Width, Height];

        ClearBoard();
    }

    public void ClearBoard()
    {
        for (int x = 0; x < Width; x++)
        {
            for (int y = 0; y < Height; y++)
            {
                Board[x, y] = Tile.EMPTY;
            }
        }
    }

    public Tile Winner()
    {
        //Check for Crosses Winning

        //Check Colums
        for (int x = 0; x < Width; x++)
        {
            if(board[x,0] == board[x,1] && board[x, 1] == board[x,2])
            {
                return board[x, 0];
            }
        }

        //Check Rows
        for (int y = 0; y < Height; y++)
        {
            if (board[0, y] == board[1 , y] && board[1, y] == board[2 , y])
            {
                return board[0 , y];
            }
        }

        //Check Diagonals
        if (board[0, 0] == board[1, 1] && board[1, 1] == board[2, 2])
        {
            return board[1, 1];
        }
        if (board[2, 0] == board[1, 1] && board[1, 1] == board[0, 2])
        {
            return board[1, 1];
        }

        //CheckDraw
        int numEmpty = 0;
        for (int x = 0; x < Width; x++)
        {
            for (int y = 0; y < Height; y++)
            {
                if (Board[x, y] == Tile.EMPTY)
                {
                    numEmpty++;
                }
            }
        }

        if (numEmpty == 0)
        {
            return Tile.DRAW;
        }

        return Tile.EMPTY;
    }
}
