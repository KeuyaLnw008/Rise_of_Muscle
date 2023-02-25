using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "EventChanel/Player2D")]
public class Player2DProfile : ScriptableObject
{
    [SerializeField] private int _maxHp;
    [SerializeField] private int _hp;
    [SerializeField] private float _moveSpeed;
    [SerializeField] private int _damage;
    [SerializeField] private float _bulletSpeed;
    [SerializeField] private float _fireRate;

    public int maxHp => _maxHp;
    public int hp => _hp;
    public float moveSpeed => _moveSpeed;
    public int damage => _damage;
    public float bulletSpeed => _bulletSpeed;
    public float fireRate => _fireRate;
}
