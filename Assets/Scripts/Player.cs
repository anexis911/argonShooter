﻿using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;

public class Player : MonoBehaviour
{
    // Start is called before the first frame update
    [Tooltip("In ms")][SerializeField] float xSpeed = 10f;
    [SerializeField] float positionPitchFactor = -5f;
    float xThrow, yThrow;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        ProcessTranslation();
        ProcessRotation();
    }

    private void ProcessRotation()
    {
        float pitch = transform.localPosition.y * positionPitchFactor+ yThrow* (-20f);
        float yaw = transform.localPosition.x * -positionPitchFactor + xThrow * (20f);
        float roll = xThrow * -20f;
        transform.localRotation = Quaternion.Euler(pitch, yaw, roll);
    }

    private void ProcessTranslation()
    {
        xThrow = CrossPlatformInputManager.GetAxis("Horizontal");
        yThrow = CrossPlatformInputManager.GetAxis("Vertical");


        float xOffset = xThrow * Time.deltaTime * xSpeed;
        float yOffset = yThrow * Time.deltaTime * xSpeed;
        float raNewXPos = Mathf.Clamp(transform.localPosition.x + xOffset, -6f, 6f);
        float raNewYPos = Mathf.Clamp(transform.localPosition.y + yOffset, -3f, 3f);
        transform.localPosition = new Vector3(raNewXPos, raNewYPos, transform.localPosition.z);
    }
}