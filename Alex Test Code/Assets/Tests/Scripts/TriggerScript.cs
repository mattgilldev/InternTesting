using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerScript : MonoBehaviour
{
    public StateClass ColliderState;
    private bool enter = false;
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player" & enter == false)
        {
            enter = true;
            this.gameObject.SetActive(false);
            ColliderState.EndThisState();
        }
    }
}
