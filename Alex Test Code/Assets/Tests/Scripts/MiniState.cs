using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MiniState : MonoBehaviour
{
    public StateClass MyState;
    public int ListenCount = 0;
    public List<ColliderScript> ListenPoints = new List<ColliderScript>();
    public void IndexCount()
    {
        ListenCount++;
        NextPoint(ListenCount);

    }

    public void NextPoint(int point)
    {
        if (point <= ListenPoints.Count)
        {
            ListenPoints[point].gameObject.SetActive(true);
        }
        if (point > ListenPoints.Count)
        {
            Debug.Log("End of Listening to Sounds");
            MyState.EndThisState();
        }
    }

}
