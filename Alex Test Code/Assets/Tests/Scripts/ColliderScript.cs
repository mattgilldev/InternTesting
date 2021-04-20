using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class ColliderScript : MonoBehaviour
{
    public bool DiaphragmEntered = false;
    public int Time = 0;
    public bool Waited = false;
    public MiniState MyMiniState;
    public Noise myNoiseSystem;
    public UnityEvent SpotCompletion;

    //private void Start()
    //   {
    //    MyMiniState.SpotDisableSetup();
    //   }
   

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Diaphragm")
        {
            DiaphragmEntered = true;
            StartCoroutine(CountToFive());
            Time = 0; 
        }
    }

    private void Update()
    {
        if (Waited == true && Time < 5)
        {
            Time += 1;
            Waited = false;
            StartCoroutine(CountToFive());
        }

        if (Time == 5)
        {
            OnTimeMet();
        }
    }

    IEnumerator CountToFive()
    {
        yield return new WaitForSeconds(1);
        Waited = true; 
    }

    public void OnTimeMet()
    {
        Debug.Log("Timer Complete");
        SpotCompletion.Invoke();
        this.gameObject.SetActive(false);
        MyMiniState.IndexCount();

    }
    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "Diaphragm")
        {
            DiaphragmEntered = false;
            StopAllCoroutines();
            Time = 0;
            Waited = false;
        }
    }

}
