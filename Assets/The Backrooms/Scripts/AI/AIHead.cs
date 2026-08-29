using ModWobblyLife;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AIHead : MonoBehaviour
{
    RaycastHit[] results = new RaycastHit[64];
    private AIController controller;
    public float coneRadius = 10f;
    public float coneDistance = 10;
    private ModPlayerCharacter victim;
    private void Start()
    {
        controller = GetComponentInParent<AIController>();
    }
    private void Update()
    {
        int length = Physics.SphereCastNonAlloc(new Ray(transform.position, transform.forward), coneRadius, results, coneDistance);
        for (int i = 0; i < length; i++)
        {
            RaycastHit hit = results[i];
            ModPlayerCharacter player = hit.collider.GetComponentInParent<ModPlayerCharacter>();
            if (player != null)
            {
                victim = player;
            }
        }
        if(victim != null && Vector3.Distance(controller.center.position, victim.GetPlayerPosition())<coneDistance)controller.MoveTowards(victim.GetPlayerPosition());
    }
    private void OnDrawGizmos()
    {
        Gizmos.color = Color.green;
        Vector3 forward = transform.position + (transform.forward * coneDistance);
        Gizmos.DrawLine(transform.position, forward);
        Gizmos.DrawWireSphere(forward, coneRadius);
    }
}
