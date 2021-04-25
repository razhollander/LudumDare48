using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AntsManager : MonoBehaviour
{
    [SerializeField]
    Ant antPrefab;

    public void AddAnt(Vector2 pos)
    {
        var ant = antPrefab.Get<Ant>(false);
        ant.transform.position = pos;
        ant.gameObject.SetActive(true);
    }
}
