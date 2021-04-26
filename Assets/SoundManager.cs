using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    public AudioSource antDie;
    public AudioSource queenHit;
    public AudioSource queenDie;
    public AudioSource LoopA;
    public AudioSource LoopB;

    bool _flag = true;
    public void PlayantDie()
    {
        antDie.Play();
    }

    public void PlayqueenHit()
    {
        queenHit.Play();
    }

    public void PlayqueenDie()
    {
        queenDie.Play();
    }

    private void Update()
    {
        PlaySoundTrack();
    }
    public void PlaySoundTrack()
    {
        if (!LoopA.isPlaying && _flag)
        {
            LoopB.Play();
            _flag = false;
        }
    }
}
