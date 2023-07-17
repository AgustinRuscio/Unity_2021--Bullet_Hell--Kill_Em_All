using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletManager : MonoBehaviour
{
    public static BulletManager instance;

    [Header("Factory")]
    private BulletFactory _normalBulletsFactory;
    private BulletFactory _rockerFactory;

    [SerializeField]
    private Bullet _bulletPrefab;

    [SerializeField]
    private Bullet _rocketPrefab;

    private void Awake()
    {
        if (instance == null)
            instance = this;
        else
            Destroy(gameObject);


        _normalBulletsFactory = new BulletFactory(_bulletPrefab);
        _rockerFactory = new BulletFactory(_rocketPrefab);
    }

    public BulletFactory BulletFactory() => _normalBulletsFactory;
    public BulletFactory RcoketFactory() => _rockerFactory;
}