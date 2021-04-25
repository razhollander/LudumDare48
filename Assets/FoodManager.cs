using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FoodManager : MonoBehaviour
{
    public GameObject template1, template2, template3;

    public int food;

    public Vector2 length;

    private void Start()
    {
        //int num =  Random.Range(1, 4);

        //if (num == 1)
        //{
        //    template1.SetActive(true);
        //}

        //else if (num == 2)
        //{
        //    template2.SetActive(true);
        //}

        //else if (num == 3)
        //{
        //    template3.SetActive(true);
        //}
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.green;
        Debug.DrawRay(Vector2.zero, length, Color.green,5);
    }
}
