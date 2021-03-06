﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimeOnLevel : MonoBehaviour
{
    private float timerS;
    private int timerM;
    bool timerStop;
    // Start is called before the first frame update
    void Start()
    {
        timerS = 0.0f;
        timerM = 0;
        timerStop = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (!timerStop)
        {
            timerS += Time.deltaTime;
            if (timerS > 60)
            {
                timerS = 0;
                timerM++;
            }
        }
    }
    public int GetSeconds()
    {
        return (int)timerS;
    }
    public float getMinutes()
    {
        return timerM;
    }
    public void SetTimerStop(bool v)
    {
        timerStop = v;
    }
}
