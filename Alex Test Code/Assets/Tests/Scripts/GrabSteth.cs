using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GrabSteth : MonoBehaviour
{
    public StateClass myclasstoend;
    private bool once = false;
   
    public void FirstStethGrab()
    {
        if (once == false)
        {
            once = true;
            myclasstoend.EndThisState();
        }
    }
}
