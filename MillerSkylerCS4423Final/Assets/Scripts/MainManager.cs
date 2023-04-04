using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainManager : MonoBehaviour
{

    public static MainManager instance;
    public int[] pieces;
    public string gameColor;

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
