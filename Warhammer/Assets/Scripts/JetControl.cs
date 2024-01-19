using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JetControl : MonoBehaviour
{
    Vector3 velocity, accelaration;
    float Thrustvalue = 100f, turningSpeed = 180, resistance = 2f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        accelaration = Vector3.zero;
        if (shouldThrust()) Thrust();
        if (shouldTurnLeft()) TurnLeft();
        if (shouldTurnRight()) TurnRight();
        if (shouldSlow()) SlowDown();
        

        accelaration -= resistance * velocity;
        velocity+=accelaration * Time.deltaTime;
        transform.position += velocity * Time.deltaTime;
    }

    private void SlowDown()
    {
        accelaration -= Thrustvalue * transform.forward;
    }

    private bool shouldSlow()
    {
        return Input.GetKey(KeyCode.S);
    }

    private void TurnRight()
    {
        transform.Rotate(transform.up, -turningSpeed * Time.deltaTime);
    }

    private bool shouldTurnRight()
    {
        return Input.GetKey(KeyCode.D);
    }

    private void TurnLeft()
    {
        transform.Rotate(transform.up, turningSpeed * Time.deltaTime);
    }

    private bool shouldTurnLeft()
    {
        return Input.GetKey(KeyCode.A);
    }

    private void Thrust()
    {
        accelaration = Thrustvalue * transform.forward;
    }

    private bool shouldThrust()
    {
        return Input.GetKey(KeyCode.W);
    }
}
