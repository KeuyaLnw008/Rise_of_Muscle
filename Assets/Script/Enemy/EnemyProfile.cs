using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "EventChanel/Enemy")]
public class EnemyProfile : ScriptableObject
{
    [SerializeField] private int _maxHP;
    [SerializeField] private float _speed;
    [SerializeField] private float _fixYPosition;
    [SerializeField] private float _fixRangeToWalk;
    [SerializeField] private float _fireRate;
    [SerializeField] private int _damage;
    [SerializeField] private float _atkAnimationSec;

    public int maxHP => _maxHP;
    public float speed => _speed;
    public float fixYPosition => _fixYPosition;
    public float fixRangeToWalk => _fixRangeToWalk;
    public float fireRate => _fireRate;
    public int damage => _damage;
    public float atkAnimationSec => _atkAnimationSec;
}

