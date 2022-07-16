using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;
using UnityEngine.Events;

public class EventManager : MonoBehaviour
{
    public static event Action TimedEvent;
    float timer;
    [SerializeField] float timerLimit = 1f;

    void Start()
    {

    }

    void Update()
    {
        timer += Time.deltaTime;
        if (timer >= timerLimit) {
            TimedEvent?.Invoke();
            timer = 0;
        }
    }
}
