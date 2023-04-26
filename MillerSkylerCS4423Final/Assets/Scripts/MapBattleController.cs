using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class MapBattleController : MonoBehaviour
{
                        // piece, x, y, color
                        // 0 = king, 1 = pawn, 2 = rook, 3 = bishop, 4 = knight, 5 = queen, 6 = prince, 7 = hole, 8 = hole2, 9 = wall
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
                                    4, 4, 6, 0, //white knight 7,4
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
            default:
                pieces = new int[] {0, 0, 0, 0, //white king 0,0
                                    5, 1, 0, 0, //white queen 1,0
                                    7, 5, 4, 2, //hole1 5,4
                                    8, 4, 5, 2, //hole2 4,5
                                    0, 7, 7, 1};//black king 7,7
                numWhite = 2;
                numBlack = 1;
                numHazard = 2;
                parMoves = 5;
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
