using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Observer;

public class Character : Actor, IMovable
{
    #region PUBLIC_PROPERTIES
    public float MovementSpeed => _stats.MovementSpeed;

    #region KEY_BINDING
    public KeyCode MoveForward => _moveForward;

    public KeyCode MoveBackward => _moveBackward;

    public KeyCode MoveRight => _moveRight;

    public KeyCode MoveLeft => _moveLeft;
    #endregion
    #endregion

    #region  PRIVATE_PROPERTIES
    [SerializeField] private IWeapon _currentWeapon; 
    [SerializeField] private List<GameObject> _weaponsList;
    #endregion

    #region KEY_BINDING
    [SerializeField] private KeyCode _moveForward = KeyCode.W;
    [SerializeField] private KeyCode _moveBackward = KeyCode.S;
    [SerializeField] private KeyCode _moveLeft = KeyCode.A;
    [SerializeField] private KeyCode _moveRight = KeyCode.D;

    [SerializeField] private KeyCode _attack = KeyCode.Mouse0;
    [SerializeField] private KeyCode _reload = KeyCode.R;

    [SerializeField] private KeyCode _weaponSlot1 = KeyCode.Alpha1;
    [SerializeField] private KeyCode _weaponSlot2 = KeyCode.Alpha2;
    [SerializeField] private KeyCode _weaponSlot3 = KeyCode.Alpha3;
    #endregion

    [SerializeField] private string eventID;
    private EventsManager EventsManager => EventsManager.Instance;

    #region UNITY_EVENTS

    private void Awake()
    {
        EventsManager.RegisterEvent(eventID);
    }
    void Start()
    {
        base.Start();
        SwitchWeapon(0);
        _currentWeapon.Reload();
    }

    void Update()
    {
        if (Input.GetKey(_moveForward)) Move(transform.forward);
        if (Input.GetKey(_moveBackward)) Move(-transform.forward);
        if (Input.GetKey(_moveLeft)) Move(-transform.right);
        if (Input.GetKey(_moveRight)) Move(transform.right);

        if(Input.GetKeyDown(_attack)) _currentWeapon.Attack();
        if (Input.GetKeyDown(_reload)) _currentWeapon.Reload();

        if (Input.GetKeyDown(_weaponSlot1)) SwitchWeapon(0);
        if (Input.GetKeyDown(_weaponSlot2)) SwitchWeapon(1);
        if(Input.GetKeyDown(_weaponSlot3)) SwitchWeapon(2);
    }
    #endregion

    #region IMOVABLE_METHODS
    public void Move(Vector3 direction)
    {
        transform.position += direction * MovementSpeed * Time.deltaTime;
    }
    #endregion

    #region CLASS_METHODS
    private void SwitchWeapon(int index)
    {
        foreach (GameObject weapon in _weaponsList)
        {
            weapon.gameObject.SetActive(false);
        }

        _weaponsList[index].SetActive(true);
        _currentWeapon = _weaponsList[index].GetComponent<IWeapon>();
    }

    public void PickUPItem(Item itemToPickup)
    {
        EventsManager.DispatchSimpleEvents(eventID);
    }

    public override void Die()
    {
        Debug.Log($"{name} died");
    }
    #endregion
}
