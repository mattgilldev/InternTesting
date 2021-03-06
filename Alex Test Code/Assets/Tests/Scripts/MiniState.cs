using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MiniState : MonoBehaviour
{
    public StateClass MyState;
    public int ListenCount = 0;
    public List<ColliderScript> ListenPoints = new List<ColliderScript>();
    public List<SlideControl> Slides = new List<SlideControl>();

    public void Start()
    {
        SpotDisableSetup();
    }

    public void SpotDisableSetup()
    {
       for (int i=0; i < ListenPoints.Count; i++)
        {
            ListenPoints[i].gameObject.SetActive(false);

        }

        for (int i=0; i<Slides.Count; i++)
        {
            Slides[i].gameObject.SetActive(false);
        }

    }

    public void SpotFirstOn()
    {
        ListenPoints[0].gameObject.SetActive(true);
        Slides[0].gameObject.SetActive(true);
    }

    
    public void IndexCount()
    {
        Slides[ListenCount].gameObject.SetActive(false);
        ListenCount++;
        NextPoint(ListenCount);
        if (ListenCount < ListenPoints.Count)
        {
            ListenPoints[ListenCount].gameObject.SetActive(true);
            Slides[ListenCount].gameObject.SetActive(true);
        }

    }

   public void NextPoint(int point)
    {
        
       if (point < ListenPoints.Count)
       {
           ListenPoints[point].gameObject.SetActive(true);
       }
      if (point >= ListenPoints.Count)
       {
           Debug.Log("End of Listening to Sounds");
           MyState.EndThisState();
       }
    }

}
