using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoardColorController : MonoBehaviour
{
    GameObject mainManager;
    public GameObject lightSquares;
    public GameObject darkSquares;
    public GameObject border;
    string gameColor;

    // Start is called before the first frame update
    void Start()
    {
        mainManager = GameObject.FindGameObjectWithTag("MainManager");
        SetGameColor();
    }

    public void SetGameColor() {
        gameColor = mainManager.GetComponent<MainManager>().gameColor;
        
        switch (gameColor) {
            case "red":
                lightSquares.GetComponent<SpriteRenderer>().color = new Color32(245, 156, 156, 255);
                darkSquares.GetComponent<SpriteRenderer>().color = new Color32(120, 31, 31, 255);
                border.GetComponent<SpriteRenderer>().color = new Color32(41, 11, 11, 255);
                break;
            case "blue":
                lightSquares.GetComponent<SpriteRenderer>().color = new Color32(156, 156, 245, 255);
                darkSquares.GetComponent<SpriteRenderer>().color = new Color32(31, 31, 120, 255);
                border.GetComponent<SpriteRenderer>().color = new Color32(11, 11, 41, 255);
                break;
            case "green":
                lightSquares.GetComponent<SpriteRenderer>().color = new Color32(156, 245, 156, 255);
                darkSquares.GetComponent<SpriteRenderer>().color = new Color32(31, 120, 31, 255);
                border.GetComponent<SpriteRenderer>().color = new Color32(11, 41, 11, 255);
                break;
            case "yellow":
                lightSquares.GetComponent<SpriteRenderer>().color = new Color32(245, 245, 156, 255);
                darkSquares.GetComponent<SpriteRenderer>().color = new Color32(120, 120, 31, 255);
                border.GetComponent<SpriteRenderer>().color = new Color32(41, 41, 11, 255);
                break;
            default:
                lightSquares.GetComponent<SpriteRenderer>().color = new Color32(156, 156, 245, 255);
                darkSquares.GetComponent<SpriteRenderer>().color = new Color32(31, 31, 120, 255);
                border.GetComponent<SpriteRenderer>().color = new Color32(11, 11, 41, 255);
                break;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
