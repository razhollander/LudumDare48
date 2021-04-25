using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AntsManager : MonoBehaviour
{
    [SerializeField]
    Ant antPrefab;

    [ContextMenu("Add ant")]
    public void AddAnt()
    {
        var ant = antPrefab.Get<Ant>(false);
        ant.transform.position = GameManager.instance.queen.transform.position;
        ant.gameObject.SetActive(true);
    }
}
