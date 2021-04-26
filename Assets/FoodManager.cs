using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FoodManager : MonoBehaviour
{
    public int food;

    //public GameObject Food1, Food2, Food3;
    public GameObject[] firstLayer,secondLayer,thirdLayer;
    [SerializeField] float disToLayer1, disToLayer2, disToLayer3;
    [SerializeField] int amount;
    public Transform Xmin, Xmax, Ymin,Ymax;
    public GameObject holder;
    private void Start()
    {
        for (int i = 0; i < amount; i++)
        {
            int num = Random.Range(1, 4);
            Vector2 randomPos = new Vector2(Random.Range(Xmin.position.x,Xmax.position.x), Random.Range(Ymin.position.y, Ymax.position.y));
           
            float dis = Vector2.Distance(randomPos, transform.position);
            //Debug.Log(dis);
            if (dis > disToLayer1 && dis < disToLayer2)
            {
                int rnd = Random.Range(0, firstLayer.Length);
                Instantiate(firstLayer[rnd], randomPos, Quaternion.identity, holder.transform);
            }

            else if (dis > disToLayer2 && dis < disToLayer3)
            {
                int rnd = Random.Range(0, secondLayer.Length);
                Instantiate(secondLayer[rnd], randomPos, Quaternion.identity, holder.transform);
            }

            else if (dis > disToLayer3)
            {
                int rnd = Random.Range(0, thirdLayer.Length);
                Instantiate(thirdLayer[rnd], randomPos, Quaternion.identity, holder.transform);
            }
        }

    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.green;
        //Debug.DrawLine(Ymin.position, Ymax.position,Color.green);
        //Debug.DrawLine(Xmin.position, Xmax.position,Color.green);
    }
}
