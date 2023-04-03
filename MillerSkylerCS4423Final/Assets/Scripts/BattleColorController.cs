using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BattleColorController : MonoBehaviour
{
    public GameObject background;
    public GameObject mainManager;
    public GameObject lightSquares;
    public GameObject darkSquares;
    public GameObject border;
    string gameColor;
    // Start is called before the first frame update
    void Start()
    {
        mainManager = GameObject.FindGameObjectWithTag("MainManager");
        gameColor = mainManager.GetComponent<MainManager>().gameColor;
        

        switch (gameColor) {
            case "red":
                lightSquares.GetComponent<SpriteRenderer>().SetColor(F59CA6);
                break;
            default:
                break;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
