using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Clock : MonoBehaviour
{

    const float 
        degreesPerHour = 30f,
        degreesPerMinute = 6f,
        degreesPerSecond = 6f;

    public bool isContinuous;

    public Transform hoursTransform, minutesTransform, secondsTransform;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (isContinuous)
        {
            UpdateContinuous();
        } 
        else
        {
            UpdateDiscrete();
        }
    }

    void Awake()
    {
        var now = DateTime.Now;
        Debug.Log(now);
        hoursTransform.localRotation = Quaternion.Euler(0f, now.Hour * degreesPerHour, 0f);
        minutesTransform.localRotation = Quaternion.Euler(0f, now.Minute * degreesPerMinute, 0f);
        secondsTransform.localRotation = Quaternion.Euler(0f, now.Second * degreesPerSecond, 0f);
    }

    void UpdateContinuous()
    {
        var now = DateTime.Now.TimeOfDay;
        hoursTransform.localRotation = Quaternion.Euler(0f, (float) now.TotalHours * degreesPerHour, 0f);
        minutesTransform.localRotation = Quaternion.Euler(0f, (float) now.TotalMinutes * degreesPerMinute, 0f);
        secondsTransform.localRotation = Quaternion.Euler(0f, (float) now.TotalSeconds * degreesPerSecond, 0f);
    }

    void UpdateDiscrete()
    {
        var now = DateTime.Now;
        hoursTransform.localRotation = Quaternion.Euler(0f, now.Hour * degreesPerHour, 0f);
        minutesTransform.localRotation = Quaternion.Euler(0f, now.Minute * degreesPerMinute, 0f);
        secondsTransform.localRotation = Quaternion.Euler(0f, now.Second * degreesPerSecond, 0f);
    }
}
