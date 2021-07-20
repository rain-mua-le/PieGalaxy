using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HUD : MonoBehaviour
{
    public Canvas canvas;
    public Text time;
    public Text money; 
    private static HUD _instance;

    public static HUD Instance { get { return _instance; } }

    private void Awake()
    {
        if (_instance != null && _instance != this)
        {
            Destroy(this.gameObject);
        } 
        else {
            _instance = this;
        }
        DontDestroyOnLoad(this);
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        time.text = "Time: " + convertToTime(Timer.Instance.time);
        money.text = "Money: " + Stats.Instance.money;
    }

    string convertToTime(int num) {
        string after = "";
        if (num % 100 / 10 == 0) 
        {
            after = "0" + num % 100;
        }
        else
        {
            after = (num % 100).ToString();
        }
        if (num / 100 < 12)
        {
            return num / 100 + ":" + after + " am";
        }
        else if (num / 100 == 12)
        {
            return num / 100 + ":" + after + " pm";
        }
        else 
        {
            return num / 100 - 12 + ":" + after + " pm";
        }
    }
}
