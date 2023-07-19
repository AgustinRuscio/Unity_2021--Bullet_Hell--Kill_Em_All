using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletManager : MonoBehaviour
{
    public static BulletManager instance;

    [Header("Factory")]
    private BulletFactory _normalBulletsFactory;
    private BulletFactory _rockerFactory;
    private BulletFactory _axeFactory;

    [SerializeField] 
    private bool _bulletsNeeded;

    [SerializeField] 
    private bool _rocketNeeded;

    [SerializeField] 
    private bool _axeNeeded;

    [SerializeField]
    private Bullet _bulletPrefab;

    [SerializeField]
    private Bullet _rocketPrefab;

    [SerializeField]
    private Bullet _axePrefab;

    private void Awake()
    {
        if (instance == null)
            instance = this;
        else
            Destroy(gameObject);


        if(_bulletsNeeded)
            _normalBulletsFactory = new BulletFactory(_bulletPrefab);

        if(_rocketNeeded)
            _rockerFactory = new BulletFactory(_rocketPrefab);

        if(_axeNeeded)
            _axeFactory = new BulletFactory(_axePrefab);
    }

    public BulletFactory BulletFactory() => _normalBulletsFactory;
    public BulletFactory RcoketFactory() => _rockerFactory;
    public BulletFactory AxeFactory() => _axeFactory;
}