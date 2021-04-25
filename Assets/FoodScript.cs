using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FoodScript : MonoBehaviour
{
    public int amount;

    public float StartAmount = 30;
    public Image HealthBar;


    private void Start()
    {
        amount = (int)StartAmount;
    }

    public void TakeFood(int takeAmount)
    {
        amount = (int)Mathf.Clamp(amount, 0, StartAmount);
        amount -= takeAmount;
        HealthBar.fillAmount = amount / StartAmount;
        if (amount <= 0)
        {
            Destroy(gameObject);
        }
    }
}
