using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AIEars : MonoBehaviour
{
    private AIController controller;
    public float hearingDistance = 20;
    private void Start()
    {
        controller = GetComponentInParent<AIController>();
    }
    public void CheckNoise(Vector3 position, float radius)
    {
        if (Vector3.Distance(position, transform.position) <= radius || Vector3.Distance(transform.position, position) <= hearingDistance)
        {
            controller.MoveTowards(position);
        }
    }
    private void OnDrawGizmos()
    {
        Gizmos.color = Color.green;
        Gizmos.DrawWireSphere(transform.position, hearingDistance);
    }
}
