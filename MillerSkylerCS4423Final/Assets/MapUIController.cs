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
    // Start is called before the first frame update
    void Start()
    {
        mainManager = GameObject.FindGameObjectWithTag("MainManager");
        winsText.text += mainManager.GetComponent<MainManager>().numWins;
        lossesText.text += mainManager.GetComponent<MainManager>().numLoss;
        moneyText.text += mainManager.GetComponent<MainManager>().money;

        sabotageButton.onClick.AddListener(Sabotage);
        supportButton.onClick.AddListener(Support);
    }

    // Update is called once per frame
    void Update()
    {
        
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
