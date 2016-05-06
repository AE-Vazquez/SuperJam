﻿using UnityEngine;
using System.Collections;

public class ShipController : MonoBehaviour {

    
    public float maxSpeed;

    public float maxRotation;

    public float acceleration;
    public float rotationStep;

    private float currentSpeed;
    private float currentRot;
    private Vector3 constrainedVelocity;
    private Vector3 constraintedRotation;

    private Rigidbody rigidBody;
	// Use this for initialization
	void Start () {
        rigidBody = GetComponent<Rigidbody>();
        constrainedVelocity = new Vector3(1, 0, 0);
        constraintedRotation = new Vector3(0, 0, 1);

    }
	
	// Update is called once per frame
	void Update () {

        if(Input.GetKey(KeyCode.A))
        {
            MoveLeft(1);

        }
        else if(Input.GetKey(KeyCode.D))
        {
            MoveRight(1);    
        }

        currentSpeed = rigidBody.velocity.x;
        rigidBody.rotation = Quaternion.Euler(0, 0, currentSpeed * -rotationStep);

	}


    public void MoveLeft(float force)
    {
        if (rigidBody.velocity.x > -maxSpeed)
        {
            rigidBody.velocity -= constrainedVelocity * acceleration*force;
            currentSpeed -= acceleration;
        }

    }


    public void MoveRight(float force)
    {
        if (rigidBody.velocity.x < maxSpeed)
        {
            rigidBody.velocity += constrainedVelocity * acceleration*force;
        }

    }

    public void ModifyVelocity(float modifier)
    {
        if(modifier>0)
        {
            MoveRight(modifier);
        }
        else if(modifier<0)
        {
            MoveRight(-modifier);
        }
    }

}
