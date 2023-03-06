using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class UI_Menu : MonoBehaviour
{
    [SerializeField] GameObject playButton;
    [SerializeField] GameObject finishPanel;
    [SerializeField] GameObject crashPanel;

    [SerializeField] TextMeshProUGUI levelCoin_text, levelScore_text;
    [SerializeField] TextMeshProUGUI totalCoin_text, totalScore_text;

    public void ShowFinishScreen()
    {
        finishPanel.SetActive(true);
    }

    public void HideStartButton()
    {
        playButton.SetActive(false);
    }

    public void ShowCrashPanel()
    {
        crashPanel.SetActive(true);
    }

    public void DisplayTexts(string levelCoin, string levelScore, string totalCoin, string totalScore)
    {
        levelCoin_text.text = "Coin: " +levelCoin;
        levelScore_text.text = "Score: "+levelScore;
        totalCoin_text.text = "Coin: " + totalCoin;
        totalScore_text.text = "Score: " + totalScore;
    }

}
