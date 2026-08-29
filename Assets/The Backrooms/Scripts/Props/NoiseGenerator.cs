using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class NoiseGenerator : MonoBehaviour
{
    public float noiseRadius = 1.0f;
    public bool sendFeedback = false;
    public Transform overrideTransform;

    private void OnValidate()
    {
        overrideTransform = transform;
    }
    public void GenerateNoise()
    {
        Backrooms.GenerateNoise(overrideTransform.position, noiseRadius, sendFeedback);
    }
    void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(overrideTransform.position, noiseRadius);
    }
}
