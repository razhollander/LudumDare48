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
    private float health;
    public float startHealth; 
    private Transform _transform;
    private UIScript UI;
    SoundManager soundManager;
    Animator animator;
    public GameObject gameOver;
    private void Awake()
    {
        _transform = transform;
        soundManager = FindObjectOfType<SoundManager>();
        animator = GetComponent<Animator>();
        health = startHealth;
    }

    public void TakeDamage(int damage)
    {
        health -= damage;
        UI.UpdatehealthTxt(damage);
        Die();

    }
    private void Start()
    {
        UI = GameManager.instance.UIScript;
    }

    public void Die()
    {
        if (health <= 0)
        {
            soundManager.PlayqueenDie();
            animator.SetBool("Dead",true);
            gameOver.SetActive(true);
            Time.timeScale = 0;         
            return;
        }
        else soundManager.PlayqueenHit();
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
        Vector2 creationPoint = _transform.position.ToVector2_Y() + Random.insideUnitCircle * createAntsRadius;
        GameManager.instance.antManager.AddAnt(creationPoint);       
    }

    private void CreateFastAnt()
    {
        foodAmount -= FoodAmountPerAnt;
        Vector2 creationPoint = _transform.position.ToVector2_Y() + Random.insideUnitCircle * createAntsRadius;
        GameManager.instance.antManager.AddFastAnt(creationPoint);
    }

    private void CreateBigAnt()
    {
        foodAmount -= FoodAmountPerAnt;
        Vector2 creationPoint = _transform.position.ToVector2_Y() + Random.insideUnitCircle * createAntsRadius;
        GameManager.instance.antManager.AddBigAnt(creationPoint);
    }

}
