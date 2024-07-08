using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimerScript : MonoBehaviour
{
    int sec;
    float zecimi;
    string zecimiString;
    float timer;
    public GameObject timerDisplay;
    // Start is called before the first frame update
    private void Awake()
    {
        
    }
    void Start()
    {
        zecimiString = "00";
        zecimi = 0;
        sec = 0;
        timer = 30;
    }

    // Update is called once per frame
    void Update()
    {
        if (timer > 0)
        {
            timer -= Time.deltaTime;
            zecimiString = "00";
            ShowTimer();
        }
        else
        {
            timer = 0;
        }
    }
    void ShowTimer()
    {
        sec = (int)timer;
        zecimi = (int)((timer - sec) * 100000 / 1000);
        if (zecimi > 9)
            zecimiString = zecimi.ToString();
        else
            zecimiString = "0" + zecimi.ToString();
        timerDisplay.GetComponent<TMPro.TextMeshPro>().text = sec.ToString() + ":" + zecimiString;
    }
}
