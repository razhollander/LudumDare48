using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class UIScript : MonoBehaviour
{

    public TextMeshProUGUI antsTxt;
    public TextMeshProUGUI foodTxt;
    public Image healthBar;
    int food;
    float startHealth;
    float health;
    int ants = 0;
    QueenScript queen;
    private void Start()
    {
        queen = FindObjectOfType<QueenScript>();
        startHealth = queen.startHealth;
        health = startHealth;
    }

    public void UpdateAntsTxt(int number)
    {
        ants += number;
        antsTxt.text = ants.ToString();
    }

    public void UpdateFoodTxt(int number)
    {       
        food += number;
        foodTxt.text = food.ToString();
    }

    public void UpdatehealthTxt(float number)
    {
        health -= number;
        healthBar.fillAmount = health / startHealth;
    }
}
