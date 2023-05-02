using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class MapBattleController : MonoBehaviour
{
                        // piece, x, y, color
                        // 0 = king, 1 = pawn, 2 = rook, 3 = bishop, 4 = knight, 5 = queen, 6 = prince, 7 = hole, 8 = hole2, 9 = wall, 10 = river, 11 = river 2, 12 = river 3
    public int[] pieces;

    public GameObject mainManager;
    public MapUIController pauseUI;
    public int levelID;
    int numWhite;
    int numBlack;
    int numHazard;
    int parMoves;

    // Start is called before the first frame update
    void Start()
    {  
        switch (levelID) {
            case 1:
                pieces = new int[] {4, 3, 5, 0, //white knight 6,4
                                    1, 4, 6, 0, //white knight 7,4
                                    3, 5, 3, 0, //white bishop 4,6
                                    3, 6, 3, 0, //white bishop 4,7
                                    0, 3, 1, 0,
                                    0, 5, 5, 1, //black king 6,6
                                    7, 4, 3, 2, //hole 4,5
                                    7, 4, 4, 2, //hole 5,5
                                    8, 4, 5, 2, //hole 6,5
                                    7, 4, 7, 2, //hole 8,5
                                    8, 6, 4, 2, //hole 5,7
                                    8, 6, 5, 2, //hole 6,7
                                    7, 6, 7, 2, //hole 8,7
                                    };
                numWhite = 5;
                numBlack = 1;
                numHazard = 7;
                parMoves = 5;
                break;
            case 2:
                pieces = new int[] {3, 0, 0, 0, //white bishop 0,0
                                    2, 1, 0, 0, //white rook 1,0
                                    3, 2, 0, 0, //white bishop 2,0
                                    3, 4, 0, 0, //white bishop 4,0
                                    2, 5, 0, 0, //white rook 5,0
                                    3, 5, 1, 0, //white bishop 5,1
                                    0, 4, 1, 0, //white king 4,1
                                    7, 4, 4, 2, //hole 4,4
                                    8, 3, 5, 2, //hole 3,5
                                    8, 6, 0, 2, //hole 3,5
                                    0, 4, 5, 1, //black king 4,5
                                    9, 7, 3, 1,
                                    9, 6, 3, 1,
                                    9, 5, 3, 1,
                                    9, 4, 3, 1,
                                    9, 3, 3, 1,
                                    9, 2, 3, 1,
                                    9, 1, 3, 1,
                                    9, 0, 3, 1}; //wall 0,3
                numWhite = 7;
                numBlack = 9;
                numHazard = 3;
                parMoves = 4;
                break;
            case 3:
                pieces = new int[] {6, 4, 2, 0, //white prince
                                    0, 0, 6, 0, //white king
                                    0, 6, 7, 1, //black king
                                    8, 2, 5, 2, //hole
                                    9, 2, 6, 1, //black wall
                                    8, 2, 7, 2, //hole
                                    7, 3, 4, 2, //hole
                                    7, 4, 4, 2, //hole
                                    9, 5, 4, 1, //black wall
                                    8, 6, 4, 2, //hole
                                    9, 7, 5, 1}; //black wall
                numWhite = 2;
                numBlack = 4;
                numHazard = 5;
                parMoves = 4;
                break;
            case 4:
                pieces = new int[] {1, 2, 1, 0,
                                    3, 3, 1, 0,
                                    4, 1, 1, 0,
                                    2, 3, 2, 0,
                                    3, 6, 3, 0,
                                    7, 0, 2, 2,
                                    8, 1, 2, 2,
                                    7, 3, 3, 2,
                                    8, 4, 3, 2,
                                    7, 4, 4, 2,
                                    8, 5, 4, 2,
                                    7, 6, 4, 2,
                                    8, 7, 4, 2,
                                    8, 1, 5, 2,
                                    8, 2, 4, 2,
                                    0, 3, 4, 1,
                                    9, 1, 3, 1,
                                    9, 2, 3, 1,
                                    9, 2, 2, 1};
                numWhite = 5;
                numBlack = 4;
                numHazard = 10;
                parMoves = 6;
                break;
            case 5:
                pieces = new int[] {6, 0, 0, 0,
                                    0, 7, 7, 1,
                                    9, 2, 4, 1,
                                    9, 4, 5, 1,
                                    7, 0, 1, 2,
                                    8, 0, 2, 2,
                                    7, 0, 3, 2,
                                    7, 2, 0, 2,
                                    7, 2, 1, 2,
                                    8, 2, 2, 2,
                                    7, 3, 1, 2,
                                    8, 4, 1, 2,
                                    7, 6, 1, 2,
                                    7, 6, 2, 2,
                                    8, 6, 3, 2,
                                    8, 5, 3, 2,
                                    8, 4, 3, 2,
                                    7, 4, 4, 2,
                                    7, 3, 4, 2,
                                    8, 1, 4, 2,
                                    8, 5, 5, 2,
                                    7, 1, 6, 2,
                                    7, 2, 6, 2,
                                    8, 3, 6, 2,
                                    8, 4, 6, 2,
                                    7, 6, 7, 2};
                numWhite = 1;
                numBlack = 3;
                numHazard = 22;
                parMoves = 8;
                break;
            case 6:
                pieces = new int[] {4, 0, 3, 0,
                                    4, 1, 1, 0,
                                    4, 3, 0, 0,
                                    4, 4, 0, 0,
                                    4, 6, 1, 0,
                                    4, 7, 3, 0,
                                    10, 0, 4, 2,
                                    10, 1, 4, 2,
                                    11, 2, 4, 2,
                                    12, 3, 4, 2,
                                    12, 4, 4, 2,
                                    11, 5, 4, 2,
                                    10, 6, 4, 2,
                                    12, 7, 4, 2,
                                    9, 2, 7, 1,
                                    9, 3, 6, 1,
                                    9, 4, 6, 1,
                                    9, 5, 7, 1,
                                    0, 3, 7, 1};
                numWhite = 6;
                numBlack = 5;
                numHazard = 8;
                parMoves = 4;
                break;
        }
        
        mainManager = GameObject.FindGameObjectWithTag("MainManager");
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnMouseUp() {
        if (pauseUI.GetComponent<MapUIController>().pauseActive == false) {
            mainManager.GetComponent<MainManager>().pieces = pieces;
            mainManager.GetComponent<MainManager>().numWhite = numWhite;
            mainManager.GetComponent<MainManager>().numBlack = numBlack;
            mainManager.GetComponent<MainManager>().numHazard = numHazard;
            mainManager.GetComponent<MainManager>().parMoves = parMoves;
            SceneManager.LoadScene("SampleScene");
        }
    }
}
