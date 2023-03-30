using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MapBattleController : MonoBehaviour
{
                        // piece, y, x, color
                        // 0 = king, 1 = pawn, 2 = rook, 3 = bishop, 4 = knight, 5 = queen, 6 = prince
    public int[] pieces;// = {0, 4, 4, 0, 
                        //    0, 4, 5, 1,
                         //   1, 0, 0, 0,
                         //   1, 7, 7, 1};
    public GameObject mainManager;

    // Start is called before the first frame update
    void Start()
    {  
        pieces = new int[] {4, 2, 0, 0, //white knight 2,0
                            4, 4, 7, 1, //black knight 4,7
                            3, 2, 1, 0, //white bishop 2,1
                            3, 4, 6, 1, //black bishop 4,6
                            6, 1, 1, 0, //white prince 1,1
                            6, 5, 6, 1, //black prince 5,6
                            0, 1, 0, 0, //white king 1,0
                            0, 5, 7, 1};//black king 5,7
        mainManager = GameObject.FindGameObjectWithTag("MainManager");
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnMouseUp() {
        mainManager.GetComponent<MainManager>().pieces = pieces;
        SceneManager.LoadScene("SampleScene");
    }
}
