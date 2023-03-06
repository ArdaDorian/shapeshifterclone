using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UI_ButtonController : MonoBehaviour
{
    [SerializeField] Button startButton;
    [SerializeField] Button[] restartButton;
    [SerializeField] Button pauseButton;
    [SerializeField] Button resumeButton;
    [SerializeField] Button nextLevelButton;

    LevelManager levelManager;

    private void Awake()
    {
        levelManager = FindObjectOfType<LevelManager>();
    }

    private void Start()
    {
        startButton.onClick.AddListener(levelManager.StartLevel);
        AddListenerToRestart();
        pauseButton.onClick.AddListener(levelManager.PauseLevel);
        resumeButton.onClick.AddListener(levelManager.ResumeLevel);
        nextLevelButton.onClick.AddListener(levelManager.LoadNextLevel);
    }

    void AddListenerToRestart()
    {
        foreach (Button button in restartButton)
        {
            button.onClick.AddListener(levelManager.RestartLevel);
        }
    }
}
