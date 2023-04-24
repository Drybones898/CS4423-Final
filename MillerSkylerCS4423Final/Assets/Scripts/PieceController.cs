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
    public Sprite hazardhole1, hazardhole2;

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
            case "hazardhole1": this.GetComponent<SpriteRenderer>().sprite = hazardhole1; player = "hazard"; break;
            case "hazardhole2": this.GetComponent<SpriteRenderer>().sprite = hazardhole2; player = "hazard"; break;
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
        
        PlaySelectSound();
        if (!gameController.GetComponent<GameController>().IsGameOver() && gameController.GetComponent<GameController>().GetCurrentPlayer() == player && gameController.GetComponent<GameController>().pauseActive == false) {
            DestroyPlates();

            SetPieceText();
            InitiateMovePlates();
            InitiateSelectedPlate(xBoard, yBoard);
        }
        if (!gameController.GetComponent<GameController>().IsGameOver() && gameController.GetComponent<GameController>().GetCurrentPlayer() != player && gameController.GetComponent<GameController>().pauseActive == false) {
            DestroyPlates();

            SetPieceText();
            //InitiateSelectedPlate(xBoard, yBoard);
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
                gameController.GetComponent<GameController>().SetPieceNameText("King");
                gameController.GetComponent<GameController>().SetPieceDescriptionText("The king can only move and capture in one square in any direction.");
                break;
            case "blackKing":
                gameController.GetComponent<GameController>().SetPieceNameText("Black King");
                gameController.GetComponent<GameController>().SetPieceDescriptionText("The enemy king is immobile, you must act quickly to capture him before he can escape to his army!");
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
            case "hazardhole1":
            case "hazardhole2":
                gameController.GetComponent<GameController>().SetPieceNameText("Hole");
                gameController.GetComponent<GameController>().SetPieceDescriptionText("This is a hole. You cannot move pieces here.");
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

        if (sc.PositionsOnBoard(x, y) && sc.GetPosition(x, y).GetComponent<PieceController>().player != player && sc.GetPosition(x, y).GetComponent<PieceController>().player != "hazard") {
            MovePlateSpawn(x, y, true);
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

        if (sc.PositionsOnBoard(x, y) && sc.GetPosition(x, y).GetComponent<PieceController>().player != player && sc.GetPosition(x, y).GetComponent<PieceController>().player != "hazard") {
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
            } else if (cp.GetComponent<PieceController>().player != player && cp.GetComponent<PieceController>().player != "hazard") {
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

            if (sc.PositionsOnBoard(x + 1, y) && sc.GetPosition(x + 1, y) != null && sc.GetPosition(x + 1, y).GetComponent<PieceController>().player != player && sc.GetPosition(x + 1, y).GetComponent<PieceController>().player != "hazard") {
                MovePlateSpawn(x + 1, y, true);
            }

            if (sc.PositionsOnBoard(x - 1, y) && sc.GetPosition(x - 1, y) != null && sc.GetPosition(x - 1, y).GetComponent<PieceController>().player != player && sc.GetPosition(x - 1, y).GetComponent<PieceController>().player != "hazard") {
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

    public void PlaySelectSound() {
        GetComponent<AudioSource>().Play();
    }
}
