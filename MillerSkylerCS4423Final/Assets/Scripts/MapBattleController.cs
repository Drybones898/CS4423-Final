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
    public int levelID;
    int numWhite;
    int numBlack;

    // Start is called before the first frame update
    void Start()
    {  
        switch (levelID) {
            case 1:
                pieces = new int[] {4, 2, 0, 0, //white knight 2,0
                                    4, 4, 7, 1, //black knight 4,7
                                    3, 2, 1, 0, //white bishop 2,1
                                    3, 4, 6, 1, //black bishop 4,6
                                    6, 1, 1, 0, //white prince 1,1
                                    6, 5, 6, 1, //black prince 5,6
                                    0, 1, 0, 0, //white king 1,0
                                    0, 5, 7, 1};//black king 5,7
                numWhite = 4;
                numBlack = 4;
                break;
            case 2:
                pieces = new int[] {2, 2, 1, 0, //white rook 2,1
                                    4, 4, 7, 1, //black knight 4,7
                                    4, 1, 0, 0, //white knight 1,0
                                    3, 2, 0, 0, //white bishop 2,0
                                    2, 4, 6, 1, //black bishop 4,6
                                    6, 1, 1, 0, //white prince 1,1
                                    5, 6, 6, 1, //black prince 6,6
                                    0, 0, 0, 0, //white king 0,0
                                    0, 5, 6, 1};//black king 5,6
                numWhite = 5;
                numBlack = 4;
                break;
            case 3:
                pieces = new int[] {4, 2, 0, 0, //white knight 2,0
                                    4, 4, 7, 1, //black knight 4,7
                                    1, 6, 6, 1, //black pawn 2,6
                                    1, 4, 6, 1, //black pawn 4,6
                                    6, 1, 1, 0, //white prince 1,1
                                    6, 5, 6, 1, //black prince 5,6
                                    0, 1, 0, 0, //white king 1,0
                                    0, 5, 7, 1};//black king 5,7
                numWhite = 3;
                numBlack = 5;
                break;
            default:
                pieces = new int[] {0, 0, 0, 0, //white king 0,0
                                    5, 1, 0, 0, //white queen 1,0
                                    0, 7, 7, 1};//black king 7,7
                numWhite = 2;
                numBlack = 1;
                break;
        }
        
        mainManager = GameObject.FindGameObjectWithTag("MainManager");
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnMouseUp() {
        mainManager.GetComponent<MainManager>().pieces = pieces;
        mainManager.GetComponent<MainManager>().numWhite = numWhite;
        mainManager.GetComponent<MainManager>().numBlack = numBlack;
        SceneManager.LoadScene("SampleScene");
    }
}
