using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class EnemyManager : MonoBehaviour
{
    public float time;
    
   // [SerializeField] EnemyScript enemy1, enemy2, enemy3;
    public EnemyScript[] firstWave, secondWave, thirdWave;
    [SerializeField] float timeToWave1, timeToWave2, timeToWave3;


    [SerializeField]Vector2 centerL, sizeR;
    [SerializeField]Vector2 centerR, sizeL;

    [SerializeField] int minTime, maxTime;

    [SerializeField]
    AnimationCurve animationCurve;
    [SerializeField]float curveTime;
    [SerializeField] float minutesToEndGraph = 180;
    void Start()
    {
        time = Random.Range(minTime, maxTime);
    }

    private void Update()
    {
        time -= Time.deltaTime;
        Spawn();
    }

    public void Spawn()
    {
        curveTime += Time.deltaTime /minutesToEndGraph;
        if (time <= 0)
        {
            float rndNum = Random.Range(0f, 1f);
            if (rndNum <= curveTime)
            {
                EnemyScript enemy;

                if (curveTime < timeToWave1)
                {
                    Debug.Log("wave 1");
                    int rnd = Random.Range(0, firstWave.Length);
                    enemy = firstWave[rnd].Get<EnemyScript>();
                }

                else if (curveTime < timeToWave2 && curveTime > timeToWave1)
                {
                    Debug.Log("wave 2");
                    int rnd = Random.Range(0, secondWave.Length);
                    enemy = secondWave[rnd].Get<EnemyScript>();
                }

                else
                {
                    Debug.Log("wave 3");
                    int rnd = Random.Range(0, thirdWave.Length);
                    enemy = thirdWave[rnd].Get<EnemyScript>();
                }

                //int enemyNum = Random.Range(1, 4);

                //EnemyScript enemy;

                //switch (enemyNum)
                //{
                //    case 1:
                //        enemy = enemy1.Get<EnemyScript>();
                //        break;
                //    case 2:
                //        enemy = enemy2.Get<EnemyScript>();
                //        break;
                //    default:
                //        enemy = enemy3.Get<EnemyScript>();
                //        break;
                //}
                   Vector2 posL = centerL + new Vector2(Random.Range(-sizeR.x/2, sizeR.x/2), Random.Range(-sizeR.y / 2, sizeR.y / 2));
                   Vector2 posR = centerR + new Vector2(Random.Range(-sizeL.x / 2, sizeL.x / 2), Random.Range(-sizeL.y / 2, sizeL.y / 2));

                int num = Random.Range(0,2);


                if (num == 1)
                {
                    enemy.GetComponent<Transform>().position = posL;
                }

                else if (num == 0)
                { 
                    enemy.GetComponent<Transform>().position = posR;
                }
                enemy.SetDestination(GameManager.instance.queen.transform.position.ToVector2_Y());

            }
            time = Random.Range(minTime, maxTime);

        }
    }


    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawCube(centerR, sizeR);
        Gizmos.DrawCube(centerL, sizeL);
    }
}
