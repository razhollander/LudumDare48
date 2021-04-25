using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QueenScript : MonoBehaviour
{
    [SerializeField]
    private int FoodAmountPerAnt = 10;
    [SerializeField]
    private float createAntsRadius = 1;
    private int foodAmount = 0;
    public int health;
    private Transform _transform;

    private void Awake()
    {
        _transform = transform;
    }
    public void Die()
    {
        if (health <= 0)
        {
            //game over
        }
    }

    public void Feed(int amount)
    {
        foodAmount += amount;
        Debug.Log("amount: " + foodAmount + ", foodperant" + FoodAmountPerAnt);
        var antsNumber = foodAmount / FoodAmountPerAnt;
        for (int i = 0; i < antsNumber; i++)
        {
            Debug.Log("Create ANT");
            CreateAnt();
        }
    }

    private void CreateAnt()
    {
        foodAmount -= FoodAmountPerAnt;
        Vector2 creationPoint = _transform.position.ToVector2_Y() + Random.insideUnitCircle * createAntsRadius;
        GameManager.instance.antManager.AddAnt(creationPoint);
    }

}
