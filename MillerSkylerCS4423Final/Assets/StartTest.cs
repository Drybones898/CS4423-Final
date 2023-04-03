using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StartTest : MonoBehaviour
{   
    public GameObject mainManager;

    // Start is called before the first frame update
    void Start()
    {  
        mainManager = GameObject.FindGameObjectWithTag("MainManager");
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnMouseUp() {
        mainManager.GetComponent<MainManager>().gameColor = "red";
        SceneManager.LoadScene("Map");
    }
}
