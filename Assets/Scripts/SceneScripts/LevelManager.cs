using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour
{
    public event Action OnPaused;
    public event Action OnResumed;
    public event Action OnFinished;
    public event Action OnCrashed;
    public event Action OnStarted;

    UI_Controller controller_UI;

    bool isMoving;

    private void Awake()
    {
        controller_UI = FindObjectOfType<UI_Controller>();
    }

    private void Start()
    {
        controller_UI.SetUI(true, false);
    }

    public void StartLevel() // Button and UI
    {
        SetIsMoving(true);
        OnStarted();
    }
   
    public void EndLevel() // Accesed by FinishLine
    {
        GameScoreKeeper.instance.AddInTotal();
        SetIsMoving(false);
        OnFinished();
    }

    public void ApplyCrash() // Accesed by CollisionDetector
    {
        SetIsMoving(false);
        OnCrashed();
    }

    public void PauseLevel() // Button and UI
    {
        OnPaused();
        Time.timeScale = 0f;
    }

    public void ResumeLevel() // Button and UI
    {
        Time.timeScale = 1f;
        OnResumed();
    }

    public void RestartLevel() // Only Button
    {
        Time.timeScale= 1.0f;
        int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadScene(currentSceneIndex);
    }

    public void LoadNextLevel() // Only Button
    {
        int nextSceneIndex = SceneManager.GetActiveScene().buildIndex+1;
        
        if (nextSceneIndex == SceneManager.sceneCountInBuildSettings)
        {
            nextSceneIndex = 0;
        }

        SceneManager.LoadScene(nextSceneIndex);
    }


    public bool GetIsMoving() 
    {
        return isMoving;
    }

    public void SetIsMoving(bool statue)
    {
        isMoving= statue;
    }
}
