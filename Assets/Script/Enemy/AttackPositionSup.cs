using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackPositionSup : MonoBehaviour
{
    [SerializeField] private GameObject enemy;
    [SerializeField] private Player2DStats _playerStats;
    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.TryGetComponent(out _playerStats) && enemy.GetComponent<EnemyAttack>().attacking)
        {
            _playerStats.PlayerHP -= enemy.GetComponent<EnemyAttack>()._enemy.damage;
            SoundManager.instance.Play(SoundManager.SoundName.EnemyAttack);
        }
        else { }
        
    }
}
