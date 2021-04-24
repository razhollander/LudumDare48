using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QueenScript : MonoBehaviour
{
    public int health;
    
    public void Die()
    {
        if (health <= 0)
        {
            //game over
        }
    }
}
