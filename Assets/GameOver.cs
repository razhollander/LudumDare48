using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameOver : MonoBehaviour
{
    public TextMeshProUGUI _highScore;
    public TextMeshProUGUI _currentScore;

    private void OnEnable()
    {
        var score = (int.Parse(_currentScore.text));
        if (score >= PlayerPrefs.GetInt("Score"))
        {
            PlayerPrefs.SetInt("Score", score);
        }
        _highScore.text = PlayerPrefs.GetInt("Score").ToString();
        _currentScore.text = FindObjectOfType<UIScript>().foodTxt.text;
    }
}
