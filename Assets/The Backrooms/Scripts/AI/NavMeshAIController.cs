using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class NavMeshAIController : AIController
{
    private NavMeshAgent agent;
    protected override void Start()
    {
        agent = GetComponent<NavMeshAgent>();
    }

    public override bool MoveTowards(Vector3 position) => agent.SetDestination(position);
}
