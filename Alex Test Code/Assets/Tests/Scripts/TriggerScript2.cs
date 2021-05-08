using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerScript2 : MonoBehaviour
{
    public StateClass ColliderState;
    private bool enters = false;
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player" & enters == false)
        {
            enters = true;
            this.gameObject.SetActive(false);
            ColliderState.EndThisState();
        }
       
    }
}
