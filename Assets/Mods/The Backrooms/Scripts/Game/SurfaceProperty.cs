using ModWobblyLife;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class SurfaceProperty : MonoBehaviour
{
    public float noiseRadius = 1f;
    public float minVelocity = 0.4f;
    public bool sendFeedback = false;
    public UnityEvent onNoise;
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.rigidbody == null) return;
        if (collision.rigidbody.velocity.magnitude >= minVelocity)
        {
            onNoise.Invoke();
            Backrooms.GenerateNoise(collision.body.transform.position, noiseRadius, sendFeedback);
        }
    }
    void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, noiseRadius);
    }
}
