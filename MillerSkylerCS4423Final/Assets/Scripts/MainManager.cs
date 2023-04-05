using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainManager : MonoBehaviour
{

    public static MainManager instance;
    public int[] pieces;
    public string gameColor;
    public int numWhite;
    public int numBlack;
    public int numWins = 0;
    public int numLoss = 0;
    public int money = 0;
    public bool support = false;
    public bool sabotage = false;
    public int difficulty; //maybe maybe maybe I have enough time. that's a funny joke though

    // Start is called before the first frame update
    void Start()
    {
        
    }

    private void Awake() {
    if (instance == null)
    {
        instance = this;
    }
    else
    {
        Destroy(gameObject);
    }
    DontDestroyOnLoad(gameObject);
}

    // Update is called once per frame
    void Update()
    {
        
    }
}
