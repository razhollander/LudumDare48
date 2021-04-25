using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class UIScript : MonoBehaviour
{

    public TextMeshProUGUI antsTxt;
    public TextMeshProUGUI foodTxt;
    int food;
    int ants = 2;
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
}
