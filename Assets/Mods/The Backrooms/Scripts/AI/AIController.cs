using ModWobblyLife.Network;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public abstract class AIController : ModNetworkBehaviour
{
    public Transform center;
    public AIHead head;
    public AIEars ears;
    [SerializeField] private IAILimb[] aiLimbs;
    private void Awake()
    {
        aiLimbs = GetComponentsInChildren<IAILimb>();
    }
    public IAILimb[] GetAILimbs() => aiLimbs;
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
    protected abstract void Start();
    public abstract bool MoveTowards(Vector3 position);

    public void OnUpdate()
    {
        foreach (IAILimb limb in aiLimbs)
        {
            limb.OnUpdate();
        }
    }
    public void OnFixedUpdate()
    {
        foreach (IAILimb limb in aiLimbs)
        {
            limb.OnFixedUpdate();
        }
    }
    public void OnLateUpdate()
    {
        foreach (IAILimb limb in aiLimbs)
        {
            limb.OnLateUpdate();
        }
    }
}
