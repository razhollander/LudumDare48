using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
public class Ant : OverridableMonoBehaviour, ISelectable
{
    [SerializeField]
    private float _speed;
    [SerializeField]
    private float _destCircleRadios=1;
    [SerializeField]
    private int _foodCollectAmount = 1;
    [SerializeField]
    private SpriteRenderer _foodCrumbSpriteRenderer;
    private Material _material;
    public static readonly int OUTLINE_ENABLED = Shader.PropertyToID("_OutlineEnabled");
    Vector2 _destPoint;
    public bool _isMoving = false;
    Transform _transform;
    bool _hasOutlineMetrial;
    SpriteRenderer _sprite;
    bool _isCarryingFood = false;
    protected override void Awake()
    {
        base.Awake();
        _transform = transform;
        _sprite = GetComponent<SpriteRenderer>();
        _material = _sprite.material;
        _hasOutlineMetrial = _material.HasProperty(OUTLINE_ENABLED);       
    }

    private void OnEnable()
    {
        _foodCrumbSpriteRenderer.sprite = null;
        _isCarryingFood = false;
        _isMoving = false;
    }
    public void Deselect()
    {
        if (_hasOutlineMetrial)
        {
            _material.SetInt(OUTLINE_ENABLED, 0);
        }
    }

    public void Select()
    {
        if (_hasOutlineMetrial)
        {
            _material.SetInt(OUTLINE_ENABLED, 1);
        }
    }

    public void DoSelectedTask(Vector2 point)
    {
        SetDestination(point);
    }

    private void SetDestination(Vector2 point)
    {
        _destPoint = point + Random.insideUnitCircle * _destCircleRadios;
        Vector3 diff = point - _transform.position.ToVector2_Y();
        diff.Normalize();
        float yRotation = _destPoint.x > _transform.position.x ? 180 : 0;
        float rot_z = Mathf.Atan2(diff.y, diff.x) * Mathf.Rad2Deg;

        _transform.rotation = Quaternion.Euler(0f, 0f, rot_z - 180);
        _transform.Rotate(Vector3.right, yRotation);
        _isMoving = true;
    }

    public override void UpdateMe() 
    {
        if (_isMoving) 
        {
            _transform.position = Vector2.MoveTowards(_transform.position, _destPoint, _speed * Time.deltaTime);
            GetComponent<TunnelCreationScript>().dig = true;
            if (_transform.position.x == _destPoint.x && _transform.position.y == _destPoint.y)
            {
                _isMoving = false;
                GetComponent<TunnelCreationScript>().dig = false;
            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("COLLIDE!");
        var food = other.GetComponent<FoodScript>();

        if (food != null && !_isCarryingFood)
        {
            food.TakeFood(_foodCollectAmount);
            _foodCrumbSpriteRenderer.sprite = food.FoodCrumbSprite;
            _isCarryingFood = true;
            SetDestination(GameManager.instance.queen.transform.position);
        }
    }

}
