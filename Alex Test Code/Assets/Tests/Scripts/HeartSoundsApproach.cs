using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeartSoundsApproach : MonoBehaviour
{
    public StateClass ColliderState2;
    private bool enteredagain = true;
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player" & enteredagain == true)
        {
            enteredagain = false;
            this.gameObject.SetActive(false);
            ColliderState2.EndThisState();
        }
    }
}
