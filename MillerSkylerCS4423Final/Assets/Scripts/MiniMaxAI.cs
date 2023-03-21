//////////////////////////////////////////////////////////////////////////////////////////////
/***************************EVERYTHING HERE IS AI GENERATED STUFF****************************/
//////////////////////////////////////////////////////////////////////////////////////////////

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MinimaxAI : MonoBehaviour
{
    public int maxDepth = 3;

    public int Minimax(GameObject[,] board, int depth, int alpha, int beta, bool maximizingPlayer)
    {
        if (depth == 0 || IsTerminalNode(board))
        {
            return Evaluate(board);
        }

        if (maximizingPlayer)
        {
            int maxEval = int.MinValue;

            foreach (GameObject piece in GetPieces(board, "white"))
            {
                List<Vector2Int> moves = GetPossibleMoves(piece, board);
                foreach (Vector2Int move in moves)
                {
                    GameObject[,] newBoard = MakeMove(piece, move, board);
                    int eval = Minimax(newBoard, depth - 1, alpha, beta, false);
                    maxEval = Mathf.Max(maxEval, eval);
                    alpha = Mathf.Max(alpha, eval);
                    if (beta <= alpha)
                    {
                        break;
                    }
                }
            }

            return maxEval;
        }
        else
        {
            int minEval = int.MaxValue;

            foreach (GameObject piece in GetPieces(board, "black"))
            {
                List<Vector2Int> moves = GetPossibleMoves(piece, board);
                foreach (Vector2Int move in moves)
                {
                    GameObject[,] newBoard = MakeMove(piece, move, board);
                    int eval = Minimax(newBoard, depth - 1, alpha, beta, true);
                    minEval = Mathf.Min(minEval, eval);
                    beta = Mathf.Min(beta, eval);
                    if (beta <= alpha)
                    {
                        break;
                    }
                }
            }

            return minEval;
        }
    }

    public Vector2Int GetBestMove(GameObject[,] board)
    {
        int bestEval = int.MinValue;
        Vector2Int bestMove = Vector2Int.zero;

        foreach (GameObject piece in GetPieces(board, "white"))
        {
            List<Vector2Int> moves = GetPossibleMoves(piece, board);
            foreach (Vector2Int move in moves)
            {
                GameObject[,] newBoard = MakeMove(piece, move, board);
                int eval = Minimax(newBoard, maxDepth, int.MinValue, int.MaxValue, false);
                if (eval > bestEval)
                {
                    bestEval = eval;
                    bestMove = move;
                }
            }
        }

        return bestMove;
    }

// Check if there are no more legal moves or a player has won
// Return true if the game is over
private bool IsTerminalNode(GameObject[,] board)
{
    // Check for a win
    bool whiteWin = false;
    bool blackWin = false;
    for (int i = 0; i < 8; i++)
    {
        for (int j = 0; j < 8; j++)
        {
            GameObject piece = board[i, j];
            if (piece != null)
            {
                if (piece.name("whiteKing"))
                {
                    blackWin = true;
                }
                else if (piece.name("blackKing"))
                {
                    whiteWin = true;
                }
            }
        }
    }

    if (whiteWin || blackWin)
    {
        return true;
    }

    // Check for legal moves
    foreach (GameObject piece in GetPieces(board, "white"))
    {
        List<Vector2Int> moves = GetPossibleMoves(piece, board);
        if (moves.Count > 0)
        {
            return false;
        }
    }

    foreach (GameObject piece in GetPieces(board, "black"))
    {
        List<Vector2Int> moves = GetPossibleMoves(piece, board);
        if (moves.Count > 0)
        {
            return false;
        }
    }

    // No legal moves left
    return true;
}

// Evaluate the current board state and return a score
private int Evaluate(GameObject[,] board)
{
    // Simple evaluation function: count the number of pieces
    int whiteCount = 0;
    int blackCount = 0;
    for (int i = 0; i < 8; i++)
    {
        for (int j = 0; j < 8; j++)
        {
            GameObject piece = board[i, j];
            if (piece != null)
            {
                if (piece.GetColor() == "white")
                {
                    whiteCount++;
                }
                else if (piece.GetColor() == "black")
                {
                    blackCount++;
                }
            }
        }
    }

    return whiteCount - blackCount;
}

// Return a list of all pieces of the given color
private List<GameObject> GetPieces(GameObject[,] board, string color)
{
    List<GameObject> pieces = new List<GameObject>();
    for (int i = 0; i < 8; i++)
    {
        for (int j = 0; j < 8; j++)
        {
            GameObject piece = board[i, j];
            if (piece != null && piece.GetColor() == color)
            {
                pieces.Add(piece);
            }
        }
    }
    return pieces;
}

// Return a list of all legal moves for the given piece on the current board
private List<Vector2Int> GetPossibleMoves(GameObject piece, GameObject[,] board)
{
    List<Vector2Int> moves = new List<Vector2Int>();
    PieceController chessPiece = piece.GetComponent<PieceController>();
    for (int i = 0; i < 8; i++)
    {
        for (int j = 0; j < 8; j++)
        {
            if (chessPiece.IsLegalMove(i, j, board, piece))
            {
                moves.Add(new Vector2Int(i, j));
            }
        }
    }
    return moves;
}

    private GameObject[,] MakeMove(GameObject piece, Vector2Int move, GameObject[,] board)
    {
        // Make a copy of the current board with the given move applied
    }
}

