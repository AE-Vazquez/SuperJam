﻿using UnityEngine;
using System.Collections;

public class Star : MonoBehaviour {


    public float pointReward;

    public float energyReward;

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
        transform.Translate(direction * manager.currentSpeed * Time.deltaTime);
    }

    public void DestroyStar()
    {
        Destroy(gameObject);
    }


}
