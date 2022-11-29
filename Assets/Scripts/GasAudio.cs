using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class GasAudio : MonoBehaviour
{
    public AudioMixerSnapshot Snapshot;
    AudioSource audioSource;
    
    // Start is called before the first frame update
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        if (!audioSource.isPlaying){
            Snapshot.TransitionTo(0.0f);
        }
    }
}
