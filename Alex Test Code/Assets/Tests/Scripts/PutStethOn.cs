using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PutStethOn : MonoBehaviour
{
    public StateClass EndingStethClass;
    private bool on = false;

    public void PuttingStethOn()
    {
        if (on == false)
        {
            on = true;
            EndingStethClass.EndThisState();
        }
    }
}
