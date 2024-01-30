using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JetControl : MonoBehaviour
{
    Rigidbody rb;
    Vector3 velocity, accelaration;
    float Thrustvalue = 100f, turningSpeed = 180, resistance = 2f;
    Animation shipAnimations;
    // Start is called before the first frame update
    void Start()
    {
        shipAnimations = GetComponentInChildren<Animation>();
        rb = GetComponentInChildren<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        accelaration = Vector3.zero;
        if (shouldThrust()) Thrust();
        if (shouldTurnLeft()) TurnLeft();
        if (shouldTurnRight()) TurnRight();
        if (shouldSlow()) SlowDown();
        if (shouldRollLeft()) RollLeft();
        if (shouldRollRight()) RollRight();
        if (shouldPitchUp()) PitchUp();
        if (shouldPitchDown()) PitchDown();



        accelaration -= resistance * velocity;
        velocity+=accelaration * Time.deltaTime;
        transform.position += velocity * Time.deltaTime;
    }

    private void PitchDown()
    {
        transform.Rotate(Vector3.left, -turningSpeed * Time.deltaTime);
    }

    private bool shouldPitchDown()
    {
        return Input.GetKey(KeyCode.DownArrow);
    }

    private void PitchUp()
    {
        transform.Rotate(Vector3.left, turningSpeed * Time.deltaTime);
    }

    private bool shouldPitchUp()
    {
        return Input.GetKey(KeyCode.UpArrow);
    }

    private void RollRight()
    {
        transform.Rotate(Vector3.forward, -turningSpeed * Time.deltaTime);
    }

    private bool shouldRollRight()
    {
        return Input.GetKey(KeyCode.RightArrow);
    }

    private void RollLeft()
    {
        transform.Rotate(Vector3.forward, turningSpeed * Time.deltaTime);
    }

    private bool shouldRollLeft()
    {
       return Input.GetKey(KeyCode.LeftArrow);
    }

    private void SlowDown()
    {
        rb.AddForce(-Thrustvalue * transform.forward);
    }

    private bool shouldSlow()
    {
        return Input.GetKey(KeyCode.S);
    }

    private void TurnRight()
    {
        transform.Rotate(Vector3.up, -turningSpeed * Time.deltaTime);
    }

    private bool shouldTurnRight()
    {
        return Input.GetKey(KeyCode.D);
    }

    private void TurnLeft()
    {
        transform.Rotate(Vector3.up, turningSpeed * Time.deltaTime);
    }

    private bool shouldTurnLeft()
    {
        return Input.GetKey(KeyCode.A);
    }

    private void Thrust()
    {
        rb.AddForce( Thrustvalue * transform.forward);
    }

    private bool shouldThrust()
    {
        return Input.GetKey(KeyCode.W);
    }
}
