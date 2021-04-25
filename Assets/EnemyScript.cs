using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyScript : PooledMonobehaviour
{
    GameObject queen;

    void Start()
    {
        queen = FindObjectOfType<QueenScript>().gameObject;
    }

    void Update()
    {
        
    }
}
