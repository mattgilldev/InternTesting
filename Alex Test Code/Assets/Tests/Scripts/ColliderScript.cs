using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColliderScript : MonoBehaviour
{
    public bool DiaphragmEntered = false;
    public int Time = 0;
    public bool Waited = false;
    public MiniState MyMiniState;

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

    public void OnTimeMet()
    {
        Debug.Log("Timer Complete");
        MyMiniState.IndexCount();
        this.gameObject.SetActive(false);
    }

    IEnumerator CountToFive()
    {
        yield return new WaitForSeconds(1);
        Waited = true; 
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
