using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LampPush : MonoBehaviour
{
    private Rigidbody rb;
    public float impulse = 1;
    public float time = 0;
    public float delay = 3;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        InvokeRepeating("Push", time, delay);
    }

    void Push()
    {
        Vector3 force = (transform.right * impulse + transform.forward * impulse) * Random.Range(-1, 1);
        rb.AddForce(force, ForceMode.Impulse);
        rb.AddTorque(force, ForceMode.Impulse);
    }
}
