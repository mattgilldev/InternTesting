using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using TMPro;
using System.Diagnostics;
using System;

public class ColliderScript : MonoBehaviour
{
    public bool DiaphragmEntered = false;
    public int Time = 0;
    public MiniState MyMiniState;
    public Noise myNoiseSystem;
    public UnityEvent SpotCompletion;
    public GameObject Counter;
    public TextMeshProUGUI myTextField;
    public int requiredtime = 6;
    Stopwatch myTimer;
    


    private void Start()
      {
        //    MyMiniState.SpotDisableSetup();
        Counter.SetActive(false);
        myTimer = new Stopwatch();

      }
   

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Diaphragm")
        {
            DiaphragmEntered = true;
            Counter.SetActive(true);
            myTimer.Stop();
            myTimer.Reset();
            myTimer.Start();
            myTextField.text = (Convert.ToInt32(myTimer.Elapsed.TotalSeconds)).ToString();
        }
    }

    private void Update()
    {
        if (Convert.ToInt32(myTimer.Elapsed.TotalSeconds) < 6)
        {
            myTextField.text = (Convert.ToInt32(myTimer.Elapsed.TotalSeconds)).ToString();
        }
        if (Convert.ToInt32(myTimer.Elapsed.TotalSeconds) >= 6)
        {
            myTextField.text = (Convert.ToInt32(myTimer.Elapsed.TotalSeconds)).ToString();
            myTimer.Stop();
            myTimer.Reset();
            OnTimeMet();
        }
    }

    public void OnTimeMet()
    {
        SpotCompletion.Invoke();
        this.gameObject.SetActive(false);
        Counter.SetActive(false);
        MyMiniState.IndexCount();

    }
    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "Diaphragm")
        {
            DiaphragmEntered = false;
            Counter.SetActive(false);
            myTimer.Stop();
            myTimer.Reset();
        }
    }

}
