using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;

public class GameController : MonoBehaviour
{
    
    public GameObject Chesspiece;
    public GameObject mainManager;
    
    [Header("Text")]
    public TMP_Text pieceNameText;
    public TMP_Text pieceDescriptionText;

    [Header("Pause Menu UI")]
    public BoardColorController boardColor;
    public BackgroundColorController backgroundColor;
    public TMP_Dropdown gameColorDropdown;
    public GameObject optionsMenu;
    public GameObject pauseMenu;
    public Button mapButton;
    public Button optionsButton;
    public Button resumeButton;
    public Button confirmButton;
    public Button quitButton;

    private GameObject[,] positions = new GameObject[8,8];
    private GameObject[] playerBlack;// = new GameObject[2];
    private GameObject[] playerWhite;// = new GameObject[2];
    private GameObject[] boardHazard;

    private string currentPlayer = "white";

    private bool gameOver = false;

    [Header("Misc")]
    public int[] pieces;
    string pieceName;
    int xStart;
    int yStart;
    string color;
    string realName;
    public bool pauseActive = false;
    
    // Start is called before the first frame update
    void Start()
    {
        mainManager = GameObject.FindGameObjectWithTag("MainManager");
        pieces = mainManager.GetComponent<MainManager>().pieces;
        int numWhite = mainManager.GetComponent<MainManager>().numWhite;
        int numBlack = mainManager.GetComponent<MainManager>().numBlack;
        int numHazard = mainManager.GetComponent<MainManager>().numHazard;

        gameColorDropdown.onValueChanged.AddListener(delegate {
                onValueChanged(gameColorDropdown);
            });
        resumeButton.onClick.AddListener(resumeGame);
        optionsButton.onClick.AddListener(toOptions);
        confirmButton.onClick.AddListener(toPauseMenu);
        mapButton.onClick.AddListener(toMap);
        quitButton.onClick.AddListener(Quit);
        
        playerWhite = new GameObject[numWhite];
        playerBlack = new GameObject[numBlack];
        boardHazard = new GameObject[numHazard];
        
        int j = 0;
        int k = 0;
        int l = 0;
        GameObject objectWhite;
        GameObject objectBlack;
        GameObject objectHazard;
        
        for (int i = 0; i < pieces.Length; i++) {
            if (i == 0) {
                switch (pieces[i]) {
                    case 0:
                        pieceName = "King";
                        break;
                    case 1:
                        pieceName = "Pawn";
                        break;
                    case 2:
                        pieceName = "Rook";
                        break;
                    case 3:
                        pieceName = "Bishop";
                        break;
                    case 4:
                        pieceName = "Knight";
                        break;
                    case 5:
                        pieceName = "Queen";
                        break;
                    case 6:
                        pieceName = "Prince";
                        break;
                    case 7:
                        pieceName = "hole1";
                        break;
                    case 8:
                        pieceName = "hole2";
                        break;
                }
            }
            if (i == 1) {
                xStart = pieces[i];
            } 
            if (i == 2) {
                yStart = pieces[i];
            } 
            if (i == 3) {
                if (pieces[i] == 0) {
                    color = "white";
                } else if (pieces[i] == 1) {
                    color = "black";
                } else {
                    color = "hazard";
                }
                realName = string.Concat(color, pieceName);
                if (color == "white") { 
                    objectWhite = Create(realName, xStart, yStart); 
                    playerWhite[j] = objectWhite;
                    j++;
                } else if (color == "black") {
                    objectBlack = Create(realName, xStart, yStart); 
                    playerBlack[k] = objectBlack;
                    k++;
                } else {
                    objectHazard = Create(realName, xStart, yStart);
                    boardHazard[l] = objectHazard;
                    l++;
                }
            }
            if (i != 0 && i != 1 && i != 2 && i != 3) {
                switch (i % 4) {
                    case 0:
                        switch (pieces[i]) {
                        case 0:
                            pieceName = "King";
                            break;
                        case 1:
                            pieceName = "Pawn";
                            break;
                        case 2:
                            pieceName = "Rook";
                            break;
                        case 3:
                            pieceName = "Bishop";
                            break;
                        case 4:
                            pieceName = "Knight";
                            break;
                        case 5:
                            pieceName = "Queen";
                            break;
                        case 6:
                            pieceName = "Prince";
                            break;
                        case 7:
                            pieceName = "hole1";
                            break;
                        case 8:
                            pieceName = "hole2";
                            break;
                    }
                    break;
                    case 1:
                        xStart = pieces[i];
                        break;
                    case 2:
                        yStart = pieces[i];
                        break;
                    case 3:
                        if (pieces[i] == 0) {
                            color = "white";
                        } else if (pieces[i] == 1) {
                            color = "black";
                        } else {
                            color = "hazard";
                        }
                        realName = string.Concat(color, pieceName);
                        if (color == "white") {
                            objectWhite = Create(realName, xStart, yStart);
                            playerWhite[j] = objectWhite;
                            j++;
                        } else if (color == "black") {
                            objectBlack = Create(realName, xStart, yStart); 
                            playerBlack[k] = objectBlack;
                            k++;
                        } else {
                            objectHazard = Create(realName, xStart, yStart);
                            boardHazard[l] = objectHazard;
                            l++;
                        }
                        break;
                    }            
                }
        }
            
        for (int i = 0; i < playerWhite.Length; i++) {
            SetPosition(playerWhite[i]);
        }
        for (int i = 0; i < playerBlack.Length; i++) {
            SetPosition(playerBlack[i]);
        }
        for (int i = 0; i < boardHazard.Length; i++) {
            SetPosition(boardHazard[i]);
        }
        

    }

    public GameObject Create(string name, int x, int y) {
        GameObject obj = Instantiate(Chesspiece, new Vector2(-7.5f, -3.5f), Quaternion.identity);
        PieceController cm = obj.GetComponent<PieceController>();
        cm.name = name;
        cm.SetXBoard(x);
        cm.SetYBoard(y);
        cm.Activate();
        return obj;
    }

    public void SetPosition(GameObject obj) {
        PieceController cm = obj.GetComponent<PieceController>();

        positions[cm.GetXBoard(), cm.GetYBoard()] = obj;
    }

    public void SetPositionEmpty(int x, int y) {
        positions[x,y] = null;
    }

    public GameObject GetPosition(int x, int y) {
        return positions[x,y];
    }

    public bool PositionsOnBoard(int x, int y) {
        if (x < 0 || y < 0 || x >= positions.GetLength(0) || y >= positions.GetLength(1)) {
            return false;
        } else {
            return true;
        }
    }

    public string GetCurrentPlayer() {
        return currentPlayer;
    }

    public void SetPieceNameText(string text) {
        pieceNameText.text = text;
    }

    public void SetPieceDescriptionText(string text) {
        pieceDescriptionText.text = text;
    }

    public bool IsGameOver() {
        return gameOver;
    }

    public void NextTurn() {
        if (currentPlayer == "white") {
            currentPlayer = "black";
        } else {
            currentPlayer = "white";
        }
    }

    public void Winner(string playerWinner) {

        if (playerWinner == "white") {
            mainManager.GetComponent<MainManager>().numWins += 1;
            mainManager.GetComponent<MainManager>().money += 50;
            pieceNameText.text = "You Won!";
            
        } else {
            mainManager.GetComponent<MainManager>().numLoss += 1;
            mainManager.GetComponent<MainManager>().money += 25;
            pieceNameText.text = "You Lost!";
        }
        pieceDescriptionText.text = "Click anywhere to return to the map.";
        gameOver = true;
    }

    void toMap() {
        SceneManager.LoadScene("Map");
    }

    void toPauseMenu() {
        pauseMenu.SetActive(true);
        optionsMenu.SetActive(false);
    }

    void toOptions() {
        optionsMenu.SetActive(true);
        pauseMenu.SetActive(false);
    }

    void resumeGame() {
        pauseMenu.SetActive(false);
        optionsMenu.SetActive(false);
        pauseActive = !pauseActive;
    }

    public void onValueChanged(TMP_Dropdown change) {
        switch (change.value) {
            case 0:
                mainManager.GetComponent<MainManager>().gameColor = "blue";
                //background.GetComponent<SpriteRenderer>().color = new Color32(29, 0, 0, 255);
                break;
            case 1:
                mainManager.GetComponent<MainManager>().gameColor = "red";
                //background.GetComponent<SpriteRenderer>().color = new Color32(0, 13, 29, 255);
                break;
            case 2:
                mainManager.GetComponent<MainManager>().gameColor = "green";
                //background.GetComponent<SpriteRenderer>().color = new Color32(0, 29, 0, 255);
                break;
            case 3:
                mainManager.GetComponent<MainManager>().gameColor = "yellow";
                //background.GetComponent<SpriteRenderer>().color = new Color32(29, 29, 0, 255);
                break;
        }
        backgroundColor.SetGameColor();
        boardColor.SetGameColor();
    }

    void Quit() {
        Application.Quit();
    }

    // Update is called once per frame
    void Update()
    {
        
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (pauseActive) {
                resumeGame();
            } else {
                toPauseMenu();
                pauseActive = !pauseActive;
            }
        }

        if (gameOver == true && Input.GetMouseButtonDown(0)) {
            gameOver = false;

            SceneManager.LoadScene("Map");
        }
    }
}
