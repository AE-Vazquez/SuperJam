﻿using UnityEngine;
using System.Collections;

public class Obstacle : MonoBehaviour {

    private Vector3 direction;

    [HideInInspector]
    public ParallaxManager manager;

    void Start()
    {
        direction = new Vector3(0, 0, -1);

    }

    // Update is called once per frame
    void Update()
    {
        if (manager != null)
        {
            transform.Translate(direction * manager.currentSpeed * Time.deltaTime,Space.World);
        }
    }

    public float GetCurrentSpeed()
    {
        return manager.currentSpeed;
    }

   

}
