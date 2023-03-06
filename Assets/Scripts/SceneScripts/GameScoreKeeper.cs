using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameScoreKeeper : MonoBehaviour
{
    int totalScore;
    int totalCoin;

    public static GameScoreKeeper instance;

    private void Awake()
    {
        ManageSingleton();
    }

    public void AddInTotal()
    {
        AddScoreInTotal();
        AddCoinInTotal();
    }

    void AddScoreInTotal()
    {
        totalScore += FindObjectOfType<LevelScoreKeeper>().GetScore();
    }

    void AddCoinInTotal()
    {
        totalCoin += FindObjectOfType<LevelScoreKeeper>().GetCoin();
    }

    public int GetTotalScore()
    {
        return totalScore;
    }

    public int GetTotalCoin()
    {
        return totalCoin;
    }

    private void ManageSingleton()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    
}
