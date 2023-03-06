using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreIncreaser : MonoBehaviour
{
    bool increased;

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player") && !increased)
        {
            increased= true;
            FindObjectOfType<LevelScoreKeeper>().IncreaseScore();
        }
    }
}
