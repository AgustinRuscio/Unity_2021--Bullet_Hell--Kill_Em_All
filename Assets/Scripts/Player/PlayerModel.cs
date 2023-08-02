//--------------------------------------------
//          Agustin Ruscio & Merdeces Riego
//--------------------------------------------


using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;
using UnityEngine.UI;


[Serializable]
struct WeaponData
{
    public string Name;
    public bool active;
    public Image image;
    public Weapon weapon;
    public GameObject gameObject;
}

[RequireComponent(typeof(Rigidbody))]
public class PlayerModel : MonoBehaviour, IDamageable
{
    private Rigidbody _rigidBody;

    //Controller Delegates
    private Action MovementMethods;
    private Action MouseMethods;
    private Action SystemMethods;

    //View Delegates
    private Action<float, float> MoveAnim;
    private Action<float> UpdateLifeBar;
    private Action DeathAnim;
    private Action<bool> FireAnim;
    private Action<string> UpdateWeaponHud;

    private Animator _animator;

    private Light _light;

    [SerializeField]
    private float _speed;

    private float _baseSpeed;

    [SerializeField]
    private float _maxLife;

    private float _life;

    [SerializeField]
    private Slider _slider;

    [SerializeField]
    private float _rotateSpeed;

    [Header("Weapons")]

    [SerializeField]
    private WeaponData[] _weapons;

    private int _weaponIndex = 0;

    private WeaponData _currentWeapon;
    
    private GenericTimer _timer;

    [SerializeField]
    private float _coolDown;

    [SerializeField]
    private Transform _shootPoint;

    [Header("PowerUps")]
    [SerializeField]
    private GameObject _shield;

    private Vector3 direction;

    public bool shield;

    public float _acceleration = 2f;
    void Awake()
    {
        _baseSpeed = _speed;
        _life = _maxLife;

        _rigidBody = GetComponent<Rigidbody>();
        _animator = GetComponent<Animator>();
        _light = GetComponent<Light>();
        _timer = new GenericTimer().SetCoolDown(_coolDown);

        PlayerController controller = new PlayerController(this);
        MovementMethods += controller.MovementController;
        MouseMethods += controller.WeaponMethods;
        SystemMethods += controller.SystemMethods;

       
        PlayerView view = new PlayerView(_maxLife,this).SetAnimator(_animator).SetSlider(_slider).SetImages(GetAllImages()).SetLight(_light);
        MoveAnim += view.MovingAnim;
        UpdateLifeBar += view.UpdateLifeBar;
        DeathAnim += view.SetDeath;
        FireAnim += view.SetFire;
        UpdateWeaponHud += view.UpdateWeaponSelected;

        foreach (var weapon in _weapons)
        {
            weapon.weapon.SetFireAnim(FireAnim);
            if (!weapon.active)
                weapon.image.enabled = false;
        }

       _currentWeapon = _weapons[_weaponIndex];
        UpdateWeaponHud(_currentWeapon.Name);

        UpdateLifeBar(_life);
    }

    private List<Image> GetAllImages()
    {
        List<Image> images = new List<Image>();

        foreach (var image in _weapons) 
        {
            images.Add(image.image);
        }

        return images;
    }


    void Update()
    {
        _timer.RunTimer();
        MouseMethods();
        SystemMethods();
        MoveAnim(direction.x, direction.z);
    }

    private void FixedUpdate() => MovementMethods();
    

    public void Move(Vector3 dir)
    {
        direction = dir;
        direction.Normalize();
        direction *= _speed;

        Vector3 targetVelocity = direction * _speed;

        Vector3 velocityChange = targetVelocity - direction;

        Vector3 acceleration = velocityChange * _acceleration * Time.fixedDeltaTime;

        direction += acceleration;

        _rigidBody.velocity = direction;
    }

    public void RotatePlayer(Vector3 mousePosition)
    {
        Vector3 dir = mousePosition - transform.position;
        dir.y = 0;

        Quaternion targetRot = Quaternion.LookRotation(dir);
        transform.rotation = Quaternion.Lerp(transform.rotation, targetRot, _rotateSpeed * Time.deltaTime);
    }

    public void TakeDamage(float damage)
    {
        _life -= damage;

        UpdateLifeBar(_life);

        if (_life <= 0)
            Death();
    }

    private void Death()
    {
        DeathAnim();
        EventManager.Trigger(EventEnum.LoseLevel);
    }

    public void PrevWeapon()
    {
        int originalIndex = _weaponIndex;

        do
        {
            _weaponIndex--;

            if (_weaponIndex < 0)
                _weaponIndex = _weapons.Length - 1;

            if (_weapons[_weaponIndex].active)
            {
                ChangeWeapon(_weaponIndex);
                return;
            }

        } while (_weaponIndex != originalIndex);
    }

    public void NextWeapon()
    {
        int originalIndex = _weaponIndex;

        do
        {
            _weaponIndex++;

            if (_weaponIndex >= _weapons.Length)
                _weaponIndex = 0;

            if (_weapons[_weaponIndex].active)
            {
                ChangeWeapon(_weaponIndex);
                return;
            }

        } while (_weaponIndex != originalIndex);
    }

    private void ChangeWeapon(int index)
    {
        _currentWeapon.gameObject.SetActive(false);

        _currentWeapon = _weapons[index];
        _currentWeapon.gameObject.SetActive(true);

        UpdateWeaponHud(_currentWeapon.Name);
    }


    #region PowerUps

    public void ShieldOn(float time) 
    {
        _shield.SetActive(true);
        shield = true;
        StartCoroutine(ShieldOff(time));
    }

    IEnumerator ShieldOff(float time)
    {
        yield return new WaitForSeconds(time);
        shield = false;
        _shield.SetActive(false);
    }

    public void AddLife(float amount)
    {
        _life += amount;

        if (_life > _maxLife)
            _life = _maxLife;

        UpdateLifeBar(_life);
    }

    public void SpeedUp(float multiplayer, float time)
    {
        _speed *= multiplayer;

        StartCoroutine(BackToNormalSpeed(time));
    }

    IEnumerator BackToNormalSpeed(float time)
    {
        yield return new WaitForSeconds(time);
        _speed = _baseSpeed;
    }
    #endregion

    public void Fire(bool fire) => _currentWeapon.weapon.FireWeapon(fire);
}