using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
public class Ant : OverridableMonoBehaviour, ISelectable
{
    int WALKING_ANIMATION = Animator.StringToHash("AntWalking");
    int IDLE_ANIMATION = Animator.StringToHash("AntIdle");

    [SerializeField]
    public float _speed;
    [SerializeField]
    private float _destCircleRadios=1;
    [SerializeField]
    private int _foodCollectAmount = 1;
    [SerializeField]
    private SpriteRenderer _foodCrumbSpriteRenderer;
    private Material _material;
    public static readonly int OUTLINE_ENABLED = Shader.PropertyToID("_OutlineEnabled");
    [SerializeField]
    private ParticleSystem _bloodParticle;
    Vector2 _destPoint;
    public bool _isMoving = false;
    Transform _transform;
    bool _hasOutlineMetrial;
    SpriteRenderer _sprite;
    bool _isCarryingFood = false;
    Animator _animator;
    FoodScript _lastFood;
    FoodType carryingFood;
    public int _damage = 5;
    private UIScript UIScript;
    protected override void Awake()
    {
        base.Awake();
        _animator = GetComponent<Animator>();
        _transform = transform;
        _sprite = GetComponent<SpriteRenderer>();
        _material = _sprite.material;
        _hasOutlineMetrial = _material.HasProperty(OUTLINE_ENABLED);
    }

    private void Start()
    {
        UIScript = GameManager.instance.UIScript;
    }

    private void OnEnable()
    {
        _foodCrumbSpriteRenderer.sprite = null;
        _isCarryingFood = false;
        _isMoving = false;
        _animator.Play(IDLE_ANIMATION);
        if (UIScript == null)
            UIScript = GameManager.instance.UIScript;

        UIScript.UpdateAntsTxt(1);
    }

    protected override void OnDisable()
    {
        base.OnDisable();
        UIScript.UpdateAntsTxt(-1);
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
        _animator.Play(WALKING_ANIMATION);

    }

    public override void UpdateMe() 
    {
        if (_isMoving) 
        {
            _transform.position = Vector2.MoveTowards(_transform.position, _destPoint, _speed * Time.deltaTime);
            GetComponent<TunnelCreationScript>().dig = true;
            if (_transform.position.x == _destPoint.x && _transform.position.y == _destPoint.y)
            {
                StopMoving();
            }
        }
    }

    private void StopMoving()
    {
        _isMoving = false;
        _animator.Play(IDLE_ANIMATION);
        GetComponent<TunnelCreationScript>().dig = false;
    }

    private void OnTriggerEnter(Collider other)
    {
        var food = other.GetComponent<FoodScript>();

        if (food != null && !_isCarryingFood)
        {
            food.TakeFood(_foodCollectAmount);
            _foodCrumbSpriteRenderer.sprite = food.FoodCrumbSprite;
            _isCarryingFood = true;
            SetDestination(GameManager.instance.queen.transform.position);
            _lastFood = food;
            carryingFood = _lastFood.FoodType;
        }

        var queen = other.GetComponent<QueenScript>();

        if (queen != null && _isCarryingFood)
        {
            queen.Feed(_foodCollectAmount, carryingFood);
            _foodCrumbSpriteRenderer.sprite = null;
            _isCarryingFood = false;
            if (_lastFood!=null)
            {
                SetDestination(_lastFood.transform.position.ToVector2_Y());
            }
            else
            {
                StopMoving();
            }
        }

        if (other.tag == "Enemy")
        {
            other.GetComponent<EnemyScript>().TakeDamage(_damage);
            Die();
        }
    }

    [ContextMenu("DIE")]
    private void Die()
    {
        var blood = GameObject.Instantiate(_bloodParticle.gameObject);
        blood.transform.position = _transform.position;
        blood.SetActive(true);
        _speed = 1;
        GetComponent<SpriteRenderer>().color = Color.white;
        transform.localScale = new Vector3(0.05f, 0.05f, 0.05f);
        FindObjectOfType<SoundManager>().PlayantDie();
        gameObject.SetActive(false);
    }

}
