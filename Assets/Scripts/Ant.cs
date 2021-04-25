using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
public class Ant : OverridableMonoBehaviour, ISelectable
{
    [SerializeField]
    private float _outlineWidth = 2;
    [SerializeField]
    private float _speed;
    [SerializeField]
    private float _destCircleRadios=1;
    private Material _material;
    public static readonly int OUTLINE_WIDTH = Shader.PropertyToID("_Thickness");
    public static readonly int OUTLINE_ENABLED = Shader.PropertyToID("_OutlineEnabled");
    Vector2 _destPoint;
    public bool _isMoving = false;
    Transform _transform;
    bool _hasOutlineMetrial;
    SpriteRenderer _sprite;
    protected override void Awake()
    {
        base.Awake();
        _transform = transform;
        _sprite = GetComponent<SpriteRenderer>();
        _material = _sprite.material;
        _hasOutlineMetrial = _material.HasProperty(OUTLINE_ENABLED);
       // Debug.Log(_hasOutlineMetrial);
       
    }
    //public bool isSelected => throw new System.NotImplementedException();

    public void Deselect()
    {
        if (_hasOutlineMetrial)
        {
            _material.SetInt(OUTLINE_ENABLED, 0);
            //_material.SetFloat(OUTLINE_WIDTH, 0);
        }
    }

    public void Select()
    {
        if (_hasOutlineMetrial)
        {
            Debug.Log("Ant Selected");
            _material.SetInt(OUTLINE_ENABLED, 1);
           // _material.SetFloat(OUTLINE_WIDTH, _outlineWidth);
        }
    }

    public void DoSelectedTask(Vector2 point)
    {
        Debug.Log("Do task "+point);

        _destPoint = point + Random.insideUnitCircle * _destCircleRadios;
        //_transform.l(_destPoint, Vector2.up);
        Vector3 diff = point - _transform.position.ToVector2_Y();
        diff.Normalize();

        float yRotation = _destPoint.x > _transform.position.x ? 180 : 0;
        float rot_z = Mathf.Atan2(diff.y, diff.x) * Mathf.Rad2Deg;
    
        _transform.rotation = Quaternion.Euler(0f, 0f, rot_z - 180);
        _transform.Rotate(Vector3.right, yRotation);// = new Vector3(_transform.localEulerAngles.x, yRotation, _transform.localEulerAngles.z);
        //_sprite.flipX = _destPoint.x > _transform.position.x;
        //_sprite.flipY = _destPoint.x < _transform.position.x;

        // Debug.DrawLine(transform.position, _destPoint, Color.blue, 5);
        _isMoving = true;
    }

    public override void UpdateMe() 
    {
        if (_isMoving) 
        {
            _transform.position = Vector2.MoveTowards(_transform.position, _destPoint, _speed * Time.deltaTime);
            if (_transform.position.x == _destPoint.x && _transform.position.y == _destPoint.y)
            {
                _isMoving = false; 
            }
        }
    }

}
