using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundColorController : MonoBehaviour
{
    public GameObject background;
    string gameColor;
    // Start is called before the first frame update
    void Start()
    { 
        SetGameColor();
    }

    public void SetGameColor() {
        gameColor = PlayerPrefs.GetString("color");
        switch (gameColor) {
            case "Red":
                background.GetComponent<SpriteRenderer>().color = new Color32(29, 0, 0, 255);
                break;
            case "Blue":
                background.GetComponent<SpriteRenderer>().color = new Color32(0, 13, 29, 255);
                break;
            case "Green":
                background.GetComponent<SpriteRenderer>().color = new Color32(0, 29, 0, 255);
                break;
            case "Yellow":
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