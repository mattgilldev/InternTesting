using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
/// <summary>
/// Script is only a class for a state for the "ProgressManager.cs" script....
/// 
/// To use... make an empty gameobject called "stateholder" to act as the parent... then make empty gameobjects as children... each with this script for each state
/// "ProgressManager.cs" will grab all of these states and then add them in the editor live and at run time so you can just rearrage the order of the children gameobjects to change the order of the states
/// </summary>
public class StateClass : MonoBehaviour
{
    public string statename = "";
    [Tooltip("List of gameobjects you want to turn on at the start of the state")]
    public List<GameObject> Gobjs_turnon = new List<GameObject>();
    [Tooltip("There is or isn't an aduio clip to play")]
    public bool _audioclip = false;
    [Tooltip("what is the starting point of audio instructions from the clip")]
    public float audioclip_starttime = 0f;
    [Tooltip("what is the end point of audio instructions from the clip")]
    public float audioclip_endtime = 0f;
    [Tooltip("There is no task for the user in this step, only playing the audio for instruction...so if this is true, then once the audio is done playing, go to the next state.,. false = there is a task the user needs to do")]
    public bool _Notasktodo = false;
    [Tooltip("time to wait before repeating audio if desired")]
    public float DelayTime;
    [Tooltip("anything to trigger on start of the state")]
    public UnityEvent Events_on_start;
    [Tooltip("anything to trigger on end (completing the state)")]
    public UnityEvent Events_on_end;


    [Header("for testing only")]
    public bool endstate = false;
    //runs in edit mode to live update the name of the gameobject
    private void OnValidate()
    {
        statename = gameObject.name;
    }


    public void EndThisState()
    {
        Events_on_end.Invoke();
    }


    private void Update()
    {
        if (endstate)
        {
            endstate = false;
            EndThisState();
        }
    }

}
