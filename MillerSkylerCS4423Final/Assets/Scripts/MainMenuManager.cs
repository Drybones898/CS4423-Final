using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

public class MainMenuManager : MonoBehaviour
{
    GameObject mainManager;
    [Header("Background Color Stuff")]
    public BackgroundColorController backgroundColor;
    public TMP_Dropdown gameColorDropdown;
    public GameObject optionsMenu;
    public GameObject mainMenu;
    public Button startButton;
    public Button optionsButton;
    public Button confirmButton;
    public Button quitButton;
    
    // Start is called before the first frame update
    void Start()
    {
        mainManager = GameObject.FindGameObjectWithTag("MainManager");

        //Add listener for when the value of the Dropdown changes, to take action
        gameColorDropdown.onValueChanged.AddListener(delegate {
                onValueChanged(gameColorDropdown);
            });
        startButton.onClick.AddListener(startGame);
        optionsButton.onClick.AddListener(toOptions);
        confirmButton.onClick.AddListener(toMainMenu);
        quitButton.onClick.AddListener(Quit);
    }

    // Update is called once per frame
    void Update()
    {
        
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
    }

    void startGame() {
        SceneManager.LoadScene("Map");
    }

    void toOptions() {
        mainMenu.SetActive(false);
        optionsMenu.SetActive(true);
    }

    void toMainMenu() {
        mainMenu.SetActive(true);
        optionsMenu.SetActive(false);
    }

    void Quit() {
        Application.Quit();
    }
}