using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Collider), typeof(Rigidbody))]
public class BasicBullet : MonoBehaviour, IBullet, IMovable
{
    #region IBULLET_PROPERTIES
    public float LifeTime => _lifeTime;
    public LayerMask HitteableLayer => _hitteableLayer;
    public IWeapon Owner => _owner;

    #endregion

    #region IMOVABLE_PROPERTIES
    public float MovementSpeed => _movementSpeed;

    #region NOT_USED
    public KeyCode MoveForward => throw new System.NotImplementedException();

    public KeyCode MoveBackward => throw new System.NotImplementedException();

    public KeyCode MoveRight => throw new System.NotImplementedException();

    public KeyCode MoveLeft => throw new System.NotImplementedException();

    
    #endregion
    #endregion

    #region PRIVATE_PROPERTIES
    [SerializeField] private float _movementSpeed = 10f;
    [SerializeField] private float _lifeTime = 5f;
    
    [SerializeField] private LayerMask _hitteableLayer;
    [SerializeField] private IWeapon _owner;
    [SerializeField] private ElementalAffinity damageAffinity; 

    private Collider _collider;
    private Rigidbody _rigidbody;
    #endregion

    #region UNITY_EVENTS
    private void Start()
    {
        _collider = GetComponent<Collider>();
        _rigidbody = GetComponent<Rigidbody>();
        Init();
    }
    
    private void Update()
    {
        Move(transform.forward);

        _lifeTime -= Time.deltaTime;
        if(_lifeTime <= 0) Destroy(gameObject);
    }

    public void OnTriggerEnter(Collider other)
    {
        if(((1<<other.gameObject.layer) & _hitteableLayer) != 0)
        {
            other.GetComponent<Actor>()?.TakeDamage(_owner.Damage, damageAffinity); 
        }
    }
    #endregion

    #region IBULLET_METHODS
    public void Init()
    {
        //Collider
        _collider.isTrigger = true;

        //Rigidbody
        _rigidbody.isKinematic = true;
        _rigidbody.collisionDetectionMode = CollisionDetectionMode.ContinuousDynamic;
    }

    public void SetOwner(IWeapon weapon) => _owner = weapon;
    public IProduct Clone()
    {
        return Instantiate(this);
    }

    public GameObject MyGameObject => gameObject;
    #endregion

    #region IMOVABLE_METHODS
    public void Move(Vector3 direction) => transform.position += direction * _movementSpeed * Time.deltaTime;

   
    #endregion
}
