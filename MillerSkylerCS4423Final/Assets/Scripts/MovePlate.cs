using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovePlate : MonoBehaviour
{
    public GameObject gameController;

    GameObject reference = null;

    int matrixX;
    int matrixY;

    public bool attack = false;

    public void Start() {
        if (attack) {
            //to change this color to something I can change whenever I want.
            gameObject.GetComponent<SpriteRenderer>().color = new Color(1.0f,0.0f,0.0f,0.75f);
        }
    }

    public void OnMouseUp() {
        gameController = GameObject.FindGameObjectWithTag("GameController");
        //if (gameController.GetComponent<GameController>().GetCurrentPlayer() == "white") {
        if (attack) {
            GameObject cp = gameController.GetComponent<GameController>().GetPosition(matrixX, matrixY);

            if (cp.name == "whiteKing") {
                gameController.GetComponent<GameController>().Winner("black");
            } else if (cp.name == "blackKing") {
                gameController.GetComponent<GameController>().Winner("white");
            }
            // doing the lords work with this next line of code
            Destroy(cp);
        }

        gameController.GetComponent<GameController>().SetPositionEmpty(reference.GetComponent<PieceController>().GetXBoard(), reference.GetComponent<PieceController>().GetYBoard());

        reference.GetComponent<PieceController>().SetXBoard(matrixX);
        reference.GetComponent<PieceController>().SetYBoard(matrixY);
        reference.GetComponent<PieceController>().SetCoords();

        gameController.GetComponent<GameController>().SetPosition(reference);

        reference.GetComponent<PieceController>().DestroyPlates();
        gameController.GetComponent<GameController>().NextTurn();
    }
    //}

    public void Move(GameObject gc, int x, int y) {
        //gameController = GameObject.FindGameObjectWithTag("GameController");
        GameController gameController = gc.GetComponent<GameController>();
        //if (gameController.GetComponent<GameController>().GetCurrentPlayer() == "white") {
        if (attack) {
            GameObject cp = gameController.GetComponent<GameController>().GetPosition(matrixX, matrixY);

            if (cp.name == "whiteKing") {
                gameController.GetComponent<GameController>().Winner("black");
            } else if (cp.name == "blackKing") {
                gameController.GetComponent<GameController>().Winner("white");
            }
            // doing the lords work with this next line of code
            Destroy(cp);
        }

        gameController.GetComponent<GameController>().SetPositionEmpty(reference.GetComponent<PieceController>().GetXBoard(), reference.GetComponent<PieceController>().GetYBoard());

        reference.GetComponent<PieceController>().SetXBoard(x);
        reference.GetComponent<PieceController>().SetYBoard(y);
        reference.GetComponent<PieceController>().SetCoords();

        gameController.GetComponent<GameController>().SetPosition(reference);

        reference.GetComponent<PieceController>().DestroyPlates();
        gameController.GetComponent<GameController>().NextTurn();
    }
    //}

    public void SetCoords(int x, int y) {
        matrixX = x;
        matrixY = y;
    }

    public void SetReference(GameObject obj) {
        reference = obj;
    }

    public GameObject GetReference() {
        return reference;
    }
}
