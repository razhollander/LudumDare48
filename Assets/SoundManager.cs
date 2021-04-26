using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    public AudioSource antDie;
    public AudioSource queenHit;
    public AudioSource queenDie;

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
}
