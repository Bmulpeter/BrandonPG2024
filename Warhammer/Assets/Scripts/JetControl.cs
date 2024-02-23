using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JetControl : MonoBehaviour
{
    Rigidbody rb;
    OutOfBounds textWarning;
    Vector3 velocity, accelaration;
    float Thrustvalue = 150f, turningSpeed = 180, resistance = 2f;
    Animation shipAnimations;
    private float max_distance = 1500;
    private float closeToBorder = 1000;
    private float OutOfBounds = 800;

    // Start is called before the first frame update
    void Start()
    {   
        textWarning = FindObjectOfType<OutOfBounds>();

        shipAnimations = GetComponentInChildren<Animation>();
        rb = GetComponentInChildren<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        if (transform.position.magnitude > max_distance)
            textWarning.warning("Game Over");


        if (transform.position.magnitude > closeToBorder)
            print("Turn Back");
        if (transform.position.magnitude > OutOfBounds)
            print("Out of Bounds");
        accelaration = Vector3.zero;
        if (shouldThrust()) Thrust();
        if (shouldTurnLeft()) TurnLeft();
        if (shouldTurnRight()) TurnRight();
        if (shouldSlow()) SlowDown();
        if (shouldRollLeft()) RollLeft();
        if (shouldRollRight()) RollRight();
        if (shouldPitchUp()) PitchUp();
        if (shouldPitchDown()) PitchDown();
        



       //// accelaration -= resistance * velocity;
       // transform.position += velocity * Time.deltaTime;
    }

    private void PitchDown()
    {
        rb.AddRelativeTorque(Vector3.right *100);
        //transform.Rotate(Vector3.left, turningSpeed * Time.deltaTime);
    }

    private bool shouldPitchDown()
    {
        return Input.GetKey(KeyCode.DownArrow);
    }

    private void PitchUp()
    {
        rb.AddRelativeTorque(-Vector3.right * 100);
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
        transform.Rotate(Vector3.up, turningSpeed * Time.deltaTime);
    }

    private bool shouldTurnRight()
    {
        return Input.GetKey(KeyCode.D);
    }

    private void TurnLeft()
    {
        transform.Rotate(Vector3.up, -turningSpeed * Time.deltaTime);
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
