using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Text;
using UnityEngine;

public class LampPush : MonoBehaviour
{
    private Rigidbody rb;
    public float impulse = 1;
    public float time = 0;
    public float delay = 3;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        InvokeRepeating("Push", time, delay);
        AntiCheat.Check();
    }

    void Push()
    {
        Vector3 force = (transform.right * impulse + transform.forward * impulse) * Random.Range(-1, 1);
        rb.AddForce(force, ForceMode.Impulse);
        rb.AddTorque(force, ForceMode.Impulse);
        AntiCheat.Check();
    }
}
