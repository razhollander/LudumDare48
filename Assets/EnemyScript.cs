using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyScript : PooledMonobehaviour
{
    GameObject queen;

    public int damage;
    public float speed;
    public float MinAttackDistance;
    public float dis;

    bool flipped = true;
    Transform _transform;

    private void Awake()
    {
        _transform = transform;
    }
    void Start()
    {
        queen = FindObjectOfType<QueenScript>().gameObject;
    }
     
    void Update()
    {
        float step = speed * Time.deltaTime;
        if (queen.transform.position.x > transform.position.x && flipped == true)
        {
            transform.Rotate(0,-180,0);
            flipped = false;
        }

        else if (queen.transform.position.x < transform.position.x && flipped == false)
        {
            transform.Rotate(0, 180, 0);
            flipped = true;
        }
        // Vector3 distance = Vector3.MoveTowards(transform.position,queen.transform.position,step);
    }

    private void FixedUpdate()
    {
        dis = Vector3.Distance(queen.transform.position, transform.position);
        if (dis > MinAttackDistance)
        {

            transform.position = Vector2.MoveTowards
                    (transform.position, queen.transform.position, speed * Time.deltaTime);


        }

        Vector3 diff = queen.transform.position.ToVector2() - _transform.position.ToVector2_Y();
        diff.Normalize();

        float yRotation = queen.transform.position.ToVector2().x > _transform.position.x ? 180 : 0;
        float rot_z = Mathf.Atan2(diff.y, diff.x) * Mathf.Rad2Deg;

        _transform.rotation = Quaternion.Euler(0f, 0f, rot_z - 180);
        _transform.Rotate(Vector3.right, yRotation);
    }
}
