using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/// <summary>
/// script that manages the overall experience
/// </summary>
public class ProgressManager : MonoBehaviour
{
    public GameObject stateholder;
    public StateClass[] states = null;
    public StateClass currentState;
    public StateClass lastState;
    public int stateindex = 0;

    public bool startexperience = false;
    [HideInInspector]
    public bool experiencestarted = false;

    public int numberofstates = 0;
    [Header("Audio Systems")]
    public AudioSource Narration;
    public AudioSource Soundeffects;
    public bool audioplayed = false;

    private void Start()
    {
       stateindex = 0;
    }

    public void Update()
    {
        //only temporary for now
        if (startexperience)
        {
            startexperience = false;
            experiencestarted = true;
            StartExperience();
        }

        if (Application.isPlaying && experiencestarted && currentState._audioclip)
        {
            CheckAudioTimeEnd();
        }
    }



    public void StartExperience()
    {
        currentState = states[stateindex];
        TriggerStartingEvents();

        EnableNextstateObjects();
    }

    public void NextState()
    {
        Debug.Log("starting next state!");
        DeactivateLastState();
        UpdateStateinfo();
        TriggerStartingEvents();
        EnableNextstateObjects();
    }

    public void UpdateStateinfo()
    {
        stateindex++;
        if (stateindex <= states.Length -1)
        {
            lastState = currentState;
            currentState = states[stateindex];
            return;
        }

        if(stateindex > states.Length -1)
        {
            Debug.Log("end of experience! Out of states");
        }
    }

    public void DeactivateLastState()
    {
        currentState.currentstateactive = false;
        Debug.Log("Deactiving old things");
        foreach (GameObject thing in currentState.Gobjs_turnon)
        {
            thing.SetActive(false);
        }

    }

    public void EnableNextstateObjects()
    {
        Debug.Log("Enabling new things");
        foreach(GameObject thing in currentState.Gobjs_turnon)
        {
            thing.SetActive(true);
        }

        if (currentState._audioclip)
        {
            PlayNarration();
        }
    }

    public void TriggerStartingEvents()
    {
        currentState.currentstateactive = true;
        currentState.Events_on_start.Invoke();
    }


    //in edit mode... live update stateorder
    private void OnValidate()
    {
        if (states != null)
        {
            states = stateholder.GetComponentsInChildren<StateClass>();
        }

        if(states == null)
        {
            states = null;
        }
    }

    public void PlayNarration()
    {
        if (currentState._audioclip)
        {
            Debug.Log(currentState.gameObject.name + " is starting the audio");
            Narration.time = currentState.audioclip_starttime;
            Narration.Play();
        }
    }

    public void CheckAudioTimeEnd()
    {
        if (currentState._audioclip)
        {
            if (Narration.time >= currentState.audioclip_endtime)
            {
                Narration.Stop();
                currentState.audioisplaying = false;
                EndNarration();
            }
        }

        else
        {
            return;
        }
    }

    public void EndNarration()
    {
        if (currentState._Notasktodo == false)
        {
            Debug.Log("Audio done... but waiting for event to trigger end of state");
            return;
        }

        if (currentState._Notasktodo)
        {
            StartCoroutine(TimeDelay(1));
        }
        // if true.... go to next state post a 1-2 second delay
    }

    public IEnumerator TimeDelay(int delaytime)
    {
        yield return new WaitForSeconds(delaytime);
        currentState.EndThisState();
    }

    //need to loop the audio here if the task is not completed
}
