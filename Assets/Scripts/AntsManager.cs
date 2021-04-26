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

    public void AddFastAnt(Vector2 pos)
    {
        var ant = antPrefab.Get<Ant>(false);
        ant.transform.position = pos;
        ant.gameObject.SetActive(true);
        ant.GetComponent<Ant>()._speed = 2;
        ant.GetComponent<SpriteRenderer>().color = Color.red;
    }

    public void AddBigAnt(Vector2 pos)
    {
        var ant = antPrefab.Get<Ant>(false);
        ant.transform.position = pos;
        ant.gameObject.SetActive(true);
        ant.GetComponent<Ant>()._speed = 0.8f;
        ant.GetComponent<Ant>()._damage = 10;
        ant.GetComponent<SpriteRenderer>().color = Color.black;
        ant.GetComponent<Transform>().localScale  = ant.GetComponent<Transform>().localScale * 1.5f;
    }
}
