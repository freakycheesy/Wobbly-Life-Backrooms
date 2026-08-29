using ModWobblyLife.Network;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class AIController : ModNetworkBehaviour
{
    private NavMeshAgent agent;
    public Transform center;
    public AIHead head;
    public AIEars ears;
    public bool TryGetHead(out AIHead head)
    {
        head = this.head;
        return head != null;
    }
    public bool TryGetEars(out AIEars ears)
    {
        ears = this.ears;
        return ears != null;
    }
    private void Start()
    {
        agent = GetComponent<NavMeshAgent>();
    }
    public bool MoveTowards(Vector3 position) => agent.SetDestination(position);
}
