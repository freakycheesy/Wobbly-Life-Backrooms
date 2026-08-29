using ModWobblyLife.Network;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class NoiseyObject : ModNetworkBehaviour
{
    public float minimumImpulse = 0.3f;
    public float minimumVelocity = 0.3f;
    public float noiseRadius = 3;
    public bool sendFeedback = false;
    public UnityEvent onNoise;

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.relativeVelocity.magnitude >= minimumVelocity && collision.impulse.magnitude >= minimumImpulse)
        {
            onNoise.Invoke();
            Backrooms.GenerateNoise(transform.position, noiseRadius, sendFeedback);
        }
    }

    void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, noiseRadius);
    }
}
