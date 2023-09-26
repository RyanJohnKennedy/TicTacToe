using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FSM_AI : IPlayable
{
    private Tile team;
    private Tile eTeam;

    public BoardState MakeMove(BoardState boardState, Vector2Int move)
    {
        if (team == Tile.CROSS)
        {
            eTeam = Tile.NOUGHT;
        }
        else
        {
            eTeam = Tile.CROSS;
        }

        if (CheckWinState(boardState).x >= 0)
        {
            boardState.Board[CheckWinState(boardState).x, CheckWinState(boardState).y] = team;
        }
        else if (CheckLoseState(boardState).x >= 0)
        {
            boardState.Board[CheckLoseState(boardState).x, CheckLoseState(boardState).y] = team;
        }
        else if (boardState.Board[1,1] == Tile.EMPTY)
        {
            boardState.Board[1, 1] = team;
        }
        else if(boardState.Board[0, 0] == Tile.EMPTY)
        {
            boardState.Board[0, 0] = team;
        }
        else if(boardState.Board[0, 2] == Tile.EMPTY)
        {
            boardState.Board[0, 2] = team;
        }
        else if(boardState.Board[2, 0] == Tile.EMPTY)
        {
            boardState.Board[2, 0] = team;
        }
        else if(boardState.Board[2, 2] == Tile.EMPTY)
        {
            boardState.Board[2, 2] = team;
        }
        else if(boardState.Board[0, 1] == Tile.EMPTY)
        {
            boardState.Board[0, 1] = team;
        }
        else if (boardState.Board[1, 0] == Tile.EMPTY)
        {
            boardState.Board[1, 0] = team;
        }
        else if (boardState.Board[1, 2] == Tile.EMPTY)
        {
            boardState.Board[1, 2] = team;
        }
        else if (boardState.Board[2, 1] == Tile.EMPTY)
        {
            boardState.Board[2, 1] = team;
        }

        return boardState;
    }

    Vector2Int CheckWinState(BoardState board)
    {
        //Check colomns
        for (int x = 0; x < board.Width; x++)
        {
            if (board.Board[x, 0] == board.Board[x, 1] && board.Board[x, 0] == team)
            {
                if(board.Board[x, 2] == Tile.EMPTY)
                    return new Vector2Int(x, 2);
            }
            
            if (board.Board[x, 1] == board.Board[x, 2] && board.Board[x, 1] == team)
            {
                if (board.Board[x, 0] == Tile.EMPTY)
                    return new Vector2Int(x, 0);
            }
            
            if (board.Board[x, 0] == board.Board[x, 2] && board.Board[x, 0] == team)
            {
                if (board.Board[x, 1] == Tile.EMPTY)
                    return new Vector2Int(x, 1);
            }
        }

        //Check Rows
        for (int y = 0; y < board.Height; y++)
        {
            if (board.Board[0, y] == board.Board[1, y] && board.Board[0, y] == team)
            {
                if (board.Board[2, y] == Tile.EMPTY)
                    return new Vector2Int(2, y);
            }
            else if (board.Board[1, y] == board.Board[2, y] && board.Board[1, y] == team)
            {
                if (board.Board[0, y] == Tile.EMPTY)
                    return new Vector2Int(0, y);
            }
            else if (board.Board[0, y] == board.Board[2, y] && board.Board[0, y] == team)
            {
                if (board.Board[1, y] == Tile.EMPTY)
                    return new Vector2Int(1, y);
            }
        }

        //Check Diagonals
        if (board.Board[0, 0] == board.Board[1, 1] && board.Board[0, 0] == team)
        {
            if (board.Board[2, 2] == Tile.EMPTY)
                return new Vector2Int(2, 2);
        }
        else if (board.Board[1, 1] == board.Board[2, 2] && board.Board[1, 1] == team)
        {
            if (board.Board[0, 0] == Tile.EMPTY)
                return new Vector2Int(0, 0);
        }
        else if (board.Board[0, 0] == board.Board[2, 2] && board.Board[0, 0] == team)
        {
            if (board.Board[1, 1] == Tile.EMPTY)
                return new Vector2Int(1, 1);
        }

        if (board.Board[0, 2] == board.Board[1, 1] && board.Board[0, 2] == team)
        {
            if (board.Board[2, 0] == Tile.EMPTY)
                return new Vector2Int(2, 0);
        }
        else if (board.Board[1, 1] == board.Board[0, 2] && board.Board[1, 1] == team)
        {
            if (board.Board[2, 0] == Tile.EMPTY)
                return new Vector2Int(2, 0);
        }
        else if (board.Board[2, 0] == board.Board[0, 2] && board.Board[2, 0] == team)
        {
            if (board.Board[1, 1] == Tile.EMPTY)
                return new Vector2Int(1, 1);
        }

        return new Vector2Int(-1, -1);
    }

    Vector2Int CheckLoseState(BoardState board)
    {
        //Check colomns
        for (int x = 0; x < board.Width; x++)
        {
            if (board.Board[x, 0] == board.Board[x, 1] && board.Board[x, 0] == eTeam)
            {
                if (board.Board[x, 2] == Tile.EMPTY)
                    return new Vector2Int(x, 2);
            }

            if (board.Board[x, 1] == board.Board[x, 2] && board.Board[x, 1] == eTeam)
            {
                if (board.Board[x, 0] == Tile.EMPTY)
                    return new Vector2Int(x, 0);
            }

            if (board.Board[x, 0] == board.Board[x, 2] && board.Board[x, 0] == eTeam)
            {
                if (board.Board[x, 1] == Tile.EMPTY)
                    return new Vector2Int(x, 1);
            }
        }

        //Check Rows
        for (int y = 0; y < board.Height; y++)
        {
            if (board.Board[0, y] == board.Board[1, y] && board.Board[0, y] == eTeam)
            {
                if (board.Board[2, y] == Tile.EMPTY)
                    return new Vector2Int(2, y);
            }
            else if (board.Board[1, y] == board.Board[2, y] && board.Board[1, y] == eTeam)
            {
                if (board.Board[0, y] == Tile.EMPTY)
                    return new Vector2Int(0, y);
            }
            else if (board.Board[0, y] == board.Board[2, y] && board.Board[0, y] == eTeam)
            {
                if (board.Board[1, y] == Tile.EMPTY)
                    return new Vector2Int(1, y);
            }
        }

        //Check Diagonals
        if (board.Board[0, 0] == board.Board[1, 1] && board.Board[0, 0] == eTeam)
        {
            if (board.Board[2, 2] == Tile.EMPTY)
                return new Vector2Int(2, 2);
        }
        else if (board.Board[1, 1] == board.Board[2, 2] && board.Board[1, 1] == eTeam)
        {
            if (board.Board[0, 0] == Tile.EMPTY)
                return new Vector2Int(0, 0);
        }
        else if (board.Board[0, 0] == board.Board[2, 2] && board.Board[0, 0] == eTeam)
        {
            if (board.Board[1, 1] == Tile.EMPTY)
                return new Vector2Int(1, 1);
        }

        if (board.Board[0, 2] == board.Board[1, 1] && board.Board[0, 2] == eTeam)
        {
            if (board.Board[2, 0] == Tile.EMPTY)
                return new Vector2Int(2, 0);
        }
        else if (board.Board[1, 1] == board.Board[0, 2] && board.Board[1, 1] == eTeam)
        {
            if (board.Board[2, 0] == Tile.EMPTY)
                return new Vector2Int(2, 0);
        }
        else if (board.Board[2, 0] == board.Board[0, 2] && board.Board[2, 0] == eTeam)
        {
            if (board.Board[1, 1] == Tile.EMPTY)
                return new Vector2Int(1, 1);
        }

        return new Vector2Int(-1, -1);
    }

    public void SetTeam(Tile t)
    {
        team = t;
    }
}
