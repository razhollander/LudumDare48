using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FoodManager : MonoBehaviour
{
    public int food;

    public GameObject Food1, Food2, Food3;
    [SerializeField] int amount;
    public Transform Xmin, Xmax, Ymin,Ymax;
    public GameObject holder;
    private void Start()
    {
        for (int i = 0; i < amount; i++)
        {
            int num = Random.Range(1, 4);
            Vector2 randomPos = new Vector2(Random.Range(Xmin.position.x,Xmax.position.x), Random.Range(Ymin.position.y, Ymax.position.y));
            if (num == 1)
            {
              Instantiate(Food1,randomPos,Quaternion.identity,holder.transform);
            }

            else if (num == 2)
            {
              Instantiate(Food2, randomPos, Quaternion.identity, holder.transform);
            }

            else if (num == 3)
            {
              Instantiate(Food3, randomPos, Quaternion.identity, holder.transform);
            }
        }

    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.green;
        Debug.DrawLine(Ymin.position, Ymax.position,Color.green);
        Debug.DrawLine(Xmin.position, Xmax.position,Color.green);
    }
}
