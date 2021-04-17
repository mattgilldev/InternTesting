using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Noise : MonoBehaviour
{
    [Header("Audio Source")]
    public AudioSource _SoundEffectSource;

    [Header("Audio Clips: Effects")]
    public AudioClip _completionnoise;

    public void CompletionNoise()
    {
        _SoundEffectSource.clip = _completionnoise;
        _SoundEffectSource.Play();
    }
        
}
