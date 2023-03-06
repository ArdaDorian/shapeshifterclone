using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinManager : MonoBehaviour
{
    bool isCollected;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("collector") && !isCollected)
        {
            isCollected= true;
            other.GetComponent<Collector>().IncreaseCoin();
            Destroy(gameObject);
        }
    }
}
