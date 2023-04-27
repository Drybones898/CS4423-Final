using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovePlate : MonoBehaviour
{
    public GameObject gameController;

    GameObject reference = null;

    int matrixX;
    int matrixY;

    public GameObject camera;
    public GameObject particle;

    public bool attack = false;

    public void Start() {
        if (attack) {
            //to change this color to something I can change whenever I want.
            gameObject.GetComponent<SpriteRenderer>().color = new Color(1.0f,0.0f,0.0f,0.75f);
        }
    }

    public void OnMouseUp() {
        gameController = GameObject.FindGameObjectWithTag("GameController");
        if (attack) {
            GameObject cp = gameController.GetComponent<GameController>().GetPosition(matrixX, matrixY);
            camera = GameObject.Find("Main Camera");
            camera.GetComponent<CamShake>().TriggerShake();
            particle = GameObject.Find("DestroyedPiece");
            particle.GetComponent<Transform>().position = new Vector3(matrixX - 7.5f, matrixY - 4f, 0);
            particle.GetComponent<ParticleSystem>().Play();
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
        reference.GetComponent<SpriteRenderer>().material = reference.GetComponent<PieceController>().notSelected;

        gameController.GetComponent<GameController>().SetPosition(reference);

        gameController.GetComponent<GameController>().NextTurn();

        reference.GetComponent<PieceController>().DestroyPlates();
    }

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
