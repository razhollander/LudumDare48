using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyManager : MonoBehaviour
{
    float time;
    [SerializeField] EnemyScript enemy;



    void Start()
    {
        time = Random.Range(60, 90);
    }

    private void Update()
    {
        
    }
    
}
