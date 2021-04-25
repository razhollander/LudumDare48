using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QueenScript : MonoBehaviour
{
    [SerializeField]
    private int FoodAmountPerAnt = 10;
    [SerializeField]
    private float createAntsRadius = 1;
    [SerializeField]private int foodAmount = 0;
    public int health;
    private Transform _transform;
    public UIScript UI;

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
        UI.UpdateFoodTxt(amount);
        var antsNumber = foodAmount / FoodAmountPerAnt;
        for (int i = 0; i < antsNumber; i++)
        {
            CreateAnt();
        }
    }

    [ContextMenu("Create 500 ants")]
    private void Create500Ants()
    {
        for (int i = 0; i < 500; i++)
        {
            CreateAnt();
        }
    }

    private void CreateAnt()
    {
        foodAmount -= FoodAmountPerAnt;
        UI.UpdateFoodTxt(-FoodAmountPerAnt);
        Vector2 creationPoint = _transform.position.ToVector2_Y() + Random.insideUnitCircle * createAntsRadius;
        GameManager.instance.antManager.AddAnt(creationPoint);
        UI.UpdateAntsTxt(1);
    }

}
