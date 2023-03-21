using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PieceController : MonoBehaviour
{
    public GameObject gameController;
    public GameObject movePlate;
    public GameObject selectedPlate;

    private int xBoard = -1;
    private int yBoard = -1;

    private string player;

    public Sprite blackQueen, blackKnight, blackBishop, blackKing, blackRook, blackPawn, blackPrince;
    public Sprite whiteQueen, whiteKnight, whiteBishop, whiteKing, whiteRook, whitePawn, whitePrince;

    public void Activate() {
        gameController = GameObject.FindGameObjectWithTag("GameController");

        SetCoords();

        switch (this.name) {
            case "blackQueen": this.GetComponent<SpriteRenderer>().sprite = blackQueen; player = "black"; break;
            case "blackKnight": this.GetComponent<SpriteRenderer>().sprite = blackKnight; player = "black"; break;
            case "blackBishop": this.GetComponent<SpriteRenderer>().sprite = blackBishop; player = "black"; break;
            case "blackKing": this.GetComponent<SpriteRenderer>().sprite = blackKing; player = "black"; break;
            case "blackRook": this.GetComponent<SpriteRenderer>().sprite = blackRook; player = "black"; break;
            case "blackPawn": this.GetComponent<SpriteRenderer>().sprite = blackPawn; player = "black"; break;
            case "blackPrince": this.GetComponent<SpriteRenderer>().sprite = blackPrince; player = "black"; break;
            case "whiteQueen": this.GetComponent<SpriteRenderer>().sprite = whiteQueen; player = "white"; break;
            case "whiteKnight": this.GetComponent<SpriteRenderer>().sprite = whiteKnight; player = "white"; break;
            case "whiteBishop": this.GetComponent<SpriteRenderer>().sprite = whiteBishop; player = "white"; break;
            case "whiteKing": this.GetComponent<SpriteRenderer>().sprite = whiteKing; player = "white"; break;
            case "whiteRook": this.GetComponent<SpriteRenderer>().sprite = whiteRook; player = "white"; break;
            case "whitePawn": this.GetComponent<SpriteRenderer>().sprite = whitePawn; player = "white"; break;
            case "whitePrince": this.GetComponent<SpriteRenderer>().sprite = whitePrince; player = "white"; break;
        }
    }

    public void SetCoords() {
        float x = xBoard;
        float y = yBoard;

        x += -7.5f;
        y += -3.5f;

        this.transform.position = new Vector2(x, y);
    }

    public int GetXBoard() {
        return xBoard;
    }

    public int GetYBoard() {
        return yBoard;
    }
    
    public string GetColor() {
        return player;
    }

    public void SetXBoard(int x) {
        xBoard = x;
    }

    public void SetYBoard(int y) {
        yBoard  = y;
    }

    private void OnMouseUp() {
        
        if (!gameController.GetComponent<GameController>().IsGameOver() && gameController.GetComponent<GameController>().GetCurrentPlayer() == player) {
            DestroyPlates();

            SetPieceText();
            InitiateMovePlates();
            InitiateSelectedPlate(xBoard, yBoard);
        }
        
    }

    public void DestroyPlates() {
        GameObject[] movePlates = GameObject.FindGameObjectsWithTag("MovePlate");
        GameObject[] selectedPlates = GameObject.FindGameObjectsWithTag("SelectedPlate");
        for (int i = 0; i < movePlates.Length; i++) {
            Destroy(movePlates[i]);
        }
        for (int i = 0; i < selectedPlates.Length; i++) {
            Destroy(selectedPlates[i]);
        }
    }

    public void InitiateSelectedPlate(int matrixX, int matrixY) {
        float x = matrixX;
        float y = matrixY;

        x += -7.5f;
        y += -3.5f;

        GameObject MovePlate = Instantiate(selectedPlate, new Vector2(x, y), Quaternion.identity);

        MovePlate MovePlateScript = MovePlate.GetComponent<MovePlate>();
        MovePlateScript.SetReference(gameObject);
        MovePlateScript.SetCoords(matrixX, matrixY);
    }

    public void SetPieceText()  {
        switch (this.name) {
            case "whiteQueen":
            case "blackQueen":
                gameController.GetComponent<GameController>().SetPieceNameText("Queen");
                gameController.GetComponent<GameController>().SetPieceDescriptionText("It can move as many squares as it likes left or right horizontally, or as many squares as it likes up or down vertically. It cannot jump over pieces.");
                break;
            case "whiteKnight":
            case "blackKnight":
                gameController.GetComponent<GameController>().SetPieceNameText("Knight");
                gameController.GetComponent<GameController>().SetPieceDescriptionText("The knight moves one square left or right horizontally and then two squares up or down vertically, OR it moves two squares left or right horizontally and then one square up or down vertically. It can only capture on what it lands on, not what it jumps over.");
                break;
            case "whiteBishop":
            case "blackBishop":
                gameController.GetComponent<GameController>().SetPieceNameText("Bishop");
                gameController.GetComponent<GameController>().SetPieceDescriptionText("A bishop can move diagonally as many squares as it likes, as long as it is not blocked by its own pieces or an occupied square.");
                break;
            case "whiteKing":
            case "blackKing":
                gameController.GetComponent<GameController>().SetPieceNameText("King");
                gameController.GetComponent<GameController>().SetPieceDescriptionText("The king can only move and capture in one square in any direction.");
                break;
            case "whiteRook":
            case "blackRook":
                gameController.GetComponent<GameController>().SetPieceNameText("Rook");
                gameController.GetComponent<GameController>().SetPieceDescriptionText("The rook can move as many squares as it likes left or right horizontally, or as many squares as it likes up or down vertically (as long as it isn't blocked by other pieces).");
                break;
            case "whitePawn":
            case "blackPawn":
                gameController.GetComponent<GameController>().SetPieceNameText("Pawn");
                gameController.GetComponent<GameController>().SetPieceDescriptionText("If it is a pawn's first move, it can move forward one or two squares. If a pawn has already moved, then it can move forward just one square at a time. It attacks (or captures) each square diagonally to the left or right.");
                break;
            case "whitePrince":
            case "blackPrince":
                gameController.GetComponent<GameController>().SetPieceNameText("Prince");
                gameController.GetComponent<GameController>().SetPieceDescriptionText("The prince can move up to two spaces in the horizontal and vertical directions. It is unable to jump over pieces.");
                break;
        }
    }

    public void InitiateMovePlates() {
        switch (this.name) {
            case "whiteQueen":
            case "blackQueen":
                LineMovePlate(1, 0);
                LineMovePlate(0, 1);
                LineMovePlate(1, 1);
                LineMovePlate(-1, 0);
                LineMovePlate(0, -1);
                LineMovePlate(-1, -1);
                LineMovePlate(-1, 1);
                LineMovePlate(1, -1);
                break;
            case "whiteKnight":
            case "blackKnight":
                LMovePlate();
                break;
            case "whiteBishop":
            case "blackBishop":
                LineMovePlate(1, 1);
                LineMovePlate(1, -1);
                LineMovePlate(-1, 1);
                LineMovePlate(-1, -1);
                break;
            case "whiteKing":
            case "blackKing":
                AdjacentMovePlate();
                break;
            case "whiteRook":
            case "blackRook":
                LineMovePlate(1, 0);
                LineMovePlate(0, 1);
                LineMovePlate(-1, 0);
                LineMovePlate(0, -1);
                break;
            case "whitePawn":
                PawnMovePlate(xBoard, yBoard + 1);
                break;
            case "blackPawn":
                PawnMovePlate(xBoard, yBoard - 1);
                break;
            case "whitePrince":
            case "blackPrince":
                LimitedLineMovePlate(1, 0, 2, 2, 2, 2);
                LimitedLineMovePlate(0, 1, 2, 2, 2, 2);
                LimitedLineMovePlate(1, 1, 2, 2, 2, 2);
                LimitedLineMovePlate(-1, 0, 2, 2, 2, 2);
                LimitedLineMovePlate(0, -1, 2, 2, 2, 2);
                LimitedLineMovePlate(-1, -1, 2, 2, 2, 2);
                LimitedLineMovePlate(-1, 1, 2, 2, 2, 2);
                LimitedLineMovePlate(1, -1, 2, 2, 2, 2);
                break;
        }
    }

    public void LineMovePlate(int xInc, int yInc) {
        GameController sc = gameController.GetComponent<GameController>();

        int x = xBoard + xInc;
        int y = yBoard + yInc;

        while (sc.PositionsOnBoard(x, y) && sc.GetPosition(x, y) == null) {
            MovePlateSpawn(x, y, false);
            x += xInc;
            y += yInc;
        }

        if (sc.PositionsOnBoard(x, y) && sc.GetPosition(x, y).GetComponent<PieceController>().player != player) {
            MovePlateSpawn(x, y, true);
        }
    }

    public void PawnMovePlate(int x, int y) {
        GameController sc = gameController.GetComponent<GameController>();
        if (sc.PositionsOnBoard(x, y)) {
            if (sc.GetPosition(x, y) == null) {
                if (sc.GetPosition(x, yBoard) == sc.GetPosition(x, 1) && player == "white" && sc.GetPosition(x, y + 1) == null) {
                        MovePlateSpawn(x, y + 1, false);
                    }
                if (sc.GetPosition(x, yBoard) == sc.GetPosition(x, 6) && player == "black" && sc.GetPosition(x, y - 1) == null) {
                        MovePlateSpawn(x, y - 1, false);
                    }
                MovePlateSpawn(x, y, false);
            }

            if (sc.PositionsOnBoard(x + 1, y) && sc.GetPosition(x + 1, y) != null && sc.GetPosition(x + 1, y).GetComponent<PieceController>().player != player) {
                MovePlateSpawn(x + 1, y, true);
            }

            if (sc.PositionsOnBoard(x - 1, y) && sc.GetPosition(x - 1, y) != null && sc.GetPosition(x - 1, y).GetComponent<PieceController>().player != player) {
                MovePlateSpawn(x - 1, y, true);
            }
        }
    }

    // so many parameters for future proofing. Could be useful for many pieces I may add.
    public void LimitedLineMovePlate(int xInc, int yInc, int xDisPositve, int yDisPositve, int xDisNegative, int yDisNegative) {
        GameController sc = gameController.GetComponent<GameController>();

        int x = xBoard + xInc;
        int y = yBoard + yInc;

        while (sc.PositionsOnBoard(x, y) && sc.GetPosition(x, y) == null) {
            if ((x - xBoard) <= xDisPositve && (y - yBoard) <= yDisPositve && (xBoard - x) <= xDisNegative && (yBoard - y) <= yDisNegative) {
                MovePlateSpawn(x, y, false);
                x += xInc;
                y += yInc;
            } else {
                x += xInc;
                y += yInc;
            }  
        }

        if (sc.PositionsOnBoard(x, y) && sc.GetPosition(x, y).GetComponent<PieceController>().player != player) {
            //MovePlateSpawn(x, y, true);
            if ((x - xBoard) <= xDisPositve && (y - yBoard) <= yDisPositve && (xBoard - x) <= xDisNegative && (yBoard - y) <= yDisNegative) {
                MovePlateSpawn(x, y, true);
            }
        }
    }

    public void LMovePlate() {
        PointMovePlate(xBoard + 1, yBoard + 2);
        PointMovePlate(xBoard - 1, yBoard + 2);
        PointMovePlate(xBoard + 2, yBoard + 1);
        PointMovePlate(xBoard + 2, yBoard - 1);
        PointMovePlate(xBoard + 1, yBoard - 2);
        PointMovePlate(xBoard - 1, yBoard - 2);
        PointMovePlate(xBoard - 2, yBoard + 1);
        PointMovePlate(xBoard - 2, yBoard - 1);
    }

    public void AdjacentMovePlate() {
        PointMovePlate(xBoard, yBoard + 1);
        PointMovePlate(xBoard, yBoard - 1);
        PointMovePlate(xBoard - 1, yBoard - 1);
        PointMovePlate(xBoard - 1, yBoard);
        PointMovePlate(xBoard - 1, yBoard + 1);
        PointMovePlate(xBoard + 1, yBoard - 1);
        PointMovePlate(xBoard + 1, yBoard);
        PointMovePlate(xBoard + 1, yBoard + 1);
    }

    public void DoubleAdjacentMovePlate() {
        PointMovePlate(xBoard, yBoard + 1);
        PointMovePlate(xBoard, yBoard - 1);
        PointMovePlate(xBoard - 1, yBoard - 1);
        PointMovePlate(xBoard - 1, yBoard);
        PointMovePlate(xBoard - 1, yBoard + 1);
        PointMovePlate(xBoard + 1, yBoard - 1);
        PointMovePlate(xBoard + 1, yBoard);
        PointMovePlate(xBoard + 1, yBoard + 1);
        PointMovePlate(xBoard, yBoard + 2);
        PointMovePlate(xBoard, yBoard - 2);
        PointMovePlate(xBoard - 2, yBoard - 2);
        PointMovePlate(xBoard - 2, yBoard);
        PointMovePlate(xBoard - 2, yBoard + 2);
        PointMovePlate(xBoard + 2, yBoard - 2);
        PointMovePlate(xBoard + 2, yBoard);
        PointMovePlate(xBoard + 2, yBoard + 2);
        PointMovePlate(xBoard + 1, yBoard + 2);
        PointMovePlate(xBoard - 1, yBoard + 2);
        PointMovePlate(xBoard + 2, yBoard + 1);
        PointMovePlate(xBoard + 2, yBoard - 1);
        PointMovePlate(xBoard + 1, yBoard - 2);
        PointMovePlate(xBoard - 1, yBoard - 2);
        PointMovePlate(xBoard - 2, yBoard + 1);
        PointMovePlate(xBoard - 2, yBoard - 1);
    }

    public void PointMovePlate(int x, int y) {
        GameController sc = gameController.GetComponent<GameController>();
        if (sc.PositionsOnBoard(x, y)) {
            GameObject cp = sc.GetPosition(x, y);

            if (cp == null) {
            MovePlateSpawn(x, y, false);
            } else if (cp.GetComponent<PieceController>().player != player) {
                MovePlateSpawn(x, y, true);
            }
        }  
    }

    public void MovePlateSpawn(int matrixX, int matrixY, bool isAttack) {
        float x = matrixX;
        float y = matrixY;

        x += -7.5f;
        y += -3.5f;

        GameObject MovePlate = Instantiate(movePlate, new Vector2(x, y), Quaternion.identity);

        MovePlate MovePlateScript = MovePlate.GetComponent<MovePlate>();
        if (isAttack) {
            MovePlateScript.attack = true;
        } else {
            MovePlateScript.attack = false;
        }
        MovePlateScript.SetReference(gameObject);
        MovePlateScript.SetCoords(matrixX, matrixY);
    }


//////////////////////////////////////////////////////////////////////////////////////////////
/************************EVERYTHING PAST HERE IS AI GENERATED STUFF**************************/
/**********************OF COURSE IT'S HEAVILY EDITED TO ACTUALLY WORK************************/
//////////////////////////////////////////////////////////////////////////////////////////////


    public bool IsLegalMove(int x, int y, GameObject[,] board, GameObject piece)
    {
        //GameController gameController = GameObject.Find("GameController").GetComponent<GameController>();
        
        // Check if the move is within the board bounds
        if (!(x <= 8 && x >= 0 && y <= 8 && y >= 0))
        {
            return false;
        }
        
        // Check if there is a piece of the same color in the target position
        GameObject targetPiece = board[x, y];
        if (targetPiece != null && targetPiece.GetComponent<PieceController>().GetColor() == piece.GetComponent<PieceController>().GetColor())
        {
            return false;
        }
        
        // Check if the move is valid according to the specific piece's movement rules
        List<Vector2Int> possibleMoves = GetMoves(board, piece);
        foreach (Vector2Int move in possibleMoves)
        {
            int targetX = piece.GetXBoard() + move.x;
            int targetY = piece.GetYBoard(); + move.y;
            
            if (targetX == x && targetY == y)
            {
                GameObject simulatedGameController = Instantiate(gameController);
                simulatedGameController.SetPositionEmpty(xBoard, yBoard);
                simulatedGameController.SetPosition(gameObject);
                Destroy(simulatedGameController.gameObject);
                return true;
            }
        }
        
        return false;
    }

    public void MakeMove(Vector2Int move)
    {
        // Save the current position of the piece
        int currentX = GetXBoard();
        int currentY = GetYBoard();

        // Move the piece to the new position
        gameController.SetPositionEmpty(currentX, currentY);
        SetXBoard(move.x);
        SetYBoard(move.y);
        gameController.SetPosition(gameObject);

        // Update the game state
        gameController.NextTurn();
    }


    //////////////////////////////////////////////////////////////////////////////////////////////////
    /******************************I CODED EVERYTHING BELOW HERE BOZO********************************/
    /*EVERYTHING SEEMS KINDA SIMILAR TO STUFF ABOVE BECAUSE I WAS DUMB AND THIS IS FOR CHESS AI ONLY*/
    /***********************************UGLY UGLY UGLY CODE HURRAH***********************************/
    //////////////////////////////////////////////////////////////////////////////////////////////////


    public List<Vector2Int> GetMoves(GameObject[,] board, GameObject piece) {
        List<Vector2Int> moves = new List<Vector2Int>();

        switch (piece.name) {
            case "whiteQueen":
            case "blackQueen":
                moves.AddRange(GetBishopMoves(board, piece));
                moves.AddRange(GetRookMoves(board, piece));
                break;
            case "whiteKnight":
            case "blackKnight":
                moves.AddRange(GetLMoves(board, piece));
                break;
            case "whiteBishop":
            case "blackBishop":
                moves.AddRange(GetBishopMoves(board, piece));
                break;
            case "whiteKing":
            case "blackKing":
                moves.AddRange(GetAdjacentMoves(board, piece));
                break;
            case "whiteRook":
            case "blackRook":
                moves.AddRange(GetRookMoves(board, piece));
                break;
            case "whitePawn":
                moves.AddRange(GetPawnMoves(board, piece, piece.GetComponent<PieceController>().GetXBoard(), piece.GetComponent<PieceController>().GetYBoard() + 1));
                break;
            case "blackPawn":
                moves.AddRange(GetPawnMoves(board, piece, piece.GetComponent<PieceController>().GetXBoard(), piece.GetComponent<PieceController>().GetYBoard() - 1));
                break;
            case "whitePrince":
            case "blackPrince":
                moves.AddRange(GetLimitedLineMoves(board, piece, 1, 1, 2, 2, 2, 2));
                moves.AddRange(GetLimitedLineMoves(board, piece, 1, 0, 2, 2, 2, 2));
                moves.AddRange(GetLimitedLineMoves(board, piece, 0, 1, 2, 2, 2, 2));
                moves.AddRange(GetLimitedLineMoves(board, piece, -1, 0, 2, 2, 2, 2));
                moves.AddRange(GetLimitedLineMoves(board, piece, 0, -1, 2, 2, 2, 2));
                moves.AddRange(GetLimitedLineMoves(board, piece, -1, -1, 2, 2, 2, 2));
                moves.AddRange(GetLimitedLineMoves(board, piece, -1, 1, 2, 2, 2, 2));
                moves.AddRange(GetLimitedLineMoves(board, piece, 1, -1, 2, 2, 2, 2));
                break;
        }
    }

    public List<Vector2Int> GetLMoves(GameObject[,] board, GameObject piece) {
        List<Vector2Int> moves = new List<Vector2Int>();
        moves.Add(GetPointMoves(piece.xBoard - 1, piece.GetComponent<PieceController>().GetYBoard() + 2));
        moves.Add(GetPointMoves(piece.GetComponent<PieceController>().GetXBoard() + 1, piece.GetComponent<PieceController>().GetYBoard() + 2));
        moves.Add(GetPointMoves(piece.GetComponent<PieceController>().GetXBoard() + 2, piece.GetComponent<PieceController>().GetYBoard() + 1));
        moves.Add(GetPointMoves(piece.GetComponent<PieceController>().GetXBoard() + 2, piece.GetComponent<PieceController>().GetYBoard() - 1));
        moves.Add(GetPointMoves(piece.GetComponent<PieceController>().GetXBoard() + 1, piece.GetComponent<PieceController>().GetYBoard() - 2));
        moves.Add(GetPointMoves(piece.GetComponent<PieceController>().GetXBoard() - 1, piece.GetComponent<PieceController>().GetYBoard() - 2));
        moves.Add(GetPointMoves(piece.GetComponent<PieceController>().GetXBoard() - 2, piece.GetComponent<PieceController>().GetYBoard() + 1));
        moves.Add(GetPointMoves(piece.GetComponent<PieceController>().GetXBoard() - 2, piece.GetComponent<PieceController>().GetYBoard() - 1));
        return moves;
    }

    public List<Vector2Int> GetAdjacentMoves(GameObject[,] board, GameObject piece) {
        List<Vector2Int> moves = new List<Vector2Int>();
        moves.Add(GetPointMoves(piece.GetComponent<PieceController>().GetXBoard(), piece.GetComponent<PieceController>().GetYBoard() - 1));
        moves.Add(GetPointMoves(piece.GetComponent<PieceController>().GetXBoard(), piece.GetComponent<PieceController>().GetYBoard() + 1));
        moves.Add(GetPointMoves(piece.GetComponent<PieceController>().GetXBoard() - 1, piece.GetComponent<PieceController>().GetYBoard() - 1));
        moves.Add(GetPointMoves(piece.GetComponent<PieceController>().GetXBoard() - 1, piece.GetComponent<PieceController>().GetYBoard()));
        moves.Add(GetPointMoves(piece.GetComponent<PieceController>().GetXBoard() - 1, piece.GetComponent<PieceController>().GetYBoard() + 1));
        moves.Add(GetPointMoves(piece.GetComponent<PieceController>().GetXBoard() + 1, piece.GetComponent<PieceController>().GetYBoard() - 1));
        moves.Add(GetPointMoves(piece.GetComponent<PieceController>().GetXBoard() + 1, piece.GetComponent<PieceController>().GetYBoard()));
        moves.Add(GetPointMoves(piece.GetComponent<PieceController>().GetXBoard() + 1, piece.GetComponent<PieceController>().GetYBoard() + 1));
        return moves;
    }

    public List<Vector2Int> DoubleAdjacentMovePlate(GameObject[,] board, GameObject piece) {
        List<Vector2Int> moves = new List<Vector2Int>();
        moves.Add(GetPointMoves(piece.GetComponent<PieceController>().GetXBoard(), piece.GetComponent<PieceController>().GetYBoard() + 1));
        moves.Add(GetPointMoves(piece.GetComponent<PieceController>().GetXBoard(), piece.GetComponent<PieceController>().GetYBoard() - 1));
        moves.Add(GetPointMoves(piece.GetComponent<PieceController>().GetXBoard() - 1, piece.GetComponent<PieceController>().GetYBoard() - 1));
        moves.Add(GetPointMoves(piece.GetComponent<PieceController>().GetXBoard() - 1, piece.GetComponent<PieceController>().GetYBoard()));
        moves.Add(GetPointMoves(piece.GetComponent<PieceController>().GetXBoard() - 1, piece.GetComponent<PieceController>().GetYBoard() + 1));
        moves.Add(GetPointMoves(piece.GetComponent<PieceController>().GetXBoard() + 1, piece.GetComponent<PieceController>().GetYBoard() - 1));
        moves.Add(GetPointMoves(piece.GetComponent<PieceController>().GetXBoard() + 1, piece.GetComponent<PieceController>().GetYBoard()));
        moves.Add(GetPointMoves(piece.GetComponent<PieceController>().GetXBoard() + 1, piece.GetComponent<PieceController>().GetYBoard() + 1));
        moves.Add(GetPointMoves(piece.GetComponent<PieceController>().GetXBoard(), piece.GetComponent<PieceController>().GetYBoard() + 2));
        moves.Add(GetPointMoves(piece.GetComponent<PieceController>().GetXBoard(), piece.GetComponent<PieceController>().GetYBoard() - 2));
        moves.Add(GetPointMoves(piece.GetComponent<PieceController>().GetXBoard() - 2, piece.GetComponent<PieceController>().GetYBoard() - 2));
        moves.Add(GetPointMoves(piece.GetComponent<PieceController>().GetXBoard() - 2, piece.GetComponent<PieceController>().GetYBoard()));
        moves.Add(GetPointMoves(piece.GetComponent<PieceController>().GetXBoard() - 2, piece.GetComponent<PieceController>().GetYBoard() + 2));
        moves.Add(GetPointMoves(piece.GetComponent<PieceController>().GetXBoard() + 2, piece.GetComponent<PieceController>().GetYBoard() - 2));
        moves.Add(GetPointMoves(piece.GetComponent<PieceController>().GetXBoard() + 2, piece.GetComponent<PieceController>().GetYBoard()));
        moves.Add(GetPointMoves(piece.GetComponent<PieceController>().GetXBoard() + 2, piece.GetComponent<PieceController>().GetYBoard() + 2));
        moves.Add(GetPointMoves(piece.GetComponent<PieceController>().GetXBoard() + 1, piece.GetComponent<PieceController>().GetYBoard() + 2));
        moves.Add(GetPointMoves(piece.GetComponent<PieceController>().GetXBoard() - 1, piece.GetComponent<PieceController>().GetYBoard() + 2));
        moves.Add(GetPointMoves(piece.GetComponent<PieceController>().GetXBoard() + 2, piece.GetComponent<PieceController>().GetYBoard() + 1));
        moves.Add(GetPointMoves(piece.GetComponent<PieceController>().GetXBoard() + 2, piece.GetComponent<PieceController>().GetYBoard() - 1));
        moves.Add(GetPointMoves(piece.GetComponent<PieceController>().GetXBoard() + 1, piece.GetComponent<PieceController>().GetYBoard() - 2));
        moves.Add(GetPointMoves(piece.GetComponent<PieceController>().GetXBoard() - 1, piece.GetComponent<PieceController>().GetYBoard() - 2));
        moves.Add(GetPointMoves(piece.GetComponent<PieceController>().GetXBoard() - 2, piece.GetComponent<PieceController>().GetYBoard() + 1));
        moves.Add(GetPointMoves(piece.GetComponent<PieceController>().GetXBoard() - 2, piece.GetComponent<PieceController>().GetYBoard() - 1));
        return moves;
    }

    public List<Vector2Int> GetRookMoves(GameObject[,] board, GameObject piece) {
        //GameController sc = gameController.GetComponent<GameController>();
        List<Vector2Int> moves = new List<Vector2Int>();
        Vector2Int move = new Vector2Int();

        int xInc, yInc;

        
        int x = piece.GetComponent<PieceController>().GetXBoard();
        int y = piece.GetComponent<PieceController>().GetYBoard();
        /*
        int xInc = 1;
        int yInc = 1;

        while (x <= 8 && x >= 0 && y <= 8 && y >= 0 && board[x, y] == null) {
            //MovePlateSpawn(x, y, false);
            moves.Add(x,y);
            x += xInc;
            y += yInc;
        }

        if (sc.PositionsOnBoard(x, y) && sc.GetPosition(x, y).GetComponent<PieceController>().player != player) {
            //MovePlateSpawn(x, y, true);
            moves.Add(x,y);
        }
        */

        for (int i = -1; i < 2; i++) {

            for (int j = -1; j < 2; j++) {

                // Verifies that it is only up, down, left, or right
                if (Mathf.Abs(x) + Mathf.Abs(y) == 1) {

                    x = piece.GetComponent<PieceController>().GetXBoard();
                    y = piece.GetComponent<PieceController>().GetYBoard();

                    xInc = i;
                    yInc = j;

                    while (x <= 8 && x >= 0 && y <= 8 && y >= 0 && board[x, y] == null) {
                        //MovePlateSpawn(x, y, false);
                        move.Set(x,y);
                        moves.Add(move);
                        x += xInc;
                        y += yInc;
                    }

                    if (x <= 8 && x >= 0 && y <= 8 && y >= 0) {
                        GameObject pieceAtPlace = board[x, y];
                        if (pieceAtPlace.GetComponent<PieceController>().player != piece.GetComponent<PieceController>().player) {
                        //MovePlateSpawn(x, y, true);
                        move.Set(x,y);
                        moves.Add(move);
                        }
                    } 
                }
            }
        }
        return moves;   
    }

    public List<Vector2Int> GetBishopMoves(GameObject[,] board, GameObject piece) {
        //GameController sc = gameController.GetComponent<GameController>();
        List<Vector2Int> moves = new List<Vector2Int>();
        Vector2Int move = new Vector2Int();

        int xInc, yInc;

        
        int x = piece.GetComponent<PieceController>().GetXBoard();
        int y = piece.GetComponent<PieceController>().GetYBoard();

        /*
        int xInc = 1;
        int yInc = 1;

        while (x <= 8 && x >= 0 && y <= 8 && y >= 0 && board[x, y] == null) {
            //MovePlateSpawn(x, y, false);
            moves.Add(x,y);
            x += xInc;
            y += yInc;
        }

        if (sc.PositionsOnBoard(x, y) && sc.GetPosition(x, y).GetComponent<PieceController>().player != player) {
            //MovePlateSpawn(x, y, true);
            moves.Add(x,y);
        }
        */

        for (int i = -1; i < 2; i++) {

            for (int j = -1; j < 2; j++) {

                // Verifies that it is only the diagonals
                if (Mathf.Abs(x) + Mathf.Abs(y) == 2) {

                    x = piece.GetComponent<PieceController>().GetXBoard();
                    y = piece.GetComponent<PieceController>().GetYBoard();

                    xInc = i;
                    yInc = j;

                    while (x <= 8 && x >= 0 && y <= 8 && y >= 0 && board[x, y] == null) {
                        //MovePlateSpawn(x, y, false);
                        move.Set(x,y);
                        moves.Add(move);
                        x += xInc;
                        y += yInc;
                    }

                    if (x <= 8 && x >= 0 && y <= 8 && y >= 0) {
                        GameObject pieceAtPlace = board[x, y];
                        if (pieceAtPlace.GetComponent<PieceController>().player != piece.GetComponent<PieceController>().player) {
                        //MovePlateSpawn(x, y, true);
                        move.Set(x,y);
                        moves.Add(move);
                        }
                    } 
                }
            }
        }
        return moves; 
    }

    public List<Vector2Int> GetPointMoves(GameObject[,] board, GameObject piece, int x, int y) {
        List<Vector2Int> moves = new List<Vector2Int>();
        Vector2Int move = new Vector2Int();

        //GameController sc = gameController.GetComponent<GameController>();
            //determines if position is real. Then assigns the piece, or lack of piece, at that position to an object
            if (x <= 8 && x >= 0 && y <= 8 && y >= 0) {
                GameObject cp = board[x, y];

            if (cp == null) {
                //MovePlateSpawn(x, y, false);
                move.Set(x,y);
                moves.Add(move);
                } else if (cp.GetComponent<PieceController>().player != piece.GetComponent<PieceController>().player) {
                    //MovePlateSpawn(x, y, true);
                    move.Set(x,y);
                    moves.Add(move);
                }
            } 
        return moves;
    }

    public List<Vector2Int> GetPawnMoves(GameObject[,] board, GameObject piece, int x, int y) {
        List<Vector2Int> moves = new List<Vector2Int>();
        Vector2Int move = new Vector2Int();

        //GameController sc = gameController.GetComponent<GameController>();
        if (x <= 8 && x >= 0 && y <= 8 && y >= 0) {
            if (board[x, y] == null) {
                if (board[x, yBoard] == board[x, 1] && player == "white" && board[x, y + 1] == null) {
                        //MovePlateSpawn(x, y + 1, false);
                        move.Set(x,y);
                        moves.Add(move);
                    }
                if (board[x, yBoard] == board[x, 6] && player == "black" && board[x, y - 1] == null) {
                        //MovePlateSpawn(x, y - 1, false);
                        move.Set(x,y);
                        moves.Add(move);
                    }
                //MovePlateSpawn(x, y, false);
                move.Set(x,y);
                moves.Add(move);
            }

            gameObject pieceAtPlace = board[x + 1, y];
            if (x + 1 <= 8 && x + 1 >= 0 && y <= 8 && y >= 0 && board[x + 1, y] != null && pieceAtPlace.GetComponent<PieceController>().player != piece.GetComponent<PieceController>().player) {
                //MovePlateSpawn(x + 1, y, true);
                move.Set(x,y);
                moves.Add(move);
            }

            pieceAtPlace = board[x - 1, y];
            if (x - 1 <= 8 && x - 1 >= 0 && y <= 8 && y >= 0 && board[x - 1, y] != null && pieceAtPlace.GetComponent<PieceController>().player != piece.GetComponent<PieceController>().player) {
                //MovePlateSpawn(x - 1, y, true);
                move.Set(x,y);
                moves.Add(move);
            }
        }
        return moves;
    }

    public List<Vector2Int> GetLimitedLineMoves(GameObject[,] board, GameObject piece, int xInc, int yInc, int xDisPositve, int yDisPositve, int xDisNegative, int yDisNegative) {
        List<Vector2Int> moves = new List<Vector2Int>();
        Vector2Int move = new Vector2Int();
        
        //GameController sc = gameController.GetComponent<GameController>();

        //int x, y, xInc, yInc;

        int fakeXBoard = piece.GetComponent<PieceController>().GetXBoard();
        int fakeYBoard = piece.GetComponent<PieceController>().GetYBoard();

        int x = fakeXBoard + xInc;
        int y = fakeYBoard + yInc;

        while (x <= 8 && x >= 0 && y <= 8 && y >= 0 && sboard[x, y] == null) {
            if ((x - fakeXBoard) <= xDisPositve && (y - fakeYBoard) <= yDisPositve && (fakeXBoard - x) <= xDisNegative && (fakeYBoard - y) <= yDisNegative) {
                //MovePlateSpawn(x, y, false);
                move.Set(x,y);
                moves.Add(move);
                x += xInc;
                y += yInc;
            } else {
                x += xInc;
                y += yInc;
            }  
        }

        GameObject pieceAtPlace = board[x, y];
        if (x <= 8 && x >= 0 && y <= 8 && y >= 0 && pieceAtPlace.GetComponent<PieceController>().player != piece.GetComponent<PieceController>().player) {
            //MovePlateSpawn(x, y, true);
            move.Set(x,y);
            moves.Add(move);
            if ((x - fakeXBoard) <= xDisPositve && (y - fakeYBoard) <= yDisPositve && (fakeXBoard - x) <= xDisNegative && (fakeYBoard - y) <= yDisNegative) {
                //MovePlateSpawn(x, y, true);
                move.Set(x,y);
                moves.Add(move);
            }
        }

        return moves;
    }

}
