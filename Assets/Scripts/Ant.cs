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

    private Material _material;
    public static readonly int OUTLINE_WIDTH = Shader.PropertyToID("_Thickness");
    public static readonly int OUTLINE_ENABLED = Shader.PropertyToID("_OutlineEnabled");
    Vector2 _destPoint;
    bool _isMoving = false;
    Transform _transform;
    bool _hasOutlineMetrial;
    protected override void Awake()
    {
        base.Awake();
        _transform = transform;
        _material = GetComponent<SpriteRenderer>().material;
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
        _destPoint = point;
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
