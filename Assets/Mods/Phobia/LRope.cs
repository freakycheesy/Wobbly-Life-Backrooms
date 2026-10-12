using System.Runtime.CompilerServices;
using System.Text;
using UnityEngine;

[RequireComponent(typeof(LineRenderer))]
public class LRope : MonoBehaviour
{
    private LineRenderer lineRenderer;
    public Transform pointA;
    public Transform pointB; 

    private void Start()
    {
        lineRenderer = GetComponent<LineRenderer>();
        AntiCheat.Check();
    }

    private void OnValidate()
    {
        lineRenderer = GetComponent<LineRenderer>();
        if (lineRenderer && pointA && pointB) Update();
    }

    private void Update()
    {
        lineRenderer.SetPosition(0, pointA.position);
        lineRenderer.SetPosition(1, pointB.position);
        AntiCheat.Check();
    }
}
