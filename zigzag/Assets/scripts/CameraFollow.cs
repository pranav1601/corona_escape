﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour {
    public GameObject ball;
    Vector3 offset;
    public bool GameOVer;
    public float lerpRate;


	// Use this for initialization
	void Start () {
        offset = ball.transform.position - transform.position;
        GameOVer = false;

		
	}
	
	// Update is called once per frame
	void Update () {
        if(!GameOVer)
        {
            Follow();
        }
		
	}

    void Follow()
    {
        Vector3 pos = transform.position;
        Vector3 targetPos = ball.transform.position - offset;
        pos=Vector3.Lerp(pos, targetPos, lerpRate * Time.deltaTime);
        transform.position = pos;
    }
}
