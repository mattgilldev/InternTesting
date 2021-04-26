using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using TMPro;

public class ColliderScript : MonoBehaviour
{
    public bool DiaphragmEntered = false;
    public int Time = 0;
    public bool Waited = false;
    public MiniState MyMiniState;
    public Noise myNoiseSystem;
    public UnityEvent SpotCompletion;
    public GameObject Counter;
   public TextMeshProUGUI myTextField;
    


    private void Start()
      {
        //    MyMiniState.SpotDisableSetup();
        Counter.SetActive(false);
      }
   

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Diaphragm")
        {
            DiaphragmEntered = true;
            Counter.SetActive(true);
            Time = 0;
            myTextField.text = Time.ToString();
            StartCoroutine(CountToFive());
            
        }
    }

    private void Update()
    {
        if (Waited == true && Time < 5)
        {
            Time += 1;
            myTextField.text = Time.ToString();
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
        Counter.SetActive(false);
        MyMiniState.IndexCount();

    }
    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "Diaphragm")
        {
            DiaphragmEntered = false;
            StopAllCoroutines();
            Counter.SetActive(false);
            Time = 0;
            Waited = false;
        }
    }

}
