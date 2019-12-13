using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CTFGameManager : Singleton<CTFGameManager>
{
    public Text countdown;
    public int totalSeconds = 600;
    private float _leftSeconds;


    // Start is called before the first frame update
    void Start()
    {
        Time.timeScale = 1;
        _leftSeconds = totalSeconds;
        int _minutes = (int) (totalSeconds / 60);
        int _seconds = totalSeconds % 60;
        countdown.text = _minutes + " : " + _seconds;
    }

    // Update is called once per frame
    void Update()
    {
        CountDown();
    }

    private void CountDown()
    {
        _leftSeconds -= Time.deltaTime;
        int _minutes = (int)(_leftSeconds / 60);
        int _seconds = (int)_leftSeconds % 60;
        countdown.text = _minutes + " : " + _seconds;
    }
}
