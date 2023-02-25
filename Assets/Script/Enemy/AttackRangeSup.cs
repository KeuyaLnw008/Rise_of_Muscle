using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackRangeSup : MonoBehaviour
{
    [SerializeField] private GameObject enemy;
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
            enemy.GetComponent<EnemyAttack>().triggerStayCheck = false;
    }
    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player" && collision.gameObject.GetComponent<Player2DStats>().PlayerHP > 0)
            enemy.GetComponent<EnemyAttack>().triggerStayCheck = true;
    }
}
