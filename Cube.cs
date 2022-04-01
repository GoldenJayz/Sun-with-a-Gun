using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cube : MonoBehaviour
{
    public Rigidbody rb;
    public float force = 20f;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey("w")) rb.AddForce(new Vector3(1.0f, 0f, 0f) * force);
        else if (Input.GetKey("s")) rb.AddForce(new Vector3(-1.0f, 0f, 0f) * force);
        else if (Input.GetKey("d")) rb.AddForce(new Vector3(1.0f, 0f, -1.0f) * force);
        else if (Input.GetKey("a")) rb.AddForce(new Vector3(1.0f, 0f, 1.0f) * force);


    }
}
