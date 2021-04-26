﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QueenScript : MonoBehaviour
{
    [SerializeField]
    private int FoodAmountPerAnt = 10;
    [SerializeField]
    private float createAntsRadius = 1;
    [SerializeField]private int foodAmount = 0;
    private float health;
    public float startHealth; 
    private Transform _transform;
    public UIScript UI;

    private void Awake()
    {
        _transform = transform;
    }

    public void TakeDamage(int damage)
    {
        health -= damage;
        UI.UpdatehealthTxt(damage);
    }
    public void Die()
    {
        if (health <= 0)
        {
            //game over cahnge sprite
        }
    }

    public void Feed(int amount,FoodType kind)
    {
        foodAmount += amount;
        UI.UpdateFoodTxt(amount);
        var antsNumber = foodAmount / FoodAmountPerAnt;

        for (int i = 0; i < antsNumber; i++)
        {
            switch( kind)
            {
                case FoodType.Fast:
                    CreateFastAnt();
                    break;
                case FoodType.Normal:
                    CreateAnt();
                    break;
                case FoodType.Strong:
                    CreateBigAnt();
                    break;
            }
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

    private void CreateFastAnt()
    {
        foodAmount -= FoodAmountPerAnt;
        UI.UpdateFoodTxt(-FoodAmountPerAnt);
        Vector2 creationPoint = _transform.position.ToVector2_Y() + Random.insideUnitCircle * createAntsRadius;
        GameManager.instance.antManager.AddFastAnt(creationPoint);
        UI.UpdateAntsTxt(1);
    }

    private void CreateBigAnt()
    {
        foodAmount -= FoodAmountPerAnt;
        UI.UpdateFoodTxt(-FoodAmountPerAnt);
        Vector2 creationPoint = _transform.position.ToVector2_Y() + Random.insideUnitCircle * createAntsRadius;
        GameManager.instance.antManager.AddBigAnt(creationPoint);
        UI.UpdateAntsTxt(1);
    }

}
