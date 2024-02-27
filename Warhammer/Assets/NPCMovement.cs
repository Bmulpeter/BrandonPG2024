using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class NPCMovement : MonoBehaviour
{
    // Start is called before the first frame update
    JetControl myTarget;
    Rigidbody rb;
    private float thrustValue= 20f;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        myTarget = FindObjectOfType<JetControl>();
        if (myTarget) print("I Found the jet");
    }

    // Update is called once per frame
    void Update()
    {
        transform.LookAt(myTarget.transform);
        rb.AddForce(thrustValue *transform.forward);
    }
}
