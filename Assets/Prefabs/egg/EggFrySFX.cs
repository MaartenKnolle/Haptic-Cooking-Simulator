using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EggFrySFX : MonoBehaviour
{
    public AudioSource Geluidje1_AudioSource;
    public AudioSource Geluidje2_AudioSource;

    public bool isPlayingSequence = false;

    // public void = functie die aan te roepen valt door een ander script. Private void = niet bereikbaar!
    // Ik heb dit nu gekoppeld aan de knop op het scherm, die verwijst naar deze functie
    public void StartAudioSequence()
    {
        // eerste geluid audiosource moet uitgezet worden
        Geluidje1_AudioSource.gameObject.SetActive(true);
        Geluidje2_AudioSource.gameObject.SetActive(false);

        Geluidje1_AudioSource.Play();
        isPlayingSequence = true;
    }

    public void StopAudioSequence()
    {
        Geluidje1_AudioSource.Stop();
        Geluidje2_AudioSource.Stop();
        Geluidje1_AudioSource.gameObject.SetActive(false);
        Geluidje2_AudioSource.gameObject.SetActive(false);

        isPlayingSequence = false;
    }

    // Start is called before the first frame update
    void Start()
    {
        StartAudioSequence();
    }

    // Update is called once per frame
    void Update()
    {
        if (!Geluidje1_AudioSource.isPlaying && isPlayingSequence)
        {
            // zet eerste het tweede geluidje aan, en speel dat tweede geluidje
            // het tweede geluidje loopt, dus dat blijft doorspelen.
            // zet daarna het eerste geluidje uit, zodat het niet meer in deze loop blijft checken (zie if-statement)
            Geluidje2_AudioSource.gameObject.SetActive(true);
            Geluidje2_AudioSource.Play();

            Geluidje1_AudioSource.gameObject.SetActive(false);
            isPlayingSequence = false;
        }
    }
}
