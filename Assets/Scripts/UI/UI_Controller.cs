using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UI_Controller : MonoBehaviour
{
    UI_Menu menu_UI;
    UI_Gameplay gamePlay_UI;
    LevelManager levelManager;

    LevelScoreKeeper levelScoreKeeper;

    private void Awake()
    {
        menu_UI = FindObjectOfType<UI_Menu>();
        gamePlay_UI = FindObjectOfType<UI_Gameplay>();
        levelManager = FindObjectOfType<LevelManager>();
    }

    private void Start()
    {
        AddActions();
        levelScoreKeeper = FindObjectOfType<LevelScoreKeeper>();
    }

    void ClosePausePanel()
    {
        gamePlay_UI.DisplayPausePanel(false);
    }

    void ShowPausePanel()
    {
        gamePlay_UI.DisplayPausePanel(true);
    }

    void StartLevel()
    {
        SetUI(false, true);
        menu_UI.HideStartButton();
    }

    void FinishLevel()
    {
        menu_UI.ShowFinishScreen();
        SetUI(true, false);
    }

    void ApplyCrash()
    {
        SetUI(true, false);
        menu_UI.ShowCrashPanel();
        
    }

    public void SetUI(bool menu, bool gameplay)
    {
        menu_UI.gameObject.SetActive(menu);
        gamePlay_UI.gameObject.SetActive(gameplay);
    }

    void DisplayScores()
    {
        menu_UI.DisplayTexts(levelScoreKeeper.GetCoin().ToString(), levelScoreKeeper.GetScore().ToString(), 
                             GameScoreKeeper.instance.GetTotalCoin().ToString(), GameScoreKeeper.instance.GetTotalScore().ToString());
    }

    private void OnDestroy()
    {
        RemoveActions();
    }


    void AddActions()
    {
        levelManager.OnPaused += ShowPausePanel;
        levelManager.OnResumed += ClosePausePanel;
        levelManager.OnStarted += StartLevel;
        levelManager.OnFinished += FinishLevel;
        levelManager.OnFinished += DisplayScores;
        levelManager.OnCrashed += ApplyCrash;
    }

    private void RemoveActions()
    {
        levelManager.OnPaused -= ShowPausePanel;
        levelManager.OnResumed -= ClosePausePanel;
        levelManager.OnStarted -= StartLevel;
        levelManager.OnCrashed -= ApplyCrash;
        levelManager.OnFinished -= DisplayScores;
        levelManager.OnFinished -= FinishLevel;
    }
}
