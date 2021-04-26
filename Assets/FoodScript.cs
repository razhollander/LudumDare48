using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FoodScript : MonoBehaviour
{
    [SerializeField]
    Canvas _healthCanvas;

    public Sprite FoodCrumbSprite;
    private int amount;
    
    public float StartAmount = 30;
    public Image HealthBar;


    private void Start()
    {
        amount = (int)StartAmount;
    }

    private void OnEnable()
    {
        _healthCanvas.gameObject.SetActive(false);
    }

    public void TakeFood(int takeAmount)
    {
        _healthCanvas.gameObject.SetActive(true);

        amount = (int)Mathf.Clamp(amount, 0, StartAmount);
        amount -= takeAmount;
        HealthBar.fillAmount = amount / StartAmount;
        if (amount <= 0)
        {
            Destroy(gameObject);
        }
    }
}
