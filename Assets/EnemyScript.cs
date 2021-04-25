using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemyScript : OverridableMonoBehaviour
{
    [SerializeField]
    Canvas _healthCanvas;
    public int damage;
    public float startHealth;
    float health;
    public float speed;
    public float MinAttackDistance;
    public float dis;
    Vector2 _destPoint;
    bool flipped = true;
    Transform _transform;
    public Image HealthBar;
    bool isMoving = true;
    
    protected override void Awake()
    {
        base.Awake();
        _transform = transform;
         
    }
  
    private void OnEnable()
    {
        isMoving = true;
        health = startHealth;
        HealthBar.fillAmount = health / startHealth;
        _healthCanvas.gameObject.SetActive(false);
    }

    public void TakeDamage(float damage)
    {
        health -= damage;
        health = (int)Mathf.Clamp(health, 0, startHealth);
        HealthBar.fillAmount = health / startHealth;

        if (health <= 0)
        {
            gameObject.SetActive(false);
        }

        _healthCanvas.gameObject.SetActive(true);
    }

    public void SetDestination(Vector2 queenPos)
    {
        _destPoint = queenPos;
        _destPoint = _destPoint + (_transform.position.ToVector2_Y() - _destPoint).normalized*MinAttackDistance;

        Vector3 diff = _destPoint - _transform.position.ToVector2_Y();
        diff.Normalize();
        float yRotation = _destPoint.x > _transform.position.x ? 180 : 0;
        float rot_z = Mathf.Atan2(diff.y, diff.x) * Mathf.Rad2Deg;

        _transform.rotation = Quaternion.Euler(0f, 0f, rot_z - 180);
        _transform.Rotate(Vector3.right, yRotation);


        //Vector3 diff = _destPoint - _transform.position.ToVector2_Y();
        //diff.Normalize();
        //float yRotation = _destPoint.x > _transform.position.x ? 180 : 0;
        //float rot_z = Mathf.Atan2(diff.y, diff.x) * Mathf.Rad2Deg;

        //if (queenPos.x > _transform.position.x && flipped == true)
        //{
        //    transform.Rotate(0, -180, 0);
        //    flipped = false;
        //}

        //else if (queenPos.x < _transform.position.x && flipped == false)
        //{
        //    transform.Rotate(0, 180, 0);
        //    flipped = true;
        //}

        //_transform.rotation = Quaternion.Euler(0f, 0f, rot_z - 180);
        //_transform.Rotate(Vector3.right, yRotation);
        GetComponent<TunnelCreationScript>().dig = true;
        //_animator.Play(WALKING_ANIMATION);
    }

    public override void UpdateMe()
    {
        if(!isMoving)
        {
            return;
        }

        if (_transform.position.x == _destPoint.x && _transform.position.y == _destPoint.y)
        {
            GetComponent<TunnelCreationScript>().dig = false;
            isMoving = false;
        }
        else
        {
            _transform.position = Vector2.MoveTowards(_transform.position, _destPoint, speed * Time.deltaTime);
        }
    }

    //private void FixedUpdate()
    //{
    //    dis = Vector3.Distance(queen.transform.position, transform.position);
    //    if (dis > MinAttackDistance)
    //    {

    //        transform.position = Vector2.MoveTowards
    //                (transform.position, queen.transform.position, speed * Time.deltaTime);


    //    }

    //    Vector3 diff = queen.transform.position.ToVector2() - _transform.position.ToVector2_Y();
    //    diff.Normalize();

    //    float yRotation = queen.transform.position.ToVector2().x > _transform.position.x ? 180 : 0;
    //    float rot_z = Mathf.Atan2(diff.y, diff.x) * Mathf.Rad2Deg;

    //    _transform.rotation = Quaternion.Euler(0f, 0f, rot_z - 180);
    //    _transform.Rotate(Vector3.right, yRotation);
    //}
}
