using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelScoreKeeper : MonoBehaviour
{
    int score;
    int coin;

    public event Action OnCoinChanged;
    public event Action OnScoreChanged;

    private void Start()
    {
        score= 0;
        coin=0;
    }

    public void IncreaseScore()
    {
        score++;
        OnScoreChanged();
    }

    public void IncreaseCoin()
    {
        coin++;
        OnCoinChanged();
    }

    public int GetScore()
    {
        return score;
    }

    public int GetCoin()
    {
        return coin;
    }

}
