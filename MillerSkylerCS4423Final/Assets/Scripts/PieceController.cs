using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PieceController : MonoBehaviour
{
    public GameObject gameController;
    public GameObject movePlate;

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

    public void SetXBoard(int x) {
        xBoard = x;
    }

    public void SetYBoard(int y) {
        yBoard  = y;
    }

    private void OnMouseUp() {
        
        if (!gameController.GetComponent<GameController>().IsGameOver() && gameController.GetComponent<GameController>().GetCurrentPlayer() == player) {
            DestroyMovePlates();

            InitiateMovePlates();
        }
        
    }

    public void DestroyMovePlates() {
        GameObject[] movePlates = GameObject.FindGameObjectsWithTag("MovePlate");
        for (int i = 0; i < movePlates.Length; i++) {
            Destroy(movePlates[i]);
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
                LimitedLineMovePlate(1, 0, 2);
                LimitedLineMovePlate(0, 1, 2);
                LimitedLineMovePlate(1, 1, 2);
                LimitedLineMovePlate(-1, 0, 2);
                LimitedLineMovePlate(0, -1, 2);
                LimitedLineMovePlate(-1, -1, 2);
                LimitedLineMovePlate(-1, 1, 2);
                LimitedLineMovePlate(1, -1, 2);
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

    public void LimitedLineMovePlate(int xInc, int yInc, int distance) {
        GameController sc = gameController.GetComponent<GameController>();

        int x = xBoard + xInc;
        int y = yBoard + yInc;
        int i = 0;

        while (sc.PositionsOnBoard(x, y) && sc.GetPosition(x, y) == null && i < distance) {
            MovePlateSpawn(x, y, false);
            x += xInc;
            y += yInc;
            i += 1;
        }

        if (sc.PositionsOnBoard(x, y) && sc.GetPosition(x, y).GetComponent<PieceController>().player != player) {
            MovePlateSpawn(x, y, true);
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
}
