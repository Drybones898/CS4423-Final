using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundColorController : MonoBehaviour
{
    GameObject mainManager;
    public GameObject background;
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
                background.GetComponent<SpriteRenderer>().color = new Color32(29, 0, 0, 255);
                break;
            case "blue":
                background.GetComponent<SpriteRenderer>().color = new Color32(0, 13, 29, 255);
                break;
            case "green":
                background.GetComponent<SpriteRenderer>().color = new Color32(0, 29, 0, 255);
                break;
            case "yellow":
                background.GetComponent<SpriteRenderer>().color = new Color32(29, 29, 0, 255);
                break;
            default:
                background.GetComponent<SpriteRenderer>().color = new Color32(0, 13, 29, 255);
                break;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}