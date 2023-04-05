using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class MapUIController : MonoBehaviour
{
    public TMP_Text winsText;
    public TMP_Text lossesText;
    public TMP_Text moneyText;
    public Button supportButton;
    public Button sabotageButton;
    public GameObject mainManager;



    public TMP_Dropdown gameColorDropdown;
    public GameObject optionsMenu;
    public GameObject pauseMenu;
    public Button optionsButton;
    public Button resumeButton;
    public Button confirmButton;
    public Button quitButton;

    public bool pauseActive = false;
    // Start is called before the first frame update
    void Start()
    {
        mainManager = GameObject.FindGameObjectWithTag("MainManager");
        winsText.text += mainManager.GetComponent<MainManager>().numWins;
        lossesText.text += mainManager.GetComponent<MainManager>().numLoss;
        moneyText.text += mainManager.GetComponent<MainManager>().money;

        sabotageButton.onClick.AddListener(Sabotage);
        supportButton.onClick.AddListener(Support);

        gameColorDropdown.onValueChanged.AddListener(delegate {
                onValueChanged(gameColorDropdown);
            });
        resumeButton.onClick.AddListener(resumeGame);
        optionsButton.onClick.AddListener(toOptions);
        confirmButton.onClick.AddListener(toPauseMenu);
        quitButton.onClick.AddListener(Quit);
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
    }

    void Quit() {
        Application.Quit();
    }

    void Sabotage() {
        if (mainManager.GetComponent<MainManager>().money >= 100) {
            mainManager.GetComponent<MainManager>().money -= 100;
            moneyText.text = "Money: " + mainManager.GetComponent<MainManager>().money;
            mainManager.GetComponent<MainManager>().sabotage = true;
        }
    }

    void Support() {
        if (mainManager.GetComponent<MainManager>().money >= 100) {
            mainManager.GetComponent<MainManager>().money -= 100;
            moneyText.text = "Money: " + mainManager.GetComponent<MainManager>().money;
            mainManager.GetComponent<MainManager>().support = true;
        }
    }
}
