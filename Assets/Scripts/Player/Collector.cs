using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collector : MonoBehaviour
{
    LevelScoreKeeper scoreKeeper;

    void Awake()
    {
        scoreKeeper = FindObjectOfType<LevelScoreKeeper>();
    }

    public void IncreaseCoin()
    {
        scoreKeeper.IncreaseCoin();
    }
}
