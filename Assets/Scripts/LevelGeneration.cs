using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelGeneration : MonoBehaviour
{
    public GameObject[] Objects;

    private void Start()
    {
        int rnd = Random.Range(0,Objects.Length);
        Instantiate(Objects[rnd], transform.position, Quaternion.identity);
    }
}
