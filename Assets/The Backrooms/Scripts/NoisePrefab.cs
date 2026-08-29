using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NoisePrefab : MonoBehaviour
{
    private float radius = 1f;
    public void ModStart(Vector3 position, float radius)
    {
        transform.position = position;
        this.radius = radius;
        transform.localScale = Vector3.zero;
        Destroy(gameObject, radius);
    }

    private void Update()
    {
        transform.localScale = Vector3.MoveTowards(transform.localScale, Vector3.one * radius, radius * Time.deltaTime);
    }
}
