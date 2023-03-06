using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class UI_Gameplay : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI coinText;
    [SerializeField] TextMeshProUGUI scoreText;

    [SerializeField] GameObject pausePanel;

    LevelScoreKeeper levelScoreKeeper;


    private void Awake()
    {
        levelScoreKeeper = FindObjectOfType<LevelScoreKeeper>();
    }

    private void Start()
    {
        AddAction();
        coinText.text = PrintText(levelScoreKeeper.GetCoin());
        scoreText.text = PrintText(levelScoreKeeper.GetScore());

    }

    void AdjustCoinText()
    {
        coinText.text = PrintText(levelScoreKeeper.GetCoin());
    }

    void AdjustScoreText()
    {
        scoreText.text = PrintText(levelScoreKeeper.GetScore());
    }

    public void DisplayPausePanel(bool statue)
    {
        pausePanel.SetActive(statue);
    }

    string PrintText(int score)
    {
        string newText = score.ToString("00");
        return newText;
    }

    private void OnDestroy()
    {
        RemoveAction();
    }
    private void AddAction()
    {
        levelScoreKeeper.OnCoinChanged += AdjustCoinText;
        levelScoreKeeper.OnScoreChanged += AdjustScoreText;
    }

    private void RemoveAction()
    {
        levelScoreKeeper.OnCoinChanged -= AdjustCoinText;
        levelScoreKeeper.OnScoreChanged -= AdjustScoreText;
    }


}
