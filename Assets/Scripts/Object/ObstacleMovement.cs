using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleMovement : MonoBehaviour
{
    Vector3 startPos;
    [SerializeField] Vector3 movementVector;
    [SerializeField][Range(0,1)] float movementFac;
    [SerializeField] float period;
    void Start()
    {
        startPos= transform.position;
    }

    void Update()
    {
        if (period <= Mathf.Epsilon) { return; }

        float cycles = Time.time / period;

        const float tau = Mathf.PI * 2;
        float sinWave = Mathf.Sin(cycles*tau);

        movementFac = (sinWave +1f) / 2f;

        Vector3 movementOffSet = movementVector*movementFac;
        transform.position = startPos + movementOffSet;
    }
}
