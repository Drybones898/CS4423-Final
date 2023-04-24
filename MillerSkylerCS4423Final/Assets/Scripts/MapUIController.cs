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
    public TMP_Dropdown resolutionDropdown;
    public GameObject optionsMenu;
    public GameObject pauseMenu;
    public Button optionsButton;
    public Button resumeButton;
    public Button confirmButton;
    public Button quitButton;
    public Toggle fullscreenToggle;
    Resolution[] resolutions;

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
        resolutionDropdown.onValueChanged.AddListener(delegate {
                onResolutionChanged(resolutionDropdown);
            });
        resumeButton.onClick.AddListener(resumeGame);
        optionsButton.onClick.AddListener(toOptions);
        confirmButton.onClick.AddListener(toPauseMenu);
        quitButton.onClick.AddListener(Quit);

        fullscreenToggle.onValueChanged.AddListener(delegate {
            SetFullScreen();
        });

        fullscreenToggle.isOn = Screen.fullScreen;
        resolutions = Screen.resolutions;
        resolutionDropdown.options = new List<TMP_Dropdown.OptionData>();

        for(int i = 0; i<resolutions.Length; i++){
            string resolutionString = resolutions[i].width + "x" + resolutions[i].height + " " + resolutions[i].refreshRate + "Hz";
            resolutionDropdown.options.Add(new TMP_Dropdown.OptionData(resolutionString));

            //set to be our default
            if(PlayerPrefs.GetInt("set default resolution") == 0){
                if(resolutions[i].width == Screen.currentResolution.width && resolutions[i].height == Screen.currentResolution.height){
                    resolutionDropdown.value = i;
                    PlayerPrefs.SetInt("set default resolution",1);
                    SetResolution();
                }
            }
        }
        resolutionDropdown.value = PlayerPrefs.GetInt("resolution");
        gameColorDropdown.value = PlayerPrefs.GetInt("colorIndex");
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
        PlayClickSound();
        pauseMenu.SetActive(true);
        optionsMenu.SetActive(false);
    }

    void toOptions() {
        PlayClickSound();
        optionsMenu.SetActive(true);
        pauseMenu.SetActive(false);
    }

    void resumeGame() {
        PlayClickSound();
        pauseMenu.SetActive(false);
        optionsMenu.SetActive(false);
        pauseActive = !pauseActive;
    }

    public void onValueChanged(TMP_Dropdown change) {
        int index = change.value;
        List<TMP_Dropdown.OptionData> menuOptions = change.GetComponent<TMP_Dropdown>().options;
        string value = menuOptions[index].text;
        PlayerPrefs.SetString("color",value);
        PlayerPrefs.SetInt("colorIndex",gameColorDropdown.value);
    }

    void Quit() {
        Application.Quit();
    }

    public void SetResolution(){
        Screen.SetResolution(resolutions[resolutionDropdown.value].width,resolutions[resolutionDropdown.value].height,Screen.fullScreen);
        PlayerPrefs.SetInt("resolution",resolutionDropdown.value);
    }

    public void SetFullScreen(){
        Screen.fullScreen = fullscreenToggle.isOn;
    }

    public void onResolutionChanged(TMP_Dropdown change) {
        Screen.SetResolution(resolutions[resolutionDropdown.value].width,resolutions[resolutionDropdown.value].height,Screen.fullScreen);
        PlayerPrefs.SetInt("resolution",resolutionDropdown.value);
    }

    void Sabotage() {
        PlayClickSound();
        if (mainManager.GetComponent<MainManager>().money >= 100) {
            mainManager.GetComponent<MainManager>().money -= 100;
            moneyText.text = "Money: " + mainManager.GetComponent<MainManager>().money;
            mainManager.GetComponent<MainManager>().sabotage = true;
        }
    }

    void Support() {
        PlayClickSound();
        if (mainManager.GetComponent<MainManager>().money >= 100) {
            mainManager.GetComponent<MainManager>().money -= 100;
            moneyText.text = "Money: " + mainManager.GetComponent<MainManager>().money;
            mainManager.GetComponent<MainManager>().support = true;
        }
    }

    public void PlayClickSound() {
        GetComponent<AudioSource>().Play();
    }
}
